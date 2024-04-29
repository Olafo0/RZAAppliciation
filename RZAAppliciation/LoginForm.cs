using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Azure.Identity;
using System.Reflection.Metadata;

namespace RZAAppliciation
{
    public partial class LoginForm : Form
    {

        string connectionString = ConfigurationManager.AppSettings["connectionString"];
        string backGroundFileDirectory = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName, "Resources\\Background");
        string resourceFileDirectory = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName, "Resources");

        public LoginForm()
        {
            InitializeComponent();

        }

        // Login Panel Location 129, 223
        // Account registration panel Location 29, 73
        // Forgot password panel Location: 64, 76




        /* This function is activated when the user clicks the 'Log in' button. Once clicked it will
         * run the code below. The code below checks if the details (Username and Password) user has provided are the
         * ones that match an account in the database. If they do it will load the main appliciation. However, if they have
         * 2FA they will be another section which the user will need to complete.
         */
        LogginUser currentLogin = new LogginUser();
        private string tokenForTwoFA;
        private void LoginBTN_Click(object sender, EventArgs e)
        {
            /* Entered details by the user are encrypted using our own made function called 'Datahash'.
            This hashes the data using the SHA-256 algorithm */
            string hUsername = DataHasher.Datahash(LoginUsernameTB.Text).Substring(0, 20);
            string hPassword = DataHasher.Datahash(LoginPasswordTB.Text).Substring(0, 50);

            // If the end-user presses 'Log in' and they haven't entered anyting the program won't do anything.
            if (String.IsNullOrEmpty(LoginUsernameTB.Text) || String.IsNullOrEmpty(LoginPasswordTB.Text))
            { }
            else
            {

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("Logincheck", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@givenUsername", hUsername);
                            command.Parameters.AddWithValue("@givenPassword", hPassword);

                            // Runs the LogniCheck stored procedure to check if username and password match the one in the database.
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                // If data found matching appends them to an object which will be used to compare the details provided again for security reasons
                                if (reader.Read())
                                {

                                    string retrievedUsername = reader["Username"].ToString();
                                    string retrievedPassword = reader["Password_"].ToString();
                                    Boolean retrievedTwoFA = Convert.ToBoolean(reader["is2FA"]);

                                    /* While this could of been done differently and easier. I decided to use an object
                                    rather than variables. I can make objects read-only meaning that people can't modify it. If it were simple variables 
                                    hackers could modify them */
                                    LogginUser retrievedData = new LogginUser(retrievedUsername, retrievedPassword, retrievedTwoFA);
                                    currentLogin = retrievedData;
                                }
                            }
                            command.Dispose();
                        }
                        connection.Close();

                        /* Checks the retireved data if they match again. I've done this because I've had instances were
                         * the program would allow a user in if it somewhat matched the password even though it didn't have upper case letters.  
                         */
                        if (currentLogin.Username == hUsername && currentLogin.Password == hPassword)
                        {
                            // If the user has 2FA on, the user will have to provided the sent token to their email to login.
                            if (currentLogin.TwoFA == true)
                            {
                                // 2FA

                                // Generating the token.
                                tokenForTwoFA = TokenGenerator.VerificationToken();

                                // Sending out the email which has the token.
                                SendEmailVerification(tokenForTwoFA, hUsername, "Login");
                                LoginPanel.Visible = false;
                                TwoFAPanel.Location = new Point(129, 223);
                                TwoFAPanel.Visible = true;
                            }
                            else
                            {
                                // if the user doesn't have 2FA on it will simply load the main menu straight away
                                MainForm Main = new MainForm(currentLogin.Username);
                                Main.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username or Password incorrect", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                // If there is an error with the database the user is given the error message, and it prevents the program from crashing.
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        /* The following are labels. When these labels are clicked it will load in their respecitve background 
         * and panel, so the user can use them.
         */
        private void ForgotPasswordLoginLB_Click(object sender, EventArgs e)
        {
            LoginPanel.Visible = false;
            LoginPasswordTB.Clear();
            LoginUsernameTB.Clear();
            BackgroundImage = Image.FromFile(Path.Combine(backGroundFileDirectory, "ForgotPasswordBackground.png"));
            ForgotPasswordPanel.Location = new Point(64, 76);
            ForgotPasswordPanel.Visible = true;
        }

        private void SignUpLoginLB_Click(object sender, EventArgs e)
        {
            LoginPanel.Visible = false;
            AccountRegPanel.Visible = true;
            BackgroundImage = Image.FromFile(Path.Combine(backGroundFileDirectory, "AccountCreationBackground.png"));
            AccountRegPanel.Location = new Point(29, 73);
        }

        private void ARBackToLoginLB_Click(object sender, EventArgs e)
        {
            AccountRegPanel.Visible = false;
            BackgroundImage = Image.FromFile(Path.Combine(backGroundFileDirectory, "LoginBackground.png"));
            LoginPanel.Location = new Point(129, 223);
            LoginPanel.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        /* This function is activited when the user presses down the 'Create Account' button. Here, once the user provides all the 
         * necessary details an account is created. user input is validated and sanitised. 
         */
        private void CreateAccountBTN_Click(object sender, EventArgs e)
        {
            /* REGEX is a library used for easy validation. 
            * The custom made expression does the following:
            * - Checks if the password contains at least one upper and lower case character
            * - Checks if the password contains at least one of the symbols (?!@$%^&*-)
            * - Checks if there is one numerical number between 0-9. 
            * - Checks if the password is at least 8 characters long
            */
            Regex ValidatePassword = new Regex("(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[?!@$%^&*-]).{8,}");


            // Checks if any of the input fields are missing data. If yes gives them a warning
            if (String.IsNullOrEmpty(ARFirstnameTB.Text) || String.IsNullOrEmpty(ARLastName.Text) || String.IsNullOrEmpty(ARHomeaddressTB.Text) || String.IsNullOrEmpty(AREmailaddressTB.Text)
                || String.IsNullOrEmpty(CreatePasswordTB.Text) || String.IsNullOrEmpty(CreateUsernameTB.Text))
            {
                MessageBox.Show("Input field(s) misisng information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string regFirstname = ARFirstnameTB.Text;
                string regLastName = ARLastName.Text;
                string regHomeaddress = ARHomeaddressTB.Text;
                string regEmail = AREmailaddressTB.Text.ToLower();
                string regUsername = CreateUsernameTB.Text;
                string regPassword = CreatePasswordTB.Text;

                Boolean regTwoFAON = false;


                // Check if the email string contains at least a @ 
                if (regEmail.Contains("@") != true)
                {
                    MessageBox.Show("Please enter in an email", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        // Check if email is being used.
                        Boolean emailbeingUsed = false;
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            /* Using a stored procedure EmailCheck to check if there is a matching email in the database. 
                             If there is prevents the user from creating an account */
                            using (SqlCommand command = new SqlCommand("EmailCheck", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@givenEmail", regEmail);

                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        string retrievedEmail = reader["Email"].ToString();

                                        if (retrievedEmail == regEmail)
                                        {
                                            emailbeingUsed = true;
                                        }
                                    }
                                }
                                command.Dispose();
                            }
                            connection.Close();
                        }


                        if (emailbeingUsed == true)
                        {
                            EmailWarningLB.Visible = true;
                        }
                        else
                        {
                            EmailWarningLB.Visible = false;

                            // Hashing the data
                            string hUsername = DataHasher.Datahash(CreateUsernameTB.Text.ToLower()).Substring(0, 20);
                            string hPassword = DataHasher.Datahash(CreatePasswordTB.Text).Substring(0, 50);
                            Boolean usernmaeBeingUsed = false;

                            // Checking if the username is being used already by an account. If it is makes the user create a different one
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();

                                using (SqlCommand command = new SqlCommand("UsernameCheck", connection))
                                {
                                    command.CommandType = CommandType.StoredProcedure;

                                    command.Parameters.AddWithValue("@givenUsername", hUsername);

                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            string retreivedUsername = reader["Username"].ToString();
                                            if (retreivedUsername == hUsername)
                                            {
                                                usernmaeBeingUsed = true;
                                            }
                                        }
                                    }
                                    command.Dispose();
                                }
                                connection.Close();
                            }

                            if (usernmaeBeingUsed == true)
                            {
                                // Makes the warning label visible.
                                WarningUsernameLB.Visible = true;
                            }
                            else
                            {
                                // Using REGEX to see if Password meets the requirements
                                if (ValidatePassword.IsMatch(regPassword))
                                {
                                    if (TAndCCB.Checked == false)
                                    {
                                        MessageBox.Show("Agree to terms before creating an account.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else
                                    {
                                        // Check if 2FA is on so we can mark it as true in the database
                                        if (TwoFACB.Checked == true)
                                        {
                                            regTwoFAON = true;
                                        }

                                        // insert the new data in the database.
                                        using (SqlConnection connection = new SqlConnection(connectionString))
                                        {
                                            connection.Open();

                                            using (SqlCommand command = new SqlCommand("InsertNewAccount", connection))
                                            {
                                                command.CommandType = CommandType.StoredProcedure;

                                                command.Parameters.AddWithValue("@givenUsername", hUsername);
                                                command.Parameters.AddWithValue("@givenPassword", hPassword);
                                                command.Parameters.AddWithValue("@givenEmail", regEmail.ToLower());
                                                command.Parameters.AddWithValue("@givenFirstName", regFirstname);
                                                command.Parameters.AddWithValue("@givenLastName", regLastName);
                                                command.Parameters.AddWithValue("@givenTwoFA", regTwoFAON);
                                                command.Parameters.AddWithValue("@givenHomeAddress", regHomeaddress);

                                                command.ExecuteNonQuery();

                                                command.Dispose();
                                            }
                                            connection.Close();
                                        }

                                        ARFirstnameTB.Clear();
                                        ARLastName.Clear();
                                        AREmailaddressTB.Clear();
                                        ARHomeaddressTB.Clear();
                                        CreateUsernameTB.Clear();
                                        CreatePasswordTB.Clear();

                                        AccountRegPanel.Visible = false;
                                        BackgroundImage = Image.FromFile(Path.Combine(backGroundFileDirectory, "LoginBackground.png"));
                                        LoginPanel.Location = new Point(129, 223);
                                        LoginPanel.Visible = true;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Password doesn't meet the requirements.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        // Labels which change the background and show the correct panels for the user.
        private void FPBackToLoginLB_Click(object sender, EventArgs e)
        {
            ForgotPasswordPanel.Visible = false;
            FPTokenTB.Clear();
            FPEmailTB.Clear();
            BackgroundImage = Image.FromFile(Path.Combine(backGroundFileDirectory, "LoginBackground.png"));
            LoginPanel.Location = new Point(129, 223);
            LoginPanel.Visible = true;
        }

        private void FPSignUpAccountLabel_Click(object sender, EventArgs e)
        {
            ForgotPasswordPanel.Visible = false;
            FPTokenTB.Clear();
            FPEmailTB.Clear();
            BackgroundImage = Image.FromFile(Path.Combine(backGroundFileDirectory, "AccountCreationBackground.png"));
            AccountRegPanel.Location = new Point(29, 73);
            AccountRegPanel.Visible = true;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void label13_Click(object sender, EventArgs e)
        {
        }



        private string retrievedEmailForCode;
        private string tokenForPassword;
        private void FPSendCodeBTN_Click(object sender, EventArgs e)
        {
            //FPEmailTB
            // Check if email exists in the database
            // use to retireved Email to send the token
            Boolean emailUsed = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("EmailCheck", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@givenEmail", FPEmailTB.Text.ToLower());

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            retrievedEmailForCode = reader["Email"].ToString();
                            if (retrievedEmailForCode == FPEmailTB.Text.ToLower())
                            {
                                emailUsed = true;
                            }
                        }
                    }
                    command.Dispose();
                }
                connection.Close();
            }

            if (emailUsed == true)
            {
                // send the token via email
                tokenForPassword = TokenGenerator.VerificationToken();
                SendEmailVerification(tokenForPassword, retrievedEmailForCode, "Forgot Password");
            }
            else
            {
                MessageBox.Show("Account doesn't exist with that email", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Checks if the forgotten password token sent to the user emails matches to what the user has entered in
        private void FPConfirmBTN_Click(object sender, EventArgs e)
        {
            // if it matches it will progress the user further
            if (tokenForPassword == FPTokenTB.Text)
            {

                ForgotPasswordPanel.Visible = false;
                BackgroundImage = Image.FromFile(Path.Combine(backGroundFileDirectory, "PasswordResetBackground.png"));
                ResetPasswordPanel.Location = new Point(82, 161);
                ResetPasswordPanel.Visible = true;
            }
            else
            {
                MessageBox.Show("Token entered doesn't match the one provided with", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FPResendEmailBTN_Click(object sender, EventArgs e)
        {

        }


        // This function is used to send out the tokens via email to the end-users.
        private void SendEmailVerification(string token, string userDetails, string emailType)
        {
            // The login for the senders email my alt email.- This would be changed to an appropriate email after.
            // This is only for testing purposes.
            string senderEmail = "olliedkxx@gmail.com";
            string senderPassword = "emit yfec gdyg helk";

            string userEmail = "";


            /* If the user is logging into their account we don't have their email. The only
             * thing we have is their username, so we use this to retireve their email address
             * in order to send out the 2FA token.
             */
            if (emailType == "Login")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("EmailFind", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@givenUsername", userDetails);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userEmail = reader["Email"].ToString();
                            }
                        }
                    }
                }
            }
            /* If the user is resetting their password, we already have their email address as it is the first
             * meaning we don't need to search for the email.
             */
            else
            {
                userEmail = retrievedEmailForCode;
            }

            string recipientEmail = userEmail;

            // A class used to represent email messages.
            MailMessage mail = new MailMessage(senderEmail, recipientEmail);

            mail.Priority = 0;

            /* Here are two choices that the program chooses depending on the 
             * users selection. If the user is resetting their password it will run the first if statement. If 
             * user is logging in and they have 2FA enabled it will run the other if statement. Each has a different 
             * message.
             */

            if (emailType == "Forgot Password")
            {
                mail.Subject = "Token for resetting password";

                // Creating the text that the user will see in HTML for better presentation
                string htmlBody = $@"
                <html>
                <body style=""font-family: Arial, sans-serif;"">
                    <img src=""cid:logoImage"" alt=""Logo"" style=""display: block; margin: 0 auto; max-width: 200px;"">
                    <p style=""font-size: 15pt; color: #333; text-align: center; margin-top: 20px;"">
                        Hello,<br><br>
                        You've received this email because a request to reset your password has been initilised.<br>
                        If you haven't requested this action, please ignore this email and change your password.<br>
                    </p>
                    <p style=""font-size: 15pt; color: #333; text-align: center; margin-top: 20px;"">
                        Use the token below to reset your password:<br><br>
                    </p>
                    <p style=""font-size: 24pt; color: blue; text-align: center;"">
                        {token}
                    </p>
                </body>
                </html>
                ";
                mail.Body = htmlBody;

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mail.Body, null, MediaTypeNames.Text.Html);

                // Adding the Logo image to the email. (Not as an attachment)
                LinkedResource logoImage = new LinkedResource(Path.Combine(resourceFileDirectory, "Misc\\LogoAttachment.png"), MediaTypeNames.Image.Jpeg);
                logoImage.ContentId = "logoImage";
                htmlView.LinkedResources.Add(logoImage);

                mail.AlternateViews.Add(htmlView);
            }
            else if (emailType == "Login")
            {
                mail.Subject = "2-Factor Authentication Token";


                // Creating the text that the user will see in HTML for better presentation
                string htmlBody = $@"
                <html>
                <body style=""font-family: Arial, sans-serif;"">
                    <img src=""cid:logoImage"" alt=""Logo"" style=""display: block; margin: 0 auto; max-width: 200px;"">
                    <p style=""font-size: 15pt; color: #333; text-align: center; margin-top: 20px;"">
                        Hello,<br><br>
                        Here is your 2-Factor authentication token email which has been requested.<br>
                        If you haven't requested this, please ignore this email and change your password.<br>
                    </p>
                    <p style=""font-size: 15pt; color: #333; text-align: center; margin-top: 20px;"">
                        Use the token below to authorise the login:<br><br>
                    </p>
                    <p style=""font-size: 24pt; color: blue; text-align: center;"">
                        {token}
                    </p>
                </body>
                </html>
                ";

                mail.Body = htmlBody;

                // Adding the Logo image to the email. (Not as an attachment)
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mail.Body, null, MediaTypeNames.Text.Html);

                LinkedResource logoImage = new LinkedResource(Path.Combine(resourceFileDirectory, "Misc\\LogoAttachment.png"), MediaTypeNames.Image.Jpeg);
                logoImage.ContentId = "logoImage";
                htmlView.LinkedResources.Add(logoImage);

                mail.AlternateViews.Add(htmlView);
            }

            // Using simple mail transfer protocol to actually send the email off.
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

            // Port 587 is used for sending encrypted emails using SMTP/
            smtpClient.Port = 587;

            // Logging into the senders email address.
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

            // Enabling Secure Socket layering to encrypt the connection between the servers
            smtpClient.EnableSsl = true;

            try
            {
                // Sending the token off to the users email account. 
                smtpClient.Send(mail);

                if (emailType == "Forgot Password")
                {
                    FPEmailSentPB.Visible = true;
                }
                else if (emailType == "Login")
                {
                    EmailSentTwoFAPB.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // This function is changes the users password to their new one
        private void ChangingPasswordBTN_Click(object sender, EventArgs e)
        {
            /* REGEX is a library used for easy validation. 
             * The custom made expression does the following:
             * - Checks if the password contains at least one upper and lower case character
             * - Checks if the password contains at least one of the symbols (?!@$%^&*-)
             * - Checks if there is one numerical number between 0-9. 
             * - Checks if the password is at least 8 characters long
             */

            Regex ValidatePassword = new Regex("(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[?!@$%^&*-]).{8,}");

            if (ValidatePassword.IsMatch(PRnewUserPasswordTB.Text))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("PasswordReset", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@givenEmail", retrievedEmailForCode);
                        command.Parameters.AddWithValue("@givenPassword", DataHasher.Datahash(PRnewUserPasswordTB.Text).Substring(0, 50));

                        command.ExecuteNonQuery();
                        command.Dispose();
                    }
                    connection.Close();
                }

                MessageBox.Show("Password has been changed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                PRnewUserPasswordTB.Clear();
                FPTokenTB.Clear();
                FPEmailTB.Clear();
                FPEmailSentPB.Visible = false;

                ResetPasswordPanel.Visible = false;
                BackgroundImage = Image.FromFile(Path.Combine(backGroundFileDirectory, "LoginBackground.png"));
                LoginPanel.Location = new Point(129, 223);
                LoginPanel.Visible = true;
            }
            else
            {
                MessageBox.Show("Password doesn't meet the requiremetns", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void BackToLoginFromPR_Click(object sender, EventArgs e)
        {
            PRnewUserPasswordTB.Clear();
            FPTokenTB.Clear();
            FPEmailTB.Clear();

            ResetPasswordPanel.Visible = false;
            BackgroundImage = Image.FromFile(Path.Combine(backGroundFileDirectory, "LoginBackground.png"));
            LoginPanel.Location = new Point(129, 223);
            LoginPanel.Visible = true;
        }


        // This function is used for the confirm button when the user tries to log into their account and it required a 2-Fa token
        private int incorrectTwoFACode;
        private void ConfirmTwoFABTN_Click(object sender, EventArgs e)
        {
            // if the email token matches to the user inputted token
            if (tokenForTwoFA == TwoFATokenTB.Text)
            {
                // Closes the 2-fa panels and logs to user in
                TwoFATokenTB.Clear();
                EmailSentTwoFAPB.Visible = false;
                TwoFAPanel.Visible = false;
                LoginPanel.Visible = true;

                // Logs the user in
                // their username is passed through the form so we can retrieve their data on the other form.
                MainForm mainMenu = new MainForm(currentLogin.Username);
                mainMenu.ShowDialog();

            }
            // if user enters the 2-fa code incorrectly multiple times it will quit the application
            else
            {
                if (incorrectTwoFACode >= 3)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Token is incorrect. {3 - incorrectTwoFACode} trys remaning", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    incorrectTwoFACode++;
                }
            }
        }

        // Resends the 2-fa token to the users email
        private void ResendCodeTwoFABTN_Click(object sender, EventArgs e)
        {
            tokenForTwoFA = TokenGenerator.VerificationToken();
            SendEmailVerification(tokenForTwoFA, currentLogin.Username, "Login");
        }

        private void BackToLoginFromTwoFALB_Click(object sender, EventArgs e)
        {
            TwoFAPanel.Visible = false;
            LoginPanel.Visible = true;
        }


        // temp Button
        private void button1_Click_1(object sender, EventArgs e)
        {

            MainForm mainForm = new MainForm("a665a45920422f9d417e");
            mainForm.ShowDialog();


        }
    }
}

