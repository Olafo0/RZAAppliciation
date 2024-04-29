using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Diagnostics.CodeAnalysis;
using Microsoft.IdentityModel.Tokens;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace RZAAppliciation
{
    public partial class MainForm : Form
    {

        // gets the connection string from the App.config. It contains the necessary data to connect sucessfully to the database
        string connectionString = ConfigurationManager.AppSettings["connectionString"];

        // When the application starts up it gets the file path to the resource folder
        string resourceFileDirectory = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName, "Resources");

        // A list of images
        List<Image> showcaseImagesList = new List<Image>();

        // Creates a new object which will contain the details about the user
        User currentUser = new User();



        public MainForm(string username)
        {
            InitializeComponent();
            ProfileInitialise(username);
            PanelInitialiser();
        }

        private void ProfileInitialise(string username)
        {
            // Get the user data from the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                /* the 'GetUserData' is a stored procedure which is kept safe in the database. This procedure only works
                when it's called like this */
                using (SqlCommand command = new SqlCommand("GetUserData", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@givenUsername", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // read the data from the database 
                            int retrievedUserID = Convert.ToInt32(reader["UserID"]);
                            string retrievedUsername = reader["Username"].ToString();
                            string retrievedPassword = reader["Password_"].ToString();
                            string retrievedEmail = reader["Email"].ToString();
                            string retrievedFirstName = reader["FirstName"].ToString();
                            string retrievedLastName = reader["LastName"].ToString();
                            Boolean retrievedTwoFa = Convert.ToBoolean(reader["is2FA"]);
                            string retrievedMemberType = reader["MemberType"].ToString();
                            int retrievedMemberStreak = Convert.ToInt32(reader["MemberStreak"]);
                            int retrievedPoints = Convert.ToInt32(reader["Points"]);
                            string retrievedHomeAddress = reader["HomeAddress"].ToString();

                            User userData = new User(retrievedUserID, retrievedUsername, retrievedPassword, retrievedEmail, retrievedFirstName, retrievedLastName,
                                retrievedTwoFa, retrievedMemberType, retrievedMemberStreak, retrievedPoints, retrievedHomeAddress);
                            currentUser = userData;
                        }
                    }
                }
            }


        }

        /* This function is used to organise all the panels/pages that are used throughout the program in the front-end.
         * 
         */
        private void PanelInitialiser()
        {
            // Placing all the panels in the correct location.
            MainPagePanel.Location = new Point(80, 0);
            ReserveTicketPanel.Location = new Point(79, 0);
            BookingContainerPanel.Location = new Point(17, 18);
            NightsStayingGB.Location = new Point(29, 10);
            BookingEducationPanel.Location = new Point(18, 23);
            ExplorePanel.Location = new Point(80, 0);
            MemberShipPanelContainer.Location = new Point(80, 0);
            MyProfilePanel.Location = new Point(140, 80);
            FaqContainerPanel.Location = new Point(17, 10);

            //Small panels
            SettingsPanel.Location = new Point(86, 12);
            ChangePasswordPanel.Location = new Point(302, 12);
            PageOneOfBookingPanel.Location = new Point(24, 28);
            OrderHistoryPanel.Location = new Point(107, 31);
            BecomeAMemberPanel.Location = new Point(11, 11);
            PaymentGateawayGB.Location = new Point(160, 88);
            ChangeDetailsPanel.Location = new Point(294, 3);
            memberPurchaseGB.Location = new Point(72, 83);


            /* Here are the panels that contain the important information about each location for 
            the ineractive map */
            EastSideToiletPanel.Location = new Point(380, 229);
            WestSideToiletPanel.Location = new Point(102, 133);
            HotelMapPanel.Location = new Point(169, 160);
            EducationalMapPanel.Location = new Point(303, 108);
            SouthBistroMapPanel.Location = new Point(302, 370);
            ShopMapPanel.Location = new Point(367, 136);
            BatMapPanel.Location = new Point(136, 281);
            BananaMapPanel.Location = new Point(323, 262);
            FishMapPanel.Location = new Point(423, 290);
            BigCatPanel.Location = new Point(119, 225);
            ElephantMapPanel.Location = new Point(302, 242);
            HelpCentrePanel.Location = new Point(256, 292);

            // Groupboxes 
            ZooSummaryGB.Location = new Point(32, 29);
            WhosComingZooGB.Location = new Point(41, 3);
            CardTypeGB.Location = new Point(21, 107);
            MainPagePanel.Visible = true;

            // Adds the necessary images to the list
            showcaseImagesList.Add(Image.FromFile(Path.Combine(resourceFileDirectory, "misc\\FamilyZoo1.png")));
            showcaseImagesList.Add(Image.FromFile(Path.Combine(resourceFileDirectory, "misc\\FamilyZoo2.png")));
            showcaseImagesList.Add(Image.FromFile(Path.Combine(resourceFileDirectory, "misc\\FishZooImage.png")));
            showcaseImagesList.Add(Image.FromFile(Path.Combine(resourceFileDirectory, "misc\\LionsZoo.png")));
        }


        // When pressed shows the user the reserve panels.
        private void ReserveTicketsBTN_Click(object sender, EventArgs e)
        {
            MainPagePanel.Visible = false;
            BookingContainerPanel.Visible = false;
            PageOneOfBookingPanel.Visible = false;
            PageTwoOfBookngPanel.Visible = false;
            ReserveTicketPanel.Visible = true;
        }

        /* This button is the home button on the navigation bar. 
         */
        private void MPHomeBTN_Click(object sender, EventArgs e)
        {
            // iterates through all of the controls
            foreach (var item in this.Controls)
            {
                // if it's a panel it will hide it.
                if (item is Panel panel)
                {
                    if (panel.Name != "MainPagePanel" && panel.Name != "NavigationPanel")
                    {
                        panel.Visible = false;
                    }
                    //Unless it is the Mainpage and the navigation panel. These will stay visible.
                    else
                    {
                        panel.Visible = true;
                    }
                }
            }
        }

        /*If the page is not visible will bring up the Frequently asked question page
         * for help.
         */
        private void MPHelpBTN_Click(object sender, EventArgs e)
        {
            if (ExplorePanel.Visible == false)
            {
                ExplorePanel.BringToFront();
                FaqContainerPanel.BringToFront();
                ExplorePanel.Visible = true;
                FaqContainerPanel.Visible = true;
            }
            else
            {
                ExplorePanel.Visible = false;
                FaqContainerPanel.Visible = false;
            }
        }



        private void ReserveTicketPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        // The button for settings button on the navigation panel. 
        private void MPSettingsBTN_Click(object sender, EventArgs e)
        {
            if (SettingsPanel.Visible == false)
            {
                SettingsPanel.Visible = true;
                SettingsPanel.BringToFront();
            }
            else
            {
                SettingsPanel.Visible = false;
                if (ChangePasswordPanel.Visible = true)
                {
                    ChangePasswordPanel.Visible = false;
                }
                if (ChangeDetailsPanel.Visible = true)
                {
                    ChangeDetailsPanel.Visible = false;
                }
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private string tokenForPassword;
        private void ChangePasswordBTN_Click(object sender, EventArgs e)
        {
            if (ChangePasswordPanel.Visible == false)
            {
                ChangePasswordPanel.Visible = true;
                ChangePasswordPanel.BringToFront();

                // Generates a secure token for the email.
                tokenForPassword = TokenGenerator.VerificationToken();
                // sends the email out
                SendEmailVerification(tokenForPassword, currentUser.Email);
            }
            else
            {
                ChangePasswordPanel.Visible = false;
            }
        }


        private void SendEmailVerification(string token, string recipientEmail)
        {
            // The login for the senders email my alt email.- This would be changed to an appropriate email after.
            // This is only for testing purposes.
            string senderEmail = "olliedkxx@gmail.com";
            string senderPassword = "emit yfec gdyg helk";

            // A class used to represent email messages.
            MailMessage mail = new MailMessage(senderEmail, recipientEmail);

            mail.Priority = 0;

            /* Here are two choices that the program chooses depending on the 
             * users selection. If the user is resetting their password it will run the first if statement. If 
             * user is logging in and they have 2FA enabled it will run the other if statement. Each has a different 
             * message.
             */


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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void SettingsChangePassword_Click(object sender, EventArgs e)
        {
            // using regex to ensure that all the requirements for the password change are met.
            Regex ValidatePassword = new Regex("(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[?!@$%^&*-]).{8,}");

            if (NewPasswordTB.ReadOnly == true)
            { }
            else
            {
                if (ValidatePassword.IsMatch(NewPasswordTB.Text))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("PasswordReset", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@givenEmail", currentUser.Email);
                            command.Parameters.AddWithValue("@givenPassword", DataHasher.Datahash(NewPasswordTB.Text).Substring(0, 50));

                            // execute the command
                            command.ExecuteNonQuery();

                            // delete the command from the variable
                            command.Dispose();
                        }
                        // closing the connection.
                        connection.Close();
                    }

                    MessageBox.Show("Password has been changed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Password doesn't meet the requiremetns", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /* This function is run to confirm that the user entered token is the same
         * to the one sent out via email.
        */
        private void SettingsConfirmToken_Click(object sender, EventArgs e)
        {
            if (PasswordTokenTB.Text == tokenForPassword)
            {
                NewPasswordTB.ReadOnly = false;
                SettingsChangePasswordBTN.Enabled = true;
            }
        }

        private void MainMenuLogoutBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BookingHotelBTN_Click(object sender, EventArgs e)
        {
            Bookinginitialiser("Hotel");
        }

        private void BookingZooBTN_Click(object sender, EventArgs e)
        {

            Bookinginitialiser("Zoo");

        }

        private void BookingEducationalBTN_Click(object sender, EventArgs e)
        {
            Bookinginitialiser("Edu");
        }

        // Booking objects for easy management
        ZooOrder currentZooOrder = new ZooOrder(null, "NaN", null, 0, null, 0, 0, 0, 0, false, false, false);
        HotelOrder currentHotelOrder = new HotelOrder(null, "NaN", null, 0, null, 0, null, null, null, null);
        // Buying membership object for easy management
        UserMemberShip currentMembership = new UserMemberShip(null, "f", 0, 0, 0, 0, false);



        string BookingType = "";
        private void Bookinginitialiser(string bookingType)
        {
            // Making the necessary panels visible depending on the booking type
            /* Because there are a lot of panels used throughout the program, I have added 
             * this function to allow for better management.
             */
            BookingContainerCleaner();
            switch (bookingType)
            {
                /* if booking type is zoo it will show the necessry panels.
                 * The same is for hotel and Educational visit (Edu)
                */
                case "Zoo":
                    BookingType = "Zoo";
                    BookingEducationPanel.Visible = false;
                    CheckHotelBTN.Visible = false;
                    RoomTypeCB.Visible = false;
                    NightsStayingGB.Visible = false;

                    dateTimePickerStart.MaxDate = DateTime.Now.AddMonths(5);
                    dateTimePickerStart.MinDate = DateTime.Now;

                    PageOneOfBookingPanel.Visible = true;
                    //DatePickerZooGB.Visible = true;
                    ExtrasHotelPanel.Visible = true;
                    BookingContainerPanel.Visible = true;


                    WhosComingZooGB.Visible = true;
                    break;


                case "Hotel":
                    BookingType = "Hotel";

                    BookingEducationPanel.Visible = false;
                    dateTimePickerStart.MinDate = DateTime.Now;
                    ExtrasHotelPanel.Visible = false;

                    CheckHotelBTN.Visible = true;
                    RoomTypeCB.Visible = true;
                    NightsStayingGB.Visible = true;

                    PageOneOfBookingPanel.Visible = true;
                    BookingContainerPanel.Visible = true;

                    break;

                case "Edu":
                    BookingType = "Edu";
                    dateTimePickerEdu.MinDate = DateTime.Now;
                    BookingEducationPanel.Visible = true;
                    BookingContainerPanel.Visible = true;
                    break;
            }


        }



        decimal totalAdultCost = 0;
        decimal totalStudentCost = 0;
        decimal totalChildCost = 0;
        decimal totalCostZoo = 0;
        /* This function is linked to three numericalUpDown. These are the one for the zoo.
         * the user enters in how many people are coming to the zoo and this function sorts out
         * the price by performing quick calculations.
         */
        private void AttendeesNumericUpDown(object sender, EventArgs e)
        {
            // Setting the price of tickets 
            decimal adultTicketPrice = 25;
            decimal studentTicketPrice = 22;
            decimal childTicketPrice = 19;


            NumericUpDown currentNumeric = sender as NumericUpDown;

            // if user enters in the amout of people who are adults it performs the quick calculations.
            // same could be said for Students and children. 
            if (currentNumeric.Name == "AdultNumeric")
            {
                totalAdultCost = adultTicketPrice * currentNumeric.Value;
                currentZooOrder.Adults = Convert.ToInt32(currentNumeric.Value);
            }
            else if (currentNumeric.Name == "StudentNumeric")
            {
                totalStudentCost = studentTicketPrice * currentNumeric.Value;
                currentZooOrder.Student = Convert.ToInt32(currentNumeric.Value);
            }
            else if (currentNumeric.Name == "ChildNumeric")
            {
                totalChildCost = childTicketPrice * currentNumeric.Value;
                currentZooOrder.Child = Convert.ToInt32(currentNumeric.Value);
            }

            // Adds the total price and shows it to the user.
            // One thing I didn't add here was the 2 year old option. as reflecting back on it it was kind of useless
            currentZooOrder.Price = (totalAdultCost + totalStudentCost + totalChildCost);
            CostOfPeopleTB.Text = $"£{currentZooOrder.Price}";

        }

        /* This function is the red label when bookign something.
         * This will close all the booking panels and will redirect you to the reserve a ticket panel
         */
        private void CloseAllBookingBTN_Click(object sender, EventArgs e)
        {
            BookingContainerPanel.Visible = false;

            if (BookingType == "Zoo")
            {

                //DatePickerZooGB.Visible = false;
                WhosComingZooGB.Visible = false;
                ExtrasHotelPanel.Visible = false;
                AdultNumeric.Value = 0;
                StudentNumeric.Value = 0;
                ChildNumeric.Value = 0;

            }

        }



        decimal TotalTicketCostZOo;
        /* In this function a lot of things happen.
         * Firstly, it will calculate all the final prices with discounts applied for the differen types of orders and give
         * you the amount of points per order. If you have a membership it will give you a extra amout of points.
         * Furthermore, it presents the data in a final form for the summary page.
         */
        private void PageTwoBookingBTN_Click(object sender, EventArgs e)
        {
            switch (BookingType)
            {
                case "Zoo":
                    decimal extra1 = 0;
                    decimal extra2 = 0;
                    decimal extra3 = 0;

                    // These are the extras. 
                    if (BuggyExtra.Checked == true)
                    {
                        currentZooOrder.Extra1 = true;
                        BuggyExtraSumCB.Checked = true;

                        // if user is not a member the price is kept the same.
                        if (currentUser.MemberType == "f" || currentUser.MemberType == "b")
                        {
                            extra1 = 19;
                        }
                        else
                        {
                            extra1 = Convert.ToDecimal(9.50);
                        }

                    }
                    if (MapExtra.Checked == true)
                    {
                        currentZooOrder.Extra2 = true;
                        MapExtraSumCB.Checked = true;
                        if (currentUser.MemberType == "f" || currentUser.MemberType == "b")
                        {
                            extra2 = 5;
                        }
                        else
                        {
                            extra2 = Convert.ToDecimal(2.50);
                        }

                    }
                    if (GuideExtra.Checked == true)
                    {
                        currentZooOrder.Extra3 = true;
                        GuidExtraSumCB.Checked = true;
                        if (currentUser.MemberType == "f" || currentUser.MemberType == "b")
                        {
                            extra2 = 9;
                        }
                        else
                        {
                            extra2 = Convert.ToDecimal(4.50);
                        }

                    }

                    currentZooOrder.DateAttending = dateTimePickerStart.Value;

                    // Adds the total price with extras to the object
                    currentZooOrder.Price += extra1 + extra2 + extra3;

                    // calculates the amout of points 
                    currentZooOrder.Points = Convert.ToInt32(currentZooOrder.Price * Convert.ToDecimal(0.5));



                    // Gives a discount  to members and give extra points
                    if (currentUser.MemberType == "g")
                    {
                        currentZooOrder.Price = currentZooOrder.Price * Convert.ToDecimal(0.70);
                        currentZooOrder.Points = Convert.ToInt32(currentZooOrder.Points * Convert.ToDecimal(1.5));
                    }
                    else if (currentUser.MemberType == "s")
                    {
                        currentZooOrder.Price = currentZooOrder.Price * Convert.ToDecimal(0.90);
                        currentZooOrder.Points = Convert.ToInt32(currentZooOrder.Points * Convert.ToDecimal(1.2));
                    }

                    // Load the next page
                    PageOneOfBookingPanel.Visible = false;
                    PageTwoOfBookngPanel.Visible = true;
                    SummaryPanel.Visible = true;
                    ZooSummaryGB.Visible = true;

                    // Load the data in the Zoo Groupbox
                    //Who's coming 
                    TotalAdultsSumTB.Text = currentZooOrder.Adults.ToString();
                    TotalStudentsSumTB.Text = currentZooOrder.Student.ToString();
                    TotalChildSumTB.Text = currentZooOrder.Child.ToString();
                    //Details
                    YourNameTB.Text = $"{currentUser.FirstName} {currentUser.LastName}";
                    YourAddressTB.Text = $"{currentUser.HomeAddress}";

                    ticketTotoalCostTB.Text = $"{(currentZooOrder.Adults + currentZooOrder.Student + currentZooOrder.Child)}x Tickets £{currentZooOrder.Price}";
                    TotalPriceZoo.Text = $"TOTAL £{currentZooOrder.Price}";
                    break;


                case "Hotel":

                    currentHotelOrder.Points = Convert.ToInt32(currentHotelOrder.Price * Convert.ToDecimal(0.5));
                    // Gives a discount  to members and give extra points
                    if (currentUser.MemberType == "g")
                    {
                        currentHotelOrder.Price = currentHotelOrder.Price * Convert.ToDecimal(0.70);
                        currentHotelOrder.Points = Convert.ToInt32(currentHotelOrder.Points * Convert.ToDecimal(1.5));
                    }
                    else if (currentUser.MemberType == "s")
                    {
                        currentHotelOrder.Price = currentHotelOrder.Price * Convert.ToDecimal(0.90);
                        currentHotelOrder.Points = Convert.ToInt32(currentHotelOrder.Points * Convert.ToDecimal(1.2));
                    }

                    // Load the next page
                    PageOneOfBookingPanel.Visible = false;
                    PageTwoOfBookngPanel.Visible = true;
                    SummaryPanel.Visible = true;
                    HotelSummary.Visible = true;
                    HotelSummary.BringToFront();

                    // Populate the summary 

                    SumRoomTypeTB.Text = currentHotelOrder.RoomType;
                    SumRoomNumber.Text = currentHotelOrder.RoomNumber;
                    SumNightStaying1.Text = currentHotelOrder.NightsStaying.ToString();
                    SumStartDate.Text = currentHotelOrder.DateAttending.ToString();
                    SumDateEndTB.Text = currentHotelOrder.DateTill.ToString();

                    SumYourNameTB.Text = $"{currentUser.FirstName} {currentUser.LastName}";
                    SumYourAddressTB.Text = $"{currentUser.HomeAddress}";

                    SumTotalPrice.Text = $"TOTAL: £{currentHotelOrder.Price}";
                    break;
            }
        }


        private void ZooSummaryGB_Enter(object sender, EventArgs e)
        {
        }


        // If the user is paying by card it will run a number of stored procedures.
        private void PaymentCardBTN_Click(object sender, EventArgs e)
        {
            if (BookingType == "Zoo")
            {
                if (String.IsNullOrEmpty(CardNumberTB.Text) || String.IsNullOrEmpty(SecurityCodeTB.Text) || String.IsNullOrEmpty(ExpiryDateTB.Text))
                {
                    MessageBox.Show("Please enter in the card details.");
                }
                else
                {

                    // This procedure inserts most of the data in the database
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        int ticketId = 0;

                        connection.Open();
                        using (SqlCommand command = new SqlCommand("InsertZooBooking", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@givenUserID", currentUser.UserID);
                            command.Parameters.AddWithValue("@givenAdults", currentZooOrder.Adults);
                            command.Parameters.AddWithValue("@givenStudents", currentZooOrder.Student);
                            command.Parameters.AddWithValue("@givenChildren", currentZooOrder.Child);
                            command.Parameters.AddWithValue("@givenPrice", currentZooOrder.Price);
                            command.Parameters.AddWithValue("@givenPurchaseDate", DateTime.Now.Date);
                            command.Parameters.AddWithValue("@givenDateAttending", currentZooOrder.DateAttending);
                            command.Parameters.AddWithValue("@isBuggy", currentZooOrder.Extra1);
                            command.Parameters.AddWithValue("@isMap", currentZooOrder.Extra2);
                            command.Parameters.AddWithValue("@isGuide", currentZooOrder.Extra3);
                            command.Parameters.AddWithValue("@givenCardNumber", CardNumberTB.Text);

                            // Once the data is added it will retrieve its unique ticketID to generate a unique reference code
                            SqlParameter ticketIdParam = new SqlParameter("@TicketID", SqlDbType.Int);
                            ticketIdParam.Direction = ParameterDirection.Output;
                            command.Parameters.Add(ticketIdParam);

                            command.ExecuteNonQuery();
                            ticketId = Convert.ToInt32(ticketIdParam.Value);

                            command.Dispose();
                        }


                        // Insers the unique reference code in the same record
                        using (SqlCommand command = new SqlCommand("InsertRefZooBooking", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            // generates the unique reference code here
                            command.Parameters.AddWithValue("@givenRef", TokenGenerator.ReferenceGenerator("Zoo", ticketId));
                            command.Parameters.AddWithValue("@givenTicketID", ticketId);

                            command.ExecuteNonQuery();

                            command.Dispose();
                        }

                        // Adding the points from the order to users profile
                        using (SqlCommand command = new SqlCommand("InsertPointsUser", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@givenUserID", currentUser.UserID);
                            command.Parameters.AddWithValue("@givenUserPoints", currentZooOrder.Points);

                            command.ExecuteNonQuery();

                            command.Dispose();
                        }

                        connection.Close();
                    }

                    ProfileInitialise(currentUser.Username);
                    MessageBox.Show("Purchase authenticated", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // same as the previous one.
            else if (BookingType == "Hotel")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    int ticketId = 0;

                    connection.Open();
                    using (SqlCommand command = new SqlCommand("InsertHotelBooking", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@givenUserID", currentUser.UserID);
                        command.Parameters.AddWithValue("@givenNightsStaying", currentHotelOrder.NightsStaying);
                        command.Parameters.AddWithValue("@givenRoomNumber", currentHotelOrder.RoomNumber);
                        command.Parameters.AddWithValue("@givenRoomType", currentHotelOrder.RoomNumber);
                        command.Parameters.AddWithValue("@givenDateAttendning", currentHotelOrder.DateAttending);
                        command.Parameters.AddWithValue("@givenDateTill", currentHotelOrder.DateTill);
                        command.Parameters.AddWithValue("@givenPurchaseDate", DateTime.Now.Date);
                        command.Parameters.AddWithValue("@givenPrice", currentHotelOrder.Price);


                        SqlParameter ticketIdParam = new SqlParameter("@TicketID", SqlDbType.Int);
                        ticketIdParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ticketIdParam);

                        command.ExecuteNonQuery();
                        ticketId = Convert.ToInt32(ticketIdParam.Value);

                        command.Dispose();
                    }

                    using (SqlCommand command = new SqlCommand("InsertRefHotelBooking", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@givenRef", TokenGenerator.ReferenceGenerator("Hotel", ticketId));
                        command.Parameters.AddWithValue("@givenTicketID", ticketId);

                        command.ExecuteNonQuery();

                        command.Dispose();
                    }

                    using (SqlCommand command = new SqlCommand("InsertInHotelRooms", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@givenUserID", currentUser.UserID);
                        command.Parameters.AddWithValue("@givenTicketID", ticketId);
                        command.Parameters.AddWithValue("@givenDateStart", currentHotelOrder.DateAttending);
                        command.Parameters.AddWithValue("@givenDateTill", currentHotelOrder.DateTill);
                        command.Parameters.AddWithValue("@givenRoomNumber", currentHotelOrder.RoomNumber);


                        command.ExecuteNonQuery();
                        command.Dispose();
                    }

                    // Adding the points from the order to users profile
                    using (SqlCommand command = new SqlCommand("InsertPointsUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@givenUserID", currentUser.UserID);
                        command.Parameters.AddWithValue("@givenUserPoints", currentHotelOrder.Points);

                        command.ExecuteNonQuery();

                        command.Dispose();
                    }

                    connection.Close();
                }
                ProfileInitialise(currentUser.Username);
                MessageBox.Show("Purchase authenticated", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            BookingContainerCleaner();
        }

        // This function clears all the panels after they have been used, so old information is not there already.
        private void BookingContainerCleaner()
        {

            foreach (var item in BookingContainerPanel.Controls)
            {
                if (item is Panel panel)
                {
                    foreach (var item2 in panel.Controls)
                    {
                        if (item2 is GroupBox groupBox)
                        {
                            foreach (var item3 in groupBox.Controls)
                            {
                                if (item3 is TextBox textBox)
                                {
                                    textBox.Clear();
                                }
                                else if (item3 is CheckBox checkBox)
                                {
                                    checkBox.Checked = false;
                                }
                                else if (item3 is NumericUpDown numericUpDown)
                                {
                                    numericUpDown.Value = 0;
                                }
                            }
                        }
                    }
                }
            }

            foreach (var item in PageOneOfBookingPanel.Controls)
            {
                if (item is Panel Panel)
                {
                    foreach (var item2 in Panel.Controls)
                    {
                        if (item2 is CheckBox checkBox)
                        {
                            checkBox.Checked = false;
                        }
                        else if (item2 is GroupBox groupBox)
                        {
                            foreach (var item3 in groupBox.Controls)
                            {
                                if (item3 is NumericUpDown numericUpDown)
                                {
                                    numericUpDown.Value = 0;
                                }
                            }
                        }
                    }
                }
            }

            foreach (var item in PageTwoOfBookngPanel.Controls)
            {
                if (item is Panel panel)
                {
                    foreach (var item2 in panel.Controls)
                    {
                        if (item2 is GroupBox groupBox)
                        {
                            foreach (var item3 in groupBox.Controls)
                            {
                                if (item3 is TextBox textBox)
                                {
                                    textBox.Clear();
                                }
                                else if (item3 is NumericUpDown numericUpDown)
                                {
                                    numericUpDown.Value = 0;
                                }
                                else if (item3 is CheckBox checkBox)
                                {
                                    checkBox.Checked = false;
                                }
                                else if (item3 is MaskedTextBox maskTextBox)
                                {
                                    maskTextBox.Clear();
                                }

                            }
                        }
                    }
                }
            }

            if (BookingType == "Zoo")
            {
                currentZooOrder.TicketReference = null;
                currentZooOrder.PurchaseDate = null;
                currentZooOrder.Price = 0;
                currentZooOrder.DateAttending = null;
                currentZooOrder.Adults = null;
                currentZooOrder.Child = null;
                currentZooOrder.Student = null;
                currentZooOrder.Extra1 = null;
                currentZooOrder.Extra2 = null;
                currentZooOrder.Extra3 = null;
            }
            else if (BookingType == "Hotel")
            {
                currentHotelOrder.Price = 0;
                currentHotelOrder.DateTill = null;
                currentHotelOrder.DateAttending = null;
                currentHotelOrder.RoomType = null;
                currentHotelOrder.RoomNumber = null;
                currentHotelOrder.NightsStaying = null;
                currentHotelOrder.TicketReference = null;
                currentHotelOrder.PurchaseDate = null;
            }
        }


        // This is the payment combobox. If user chooses credit card payment it will show them a groupbox about credit cards the same is for payment gateaways
        private void PaymentTypeGB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaymentTypeGB.SelectedIndex == 0)
            {
                PaymentGateawayGB.Visible = false;
                CardTypeGB.Visible = true;
            }
            else if (PaymentTypeGB.SelectedIndex == 1)
            {
                CardTypeGB.Visible = false;
                PaymentGateawayGB.Visible = true;
            }
        }

        // Checks if there are free rooms in the hotel. 
        private void CheckHotelBTN_Click(object sender, EventArgs e)
        {
            // Depending what room the user has chosen it will scan and tell you if there are any rooms available of that type.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("RoomChecker", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;


                    if (RoomTypeCB.SelectedIndex == 0)
                    {
                        command.Parameters.AddWithValue("@givenRoomType", "One bed");
                        currentHotelOrder.RoomType = "One bedroom";
                    }
                    else if (RoomTypeCB.SelectedIndex == 1)
                    {
                        command.Parameters.AddWithValue("@givenRoomType", "Two bed");
                        currentHotelOrder.RoomType = "Two bedroom";
                    }
                    else if (RoomTypeCB.SelectedIndex == 2)
                    {
                        command.Parameters.AddWithValue("@givenRoomType", "Three bed");
                        currentHotelOrder.RoomType = "Three bedroom";
                        TotalPriceHotel.Text = "0";
                    }

                    // The information is fetched back from here.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> availableRooms = new List<string>();
                        while (reader.Read())
                        {
                            availableRooms.Add(reader["RoomNumber"].ToString());
                        }

                        // If there are more rooms available than 0 it will give you the first option.
                        if (availableRooms.Count > 0)
                        {
                            MessageBox.Show("Rooms are avaialble");
                            MessageBox.Show(availableRooms[0].ToString());
                            currentHotelOrder.RoomNumber = availableRooms[0];
                        }
                        // else it will tell the user that the rooms are not available
                        else
                        {
                            MessageBox.Show("There are no available rooms to book currently", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                }
            }

            NightPerStayCB.Enabled = true;
        }

        /* This function is linked to one numericalUpDown. Its for the Hotel.
        * the user enters in how many days they are comming to stay at the hotel.
        * Calculates how long they are staying and the price.
        */
        private void NightStayingValueCh(object sender, EventArgs e)
        {
            decimal oneBedPrice = 60;
            decimal twoBedPrice = 70;
            decimal ThreeBedPrice = 90;
            decimal totalCostHotel = 0;


            NumericUpDown currentNumeric = sender as NumericUpDown;


            if (currentNumeric.Name == "NightPerStayCB")
            {
                // Looks at what type of room the customer is booking 
                if (RoomTypeCB.SelectedIndex == 0)
                {

                    totalCostHotel = oneBedPrice * currentNumeric.Value;
                }
                else if (RoomTypeCB.SelectedIndex == 1)
                {
                    totalCostHotel = twoBedPrice * currentNumeric.Value;
                }
                else if (RoomTypeCB.SelectedIndex == 2)
                {
                    totalCostHotel = ThreeBedPrice * currentNumeric.Value;

                }

                // Calculates how long they are staying.
                DateTime stayingTill = dateTimePickerStart.Value.Date.AddDays(Convert.ToDouble(currentNumeric.Value));

                currentHotelOrder.DateAttending = dateTimePickerStart.Value.Date;
                currentHotelOrder.DateTill = stayingTill;
                currentHotelOrder.Price = totalCostHotel;
                currentHotelOrder.NightsStaying = Convert.ToInt32(currentNumeric.Value);
                DateTillLB.Text = $"Staying until: {stayingTill.ToString("dd/MM/yyyy")}";
                TotalPriceHotel.Text = $"TOTAL PRICE £{totalCostHotel}";

                //totalCostZoo = (totalAdultCost + totalStudentCost + totalChildCost);
                //CostOfPeopleTB.Text = $"£{totalCostZoo}";

            }
        }

        private void RoomTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckHotelBTN.Enabled = true;
            if (RoomTypeCB.SelectedIndex == 0)
            {
                currentHotelOrder.RoomType = "One Bed";
            }
            else if (RoomTypeCB.SelectedIndex == 1)
            {
                currentHotelOrder.RoomType = "Two Bed";
            }
            else if (RoomTypeCB.SelectedIndex == 2)
            {
                currentHotelOrder.RoomType = "Three Bed";
            }

            TotalPriceHotel.Text = $"TOTAL PRICE £ 0";
            currentHotelOrder.Price = 0;
        }

        private void ChangeDetailsBookingBTN_Click(object sender, EventArgs e)
        {
            PageTwoOfBookngPanel.Visible = false;
            PageOneOfBookingPanel.Visible = true;
        }

        private void ChangeDetailsBTN2_Click(object sender, EventArgs e)
        {
            PageTwoOfBookngPanel.Visible = false;
            PageOneOfBookingPanel.Visible = true;
        }

        private void MPOrdersBTN_Click(object sender, EventArgs e)
        {
            if (OrderHistoryPanel.Visible == false)
            {
                OrderHistoryPanel.Visible = true;
                OrderHistoryPanel.BringToFront();
                OrderTimeline.Controls.Clear();
                OrderHistoryType.SelectedIndex = 0;
                OrderHistoryTime.SelectedIndex = 0;
                OrderHistoryPopulator("Zoo", new DateTime(1753, 1, 1));
            }
            else if (OrderHistoryPanel.Visible == true)
            {
                OrderHistoryPanel.Visible = false;
            }
        }

        private void OrderHistoryType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        /* This function retirives all the orders the user has made depending on the booking type and the time provided.
         * It will dynamically make all the necessary panels for each order and populate the order history timeline.
         */
        private void OrderHistoryPopulator(string OrderHistoryType, DateTime OrderTime)
        {
            if (OrderHistoryType == "Zoo")
            {
                List<ZooOrder> usersZooOrderHistory = new List<ZooOrder>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Running the stored procedure which gets all the orders that the user has made.
                    using (SqlCommand command = new SqlCommand("ZooOrderHistory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // we provide the necessary parameters.
                        command.Parameters.AddWithValue("@givenUserID", currentUser.UserID);
                        command.Parameters.AddWithValue("@givenDate", OrderTime);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int PanelCounter = 1;

                            // Each time infomration is fetched it will create a viewable panel and add it to the order history timeline.
                            while (reader.Read())
                            {
                                int ticketID = Convert.ToInt32(reader["TicketID"]);
                                string ticketRef = reader["TicketReference"].ToString();
                                int adults = Convert.ToInt32(reader["Adults"]);
                                int children = Convert.ToInt32(reader["Child"]);
                                int students = Convert.ToInt32(reader["Student"]);
                                int price = Convert.ToInt32(reader["Price"]);
                                string purchaseDate = reader["DatePurchase"].ToString();
                                string dateAttending = reader["DateAttending"].ToString();
                                Boolean buggy = Convert.ToBoolean(reader["Buggy"]);
                                Boolean map = Convert.ToBoolean(reader["Map"]);
                                Boolean guide = Convert.ToBoolean(reader["Guide"]);
                                string cardNumber = reader["Cardnumber"].ToString().Substring(10);

                                ZooOrder thisZooOrder = new ZooOrder(ticketID, ticketRef, Convert.ToDateTime(purchaseDate), price, Convert.ToDateTime(dateAttending), 0, adults, children, students, buggy, map, guide);

                                Boolean[] extrasArray = new Boolean[3] { buggy, map, guide };
                                // Make the panels

                                // The main panel is created 
                                Panel MainPanel = new Panel();
                                MainPanel.BackColor = Color.Transparent;
                                MainPanel.Size = new Size(465, 150);
                                MainPanel.BackgroundImage = Image.FromFile(Path.Combine(resourceFileDirectory, "Background\\ZooOrderHistorySmallPanels.png"));
                                MainPanel.BackgroundImageLayout = ImageLayout.Stretch;


                                // After this all the controls on the panel are made. This includes the labels and buttons.
                                Button ManageButton = new Button();
                                ManageButton.Size = new Size(100, 55);
                                ManageButton.FlatStyle = FlatStyle.Flat;
                                ManageButton.FlatAppearance.BorderSize = 0;
                                ManageButton.BackgroundImage = Image.FromFile(Path.Combine(resourceFileDirectory, "Buttons\\YellowButton.png"));
                                ManageButton.BackgroundImageLayout = ImageLayout.Stretch;
                                ManageButton.BackColor = Color.Transparent;
                                ManageButton.FlatAppearance.BorderSize = 0;
                                ManageButton.Text = "Manage order";
                                // adding a function to the dynamic button
                                ManageButton.Click += ManageButtonZoo_Click;
                                ManageButton.Tag = thisZooOrder;
                                ManageButton.Location = new Point(350, 90);
                                ManageButton.Cursor = Cursors.Hand;

                                Button ViewExtras = new Button();
                                ViewExtras.Size = new Size(100, 50);
                                ViewExtras.FlatStyle = FlatStyle.Flat;
                                ViewExtras.FlatAppearance.BorderSize = 0;
                                ViewExtras.BackgroundImage = Image.FromFile(Path.Combine(resourceFileDirectory, "Buttons\\YellowButton.png"));
                                ViewExtras.BackgroundImageLayout = ImageLayout.Stretch;
                                ViewExtras.BackColor = Color.Transparent;
                                ViewExtras.Text = "View Extra";
                                ViewExtras.Click += ViewExtras_Click;
                                ViewExtras.Tag = extrasArray;
                                ViewExtras.Location = new Point(350, 15);
                                ViewExtras.Cursor = Cursors.Hand;

                                Label OrderPlacedLB = new Label();
                                OrderPlacedLB.Text = $"Order placed: {purchaseDate}";
                                OrderPlacedLB.AutoSize = true;
                                OrderPlacedLB.Location = new Point(50, 15);
                                OrderPlacedLB.BackColor = Color.Transparent;

                                Label PriceLB = new Label();
                                PriceLB.Text = $"Price: £{price}";
                                PriceLB.Location = new Point(50, 40);
                                PriceLB.BackColor = Color.Transparent;

                                Label ReferenceLB = new Label();
                                ReferenceLB.AutoSize = true;
                                ReferenceLB.Text = $"Reference Code: {ticketRef}";
                                ReferenceLB.BackColor = Color.Transparent;

                                ReferenceLB.Location = new Point(50, 65);

                                Label AttendingLB = new Label();
                                AttendingLB.Text = $"Visiting: {dateAttending}";
                                AttendingLB.AutoSize = true;
                                AttendingLB.Location = new Point(50, 90);
                                AttendingLB.BackColor = Color.Transparent;

                                Label WhoseComingLB = new Label();
                                WhoseComingLB.Text = $"Adult(s) {adults} : Child(ren) {children} : Student(s) {students}";
                                WhoseComingLB.AutoSize = true;
                                WhoseComingLB.Location = new Point(50, 115);
                                WhoseComingLB.BackColor = Color.Transparent;

                                Label PanelNumberLB = new Label();
                                PanelNumberLB.Text = $"{PanelCounter}";
                                PanelNumberLB.Location = new Point(10, 5);
                                PanelNumberLB.BackColor = Color.Transparent;

                                PanelCounter += 1;

                                MainPanel.Controls.Add(ManageButton);
                                MainPanel.Controls.Add(ViewExtras);
                                MainPanel.Controls.Add(OrderPlacedLB);
                                MainPanel.Controls.Add(PriceLB);
                                MainPanel.Controls.Add(ReferenceLB);
                                MainPanel.Controls.Add(AttendingLB);
                                MainPanel.Controls.Add(WhoseComingLB);
                                MainPanel.Controls.Add(PanelNumberLB);

                                // adding the order to the timeline
                                OrderTimeline.Controls.Add(MainPanel);
                                OrderTimeline.Controls.SetChildIndex(MainPanel, 0);
                            }
                            command.Dispose();
                        }
                        connection.Close();
                    }
                }
            }

            else if (OrderHistoryType == "Hotel")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("HotelOrderHistory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@givenUserID", currentUser.UserID);
                        command.Parameters.AddWithValue("@givenDate", OrderTime);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int PanelCounter = 1;

                            while (reader.Read())
                            {
                                int ticketID = Convert.ToInt32(reader["TicketID"]);
                                string ticketRef = reader["TicketReference"].ToString();
                                int nightsStaying = Convert.ToInt32(reader["NightsStaying"]);
                                string roomType = reader["RoomType"].ToString();
                                string purchaseDate = reader["PurchaseDate"].ToString();
                                string dateAttending = reader["DateAttending"].ToString();
                                string dateTill = reader["DateTill"].ToString();
                                int price = Convert.ToInt32(reader["Price"]);
                                string roomNumber = reader["RoomNumber"].ToString();


                                HotelOrder thisHotelOrder = new HotelOrder(ticketID, ticketRef, Convert.ToDateTime(purchaseDate), price, Convert.ToDateTime(dateAttending), 0, Convert.ToDateTime(dateTill), nightsStaying, roomType, roomNumber);

                                Panel MainPanel = new Panel();
                                MainPanel.BackColor = Color.Transparent;
                                MainPanel.Size = new Size(465, 150);
                                MainPanel.BackgroundImage = Image.FromFile(Path.Combine(resourceFileDirectory, "Background\\ZooOrderHistorySmallPanels.png"));
                                MainPanel.BackgroundImageLayout = ImageLayout.Stretch;

                                Button ManageButton = new Button();
                                ManageButton.Size = new Size(100, 55);
                                ManageButton.FlatStyle = FlatStyle.Flat;
                                ManageButton.FlatAppearance.BorderSize = 0;
                                ManageButton.BackgroundImage = Image.FromFile(Path.Combine(resourceFileDirectory, "Buttons\\YellowButton.png"));
                                ManageButton.BackgroundImageLayout = ImageLayout.Stretch;
                                ManageButton.BackColor = Color.Transparent;
                                ManageButton.Text = "Manage order";
                                ManageButton.Click += ManageButtonHotel_Click;
                                ManageButton.Tag = thisHotelOrder;
                                ManageButton.Location = new Point(328, 10);
                                ManageButton.Cursor = Cursors.Hand;

                                Label OrderPlacedLB = new Label();
                                OrderPlacedLB.Text = $"Order placed: {purchaseDate}";
                                OrderPlacedLB.AutoSize = true;
                                OrderPlacedLB.Location = new Point(50, 15);

                                Label PriceLB = new Label();
                                PriceLB.Text = $"Price: £{price}";
                                PriceLB.Location = new Point(50, 40);

                                Label ReferenceLB = new Label();
                                ReferenceLB.AutoSize = true;
                                ReferenceLB.Text = $"Reference Code: {ticketRef}";
                                ReferenceLB.Location = new Point(50, 65);

                                Label AttendingLB = new Label();
                                AttendingLB.Text = $"Start Date: {dateAttending}";
                                AttendingLB.AutoSize = true;
                                AttendingLB.Location = new Point(50, 90);

                                Label AttendingTillLB = new Label();
                                AttendingTillLB.Text = $"End Date: {dateTill}";
                                AttendingTillLB.AutoSize = true;
                                AttendingTillLB.Location = new Point(50, 115);

                                Label PanelNumberLB = new Label();
                                PanelNumberLB.Text = $"{PanelCounter}";
                                PanelNumberLB.Location = new Point(10, 5);

                                Label RoomNumberText = new Label();
                                RoomNumberText.Text = "Room Number";
                                RoomNumberText.Font = new Font("Segeo Print", 12, FontStyle.Bold);
                                RoomNumberText.AutoSize = true;
                                RoomNumberText.Location = new Point(315, 80);

                                Label RoomNumber = new Label();
                                RoomNumber.Text = $"{roomNumber}";
                                RoomNumber.Location = new Point(355, 100);


                                PanelCounter += 1;

                                MainPanel.Controls.Add(ManageButton);
                                MainPanel.Controls.Add(OrderPlacedLB);
                                MainPanel.Controls.Add(PriceLB);
                                MainPanel.Controls.Add(ReferenceLB);
                                MainPanel.Controls.Add(AttendingLB);
                                MainPanel.Controls.Add(AttendingTillLB);
                                MainPanel.Controls.Add(PanelNumberLB);
                                MainPanel.Controls.Add(RoomNumberText);
                                MainPanel.Controls.Add(RoomNumber);

                                OrderTimeline.Controls.Add(MainPanel);
                                OrderTimeline.Controls.SetChildIndex(MainPanel, 0);

                            }
                            command.Dispose();
                        }
                        connection.Close();
                    }
                }
            }
        }
        // 

        /* This button is linked to the view extra button on each order
        when the user presses the button it sends the data across to this function and then
       creates a panel where the user can view their extras on their order.
        */
        private void ViewExtras_Click(object? sender, EventArgs e)
        {
            Button btn = sender as Button;
            Boolean[] userExtras = (Boolean[])btn.Tag;

            Panel viewExtraPanel = new Panel();
            viewExtraPanel.Size = new Size(250, 170);
            viewExtraPanel.Location = new Point(200, 160);


            // Title Label
            Label titleLabel = new Label();
            titleLabel.Text = "Extras booked";
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segeo Print", 12);
            titleLabel.Location = new Point(47, 10);


            // Buggy Extra
            Label buggyExtraLB = new Label();
            buggyExtraLB.Text = "Buggy:";
            buggyExtraLB.Font = new Font("Segeo Print", 10);
            buggyExtraLB.Location = new Point(30, 50);

            CheckBox buggyCheckBox = new CheckBox();
            buggyCheckBox.Enabled = false;
            buggyCheckBox.Location = new Point(170, 50);
            if (userExtras[0] == true)
            {
                buggyCheckBox.Checked = true;
            }
            else
            {
                buggyCheckBox.Checked = false;
            }


            // Map Extra
            Label mapExtraLB = new Label();
            mapExtraLB.Text = "Map:";
            mapExtraLB.Font = new Font("Segeo Print", 10);
            mapExtraLB.Location = new Point(30, 75);

            CheckBox mapCheckBox = new CheckBox();
            mapCheckBox.Enabled = false;
            mapCheckBox.Location = new Point(170, 75);
            if (userExtras[1] == true)
            {
                mapCheckBox.Checked = true;
            }
            else
            {
                mapCheckBox.Checked = false;
            }


            // Guide Extra
            Label guideExtraLB = new Label();
            guideExtraLB.Text = "Guide:";
            guideExtraLB.Font = new Font("Segeo Print", 10);
            guideExtraLB.Location = new Point(30, 100);

            CheckBox guideCheckBox = new CheckBox();
            guideCheckBox.Location = new Point(170, 100);
            guideCheckBox.Enabled = false;
            if (userExtras[2] == true)
            {
                guideCheckBox.Checked = true;
            }
            else
            {
                guideCheckBox.Checked = false;
            }

            // Close button
            Button closeButton = new Button();
            closeButton.Text = "Close";
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Size = new Size(60, 35);
            closeButton.Location = new Point(90, 125);
            closeButton.Cursor = Cursors.Hand;
            closeButton.BackColor = Color.DarkRed;
            closeButton.Click += (closeSender, closeArgs) =>
            {
                viewExtraPanel.Dispose(); // Closes the panel
            };

            OrderHistoryPanel.Controls.Add(viewExtraPanel);
            viewExtraPanel.Controls.Add(buggyExtraLB);
            viewExtraPanel.Controls.Add(buggyCheckBox);
            viewExtraPanel.Controls.Add(mapExtraLB);
            viewExtraPanel.Controls.Add(mapCheckBox);
            viewExtraPanel.Controls.Add(guideExtraLB);
            viewExtraPanel.Controls.Add(guideCheckBox);
            viewExtraPanel.Controls.Add(closeButton);
            viewExtraPanel.Controls.Add(titleLabel);
            viewExtraPanel.BringToFront();
        }

        // function runs the function OrderHistoryPopulator which fetches data and create panels to add to the order timeline 
        private void OrderHistoryFilter_Click(object sender, EventArgs e)
        {

            // Booking type Zoo
            OrderTimeline.Controls.Clear();
            if (OrderHistoryType.SelectedIndex == 0 && OrderHistoryTime.SelectedIndex == 0)
            {
                OrderHistoryPopulator("Zoo", new DateTime(1753, 1, 1));
            }
            else if (OrderHistoryType.SelectedIndex == 0 && OrderHistoryTime.SelectedIndex == 1)
            {
                OrderHistoryPopulator("Zoo", DateTime.Now.AddMonths(-1));
            }
            else if (OrderHistoryType.SelectedIndex == 0 && OrderHistoryTime.SelectedIndex == 2)
            {
                OrderHistoryPopulator("Zoo", DateTime.Now.AddMonths(-3));
            }
            else if (OrderHistoryType.SelectedIndex == 0 && OrderHistoryTime.SelectedIndex == 3)
            {
                OrderHistoryPopulator("Zoo", DateTime.Now.AddMonths(-6));
            }

            // Booking type Hotel
            else if (OrderHistoryType.SelectedIndex == 1 && OrderHistoryTime.SelectedIndex == 0)
            {
                OrderHistoryPopulator("Hotel", new DateTime(1753, 1, 1));
            }
            else if (OrderHistoryType.SelectedIndex == 1 && OrderHistoryTime.SelectedIndex == 1)
            {
                OrderHistoryPopulator("Hotel", DateTime.Now.AddMonths(-1));
            }
            else if (OrderHistoryType.SelectedIndex == 1 && OrderHistoryTime.SelectedIndex == 2)
            {
                OrderHistoryPopulator("Hotel", DateTime.Now.AddMonths(-3));
            }
            else if (OrderHistoryType.SelectedIndex == 1 && OrderHistoryTime.SelectedIndex == 3)
            {
                OrderHistoryPopulator("Hotel", DateTime.Now.AddMonths(-6));
            }
        }

        private void ExploreBTN_Click(object sender, EventArgs e)
        {
            // Show the user the interactive map panel. 
            ExplorePanel.BringToFront();
            ExplorePanel.Visible = true;

        }


        private void GoBackToMapLB_Click_1(object sender, EventArgs e)
        {
            FaqContainerPanel.Visible = false;
        }

        private void FaqsBTN_Click(object sender, EventArgs e)
        {
            FaqContainerPanel.Visible = true;
        }
        private void FaqTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FaqTypeCB.SelectedIndex == 0)
            {
                FaqHelpPanel.BackgroundImage = Image.FromFile(Path.Combine(resourceFileDirectory, "Background\\GenQuestions.png"));
            }
            else if (FaqTypeCB.SelectedIndex == 1)
            {
                FaqHelpPanel.BackgroundImage = Image.FromFile(Path.Combine(resourceFileDirectory, "Background\\AccountQuestions.png"));
            }
            else if (FaqTypeCB.SelectedIndex == 2)
            {
                FaqHelpPanel.BackgroundImage = Image.FromFile(Path.Combine(resourceFileDirectory, "Background\\EducationalQuestions.png"));
            }
        }

        /* FaqInquiryBTNHere we get the question that the user wants to ask us and send it off to the database, 
        a support staff than will be able to respond to that email via email. */
        private void FaqInquiryBTN_Click(object sender, EventArgs e)
        {
            string userInquiryMSG = Interaction.InputBox("Please write your inquiry below. When done press 'OK' to send of the question.", "Inquiry inputbox", "Write here", 500, 300);
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("InsertInquiry", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@givenUserID", currentUser.UserID);
                        command.Parameters.AddWithValue("@givenEmail", currentUser.Email);
                        command.Parameters.AddWithValue("@givenMessage", userInquiryMSG);

                        command.ExecuteNonQuery();
                        command.Dispose();
                    }
                    connection.Close();
                }
                MessageBox.Show("Inquiry has been submitted", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /* This button is linked to the manage button (Hotel) on each order
        when the user presses the button it sends the data across to this function and then
        creates a panel where the user can manage their orders.
        */
        private void ManageButtonHotel_Click(object? sender, EventArgs e)
        {
            Button btn = sender as Button;
            HotelOrder thisHotelOrder = (HotelOrder)btn.Tag;

            Panel manageOrderPanel = new Panel();
            manageOrderPanel.Size = new Size(250, 170);
            manageOrderPanel.Location = new Point(200, 350);

            // Cancel order
            Button cancelOrderButton = new Button();
            cancelOrderButton.Text = "Cancel Order";
            cancelOrderButton.Size = new Size(100, 35);
            cancelOrderButton.Location = new Point(75, 60);
            cancelOrderButton.BackColor = Color.Orange;
            cancelOrderButton.FlatStyle = FlatStyle.Flat;
            cancelOrderButton.Cursor = Cursors.Hand;
            cancelOrderButton.Click += (closeSender, closeArgs) =>
            {
                /* Checks if the visiting date has already passed, if it has it will give thhem the error message and won't allow
                them to cancel the order */
                if (thisHotelOrder.DateAttending <= DateTime.Now)
                {
                    MessageBox.Show("Can't cancel order", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // cancels the users order. 
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand("deleteOrderHotel", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;

                                command.Parameters.AddWithValue("@givenTicketID", thisHotelOrder.TicketID);

                                command.ExecuteNonQuery();
                                command.Dispose();
                            }
                            connection.Close();
                        }

                        MessageBox.Show("Order canceled", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        if (ex is SqlException sqlEx)
                        {
                            /* This has been done to mitigate a false postive error which would appear when a you cancel your hotel order. 
                            it fully works however a false error is given off.*/
                            MessageBox.Show("Please press 'Cancel Order' again to confirm cancellation", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            };

            // Close button
            Button closeButton = new Button();
            closeButton.Text = "Close";
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Size = new Size(60, 35);
            closeButton.Location = new Point(90, 110);
            closeButton.Cursor = Cursors.Hand;
            closeButton.BackColor = Color.DarkRed;
            // Add a function to the button
            closeButton.Click += (closeSender, closeArgs) =>
            {
                manageOrderPanel.Dispose(); // Closes the panel
            };

            OrderHistoryPanel.Controls.Add(manageOrderPanel);
            manageOrderPanel.Controls.Add(cancelOrderButton);
            manageOrderPanel.Controls.Add(closeButton);
            manageOrderPanel.BringToFront();
        }

        // This function is added to every manage order (zoo) button
        private void ManageButtonZoo_Click(object? sender, EventArgs e)
        {
            Button btn = sender as Button;
            ZooOrder thisZooOrder = (ZooOrder)btn.Tag;

            Panel manageOrderPanel = new Panel();
            manageOrderPanel.Size = new Size(250, 170);
            manageOrderPanel.Location = new Point(200, 350);



            // Cancel order
            Button cancelOrderButton = new Button();
            cancelOrderButton.Text = "Cancel Order";
            cancelOrderButton.Size = new Size(100, 35);
            cancelOrderButton.Location = new Point(75, 60);
            cancelOrderButton.BackColor = Color.Orange;
            cancelOrderButton.FlatStyle = FlatStyle.Flat;
            cancelOrderButton.Cursor = Cursors.Hand;
            cancelOrderButton.Click += (closeSender, closeArgs) =>
            {
                /* Checks if the visiting date has already passed, if it has it will give thhem the error message and won't allow
                them to cancel the order */
                if (thisZooOrder.DateAttending <= DateTime.Now)
                {
                    MessageBox.Show("Can't cancel order", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // cancels the users order. 
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand("deleteOrderZoo", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;

                                command.Parameters.AddWithValue("@givenTicketID", thisZooOrder.TicketID);

                                command.ExecuteNonQuery();
                                command.Dispose();
                            }
                            connection.Close();
                        }

                        MessageBox.Show("Order canceled", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            // Change date 
            // Cancel order
            Button changeDateButton = new Button();
            changeDateButton.Text = "Change visit date";
            changeDateButton.Size = new Size(150, 35);
            changeDateButton.Location = new Point(65, 10);
            changeDateButton.BackColor = Color.Yellow;
            changeDateButton.FlatStyle = FlatStyle.Flat;
            changeDateButton.Cursor = Cursors.Hand;
            changeDateButton.Click += (closeSender, closeArgs) =>
            {
                if (thisZooOrder.DateAttending <= DateTime.Now)
                {
                    MessageBox.Show("Can't cancel order", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int daysToExtend;
                    bool isValidInput = false;
                    // Validates that the user input is a number
                    do
                    {
                        string input = Interaction.InputBox("Enter the number of days you want to push the visit day forward.", "Days to Extend", "5", 500, 500);

                        if (int.TryParse(input, out daysToExtend))
                        {
                            isValidInput = true;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    } while (!isValidInput);

                    // Changes the date in the database. 
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand("changeDateZoo", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;

                                command.Parameters.AddWithValue("@givenTicketID", thisZooOrder.TicketID);
                                command.Parameters.AddWithValue("@givenNewDate", thisZooOrder.DateAttending.Value.Date.AddDays(daysToExtend));

                                command.ExecuteNonQuery();
                                command.Dispose();
                            }
                            connection.Close();
                        }
                        MessageBox.Show("Date has been changed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            // Close button
            Button closeButton = new Button();
            closeButton.Text = "Close";
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Size = new Size(60, 35);
            closeButton.Location = new Point(90, 110);
            closeButton.Cursor = Cursors.Hand;
            closeButton.BackColor = Color.DarkRed;
            closeButton.Click += (closeSender, closeArgs) =>
            {
                manageOrderPanel.Dispose(); // Closes the panel
            };

            OrderHistoryPanel.Controls.Add(manageOrderPanel);
            manageOrderPanel.Controls.Add(cancelOrderButton);
            manageOrderPanel.Controls.Add(closeButton);
            manageOrderPanel.Controls.Add(changeDateButton);
            manageOrderPanel.BringToFront();
        }


        /* For the interactive map
       // This section covers the interactive map which the user can use to retireve vital information.
       // Here when the user hovers over the unqiue icon it will display a panel with the information on it, while
        Mouselevae will hide the panel. */
        private void EastToilet_MouseHover(object sender, EventArgs e)
        {
            EastSideToiletPanel.BringToFront();
            EastSideToiletPanel.Visible = true;
        }

        private void EastToilet_MouseLeave(object sender, EventArgs e)
        {
            EastSideToiletPanel.Visible = false;
        }

        private void WestToilet_MouseHover(object sender, EventArgs e)
        {
            WestSideToiletPanel.BringToFront();
            WestSideToiletPanel.Visible = true;
        }

        private void WestToilet_MouseLeave(object sender, EventArgs e)
        {
            WestSideToiletPanel.Visible = false;
        }

        private void HotelMap_MouseHover(object sender, EventArgs e)
        {

            HotelMapPanel.BringToFront();
            HotelMapPanel.Visible = true;
        }

        private void HotelMap_MouseLeave(object sender, EventArgs e)
        {
            HotelMapPanel.Visible = false;
        }

        private void EducationalVisitMap_MouseHover(object sender, EventArgs e)
        {
            EducationalMapPanel.BringToFront();
            EducationalMapPanel.Visible = true;
        }

        private void EducationalVisitMap_MouseLeave(object sender, EventArgs e)
        {
            EducationalMapPanel.Visible = false;
        }

        private void SouthBistroMap_MouseHover(object sender, EventArgs e)
        {
            SouthBistroMapPanel.BringToFront();
            SouthBistroMapPanel.Visible = true;
        }

        private void SouthBistroMap_MouseLeave(object sender, EventArgs e)
        {
            SouthBistroMapPanel.Visible = false;
        }

        private void MerchStoreMap_MouseHover(object sender, EventArgs e)
        {
            ShopMapPanel.BringToFront();
            ShopMapPanel.Visible = true;
        }

        private void MerchStoreMap_MouseLeave(object sender, EventArgs e)
        {
            ShopMapPanel.Visible = false;
        }

        private void BatMap_MouseHover(object sender, EventArgs e)
        {
            BatMapPanel.BringToFront();
            BatMapPanel.Visible = true;
        }

        private void BatMap_MouseLeave(object sender, EventArgs e)
        {
            BatMapPanel.Visible = false;
        }

        private void BananaMap_MouseHover(object sender, EventArgs e)
        {
            BananaMapPanel.BringToFront();
            BananaMapPanel.Visible = true;
        }

        private void BananaMap_MouseLeave(object sender, EventArgs e)
        {
            BananaMapPanel.Visible = false;
        }

        private void FishMap_MouseHover(object sender, EventArgs e)
        {
            FishMapPanel.BringToFront();
            FishMapPanel.Visible = true;
        }

        private void FishMap_MouseLeave(object sender, EventArgs e)
        {
            FishMapPanel.Visible = false;
        }

        private void LionMap_MouseHover(object sender, EventArgs e)
        {
            BigCatPanel.BringToFront();
            BigCatPanel.Visible = true;
        }

        private void LionMap_MouseLeave(object sender, EventArgs e)
        {
            BigCatPanel.Visible = false;
        }

        private void ElephantMap_MouseHover(object sender, EventArgs e)
        {
            ElephantMapPanel.BringToFront();
            ElephantMapPanel.Visible = true;
        }

        private void ElephantMap_MouseLeave(object sender, EventArgs e)
        {
            ElephantMapPanel.Visible = false;
        }

        private void HelpMap_MouseHover(object sender, EventArgs e)
        {
            HelpCentrePanel.BringToFront();
            HelpCentrePanel.Visible = true;
        }

        private void HelpMap_MouseLeave(object sender, EventArgs e)
        {
            HelpCentrePanel.Visible = false;
        }
        // End of the interactive map section

        private void DietReqCB_CheckedChanged(object sender, EventArgs e)
        {
            if (DietReqCB.Checked == true)
            {
                AddDietaryRestBTN.Enabled = true;
            }
            else
            {
                AddDietaryRestBTN.Enabled = false;
            }
        }


        string DietRestricitionsList = "";
        private void AddDietaryRestBTN_Click(object sender, EventArgs e)
        {
            DietRestricitionsList = Interaction.InputBox("Please enter in a list of the products that shall not be given", "Diet Restrictions", "Enter in a list of items", 500, 500);
        }

        // This function is responsible for sending the educational visit form to the database
        private void SendBookingEdu_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertSchoolBookings", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@givenUserID", currentUser.UserID);
                    command.Parameters.AddWithValue("@givenUserEmail", currentUser.Email);
                    command.Parameters.AddWithValue("@givenSchoolName", SchoolNameBookingTB.Text);
                    command.Parameters.AddWithValue("@givenSchoolAddress", SchoolAddressBookingTB.Text);
                    command.Parameters.AddWithValue("@givenSchoolNumber", SchoolNumberBookingTB.Text);
                    command.Parameters.AddWithValue("@givenDate", dateTimePickerEdu.Value.Date);
                    command.Parameters.AddWithValue("@givenStudents", AmountOfStudentsNU.Value);
                    command.Parameters.AddWithValue("@givenTeachers", AmountOfTeachersNU.Value);
                    command.Parameters.AddWithValue("@givenYearGroup", YearGroupBookingTB.Text);
                    command.Parameters.AddWithValue("@isSnacks", DietReqCB.Checked);
                    command.Parameters.AddWithValue("@givenDietaryRestrictions", DietRestricitionsList);

                    command.ExecuteNonQuery();
                    command.Dispose();
                }
                connection.Close();

                MessageBox.Show("Form sent", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BookingEducationPanel.Visible = false;
                BookingContainerPanel.Visible = false;
                BookingContainerCleaner();
            }
        }


        // Membership section

        Boolean rewardClaimed = false;
        /* When the user clciks the claim button on the Rewards and membership page, the application checks if the user is eligible
         * if not, it will tell the user. If they are their reward is claimed. 
         */
        private void ClaimRewards(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton.Tag != "Gold")
            {
                if (currentUser.MemberType == "g" || currentUser.MemberType == "s" || currentUser.MemberType == "b")
                {
                    clickedButton.Text = "Claimed";
                    clickedButton.BackgroundImage = Image.FromFile(Path.Combine(resourceFileDirectory, "Buttons\\YellowButton.png"));
                    rewardClaimed = true;
                    MessageBox.Show("Claimed items take 1 day to appear", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You're not eligible. Membership required", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (currentUser.MemberType == "g")
                {
                    clickedButton.Text = "Claimed";
                    clickedButton.BackgroundImage = Image.FromFile(Path.Combine(resourceFileDirectory, "Buttons\\YellowButton.png"));
                    rewardClaimed = true;
                }
                else
                {
                    MessageBox.Show("You're not eligible. Gold Membership required", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /* This button redirects the user to the rewards and membership page. In addition, it fills
        * in the necessary details about the user so they can see. 
        */
        private void RewardsMembershipBTN_Click(object sender, EventArgs e)
        {
            MemberShipPanelContainer.Visible = true;
            MemberBenPB.BackgroundImageLayout = ImageLayout.Stretch;
            if (currentUser.MemberType == "g" || currentUser.MemberType == "s" || currentUser.MemberType == "b")
            {
                BecomeMemberRewBTN.Visible = false;
            }
            if (currentUser.MemberType == "g")
            {
                MembershipStatusLB.Text = "GOLD";
                MembershipStatusLB.ForeColor = Color.Gold;
                MemberBenPB.BackgroundImage = Image.FromFile(Path.Combine(resourceFileDirectory, "Background\\GoldPanel.png"));

            }
            else if (currentUser.MemberType == "s")
            {
                MembershipStatusLB.Text = "SILVER";
                MembershipStatusLB.ForeColor = Color.DarkGray;
                MemberBenPB.BackgroundImage = Image.FromFile(Path.Combine(resourceFileDirectory, "Background\\SilverPanel.png"));

            }
            else if (currentUser.MemberType == "b")
            {
                MembershipStatusLB.Text = "BRONZE";
                MembershipStatusLB.ForeColor = Color.RosyBrown;
                MemberBenPB.BackgroundImage = Image.FromFile(Path.Combine(resourceFileDirectory, "Background\\BronzePanel.png"));

            }
            else if (currentUser.MemberType == "f")
            {
                MembershipStatusLB.Text = "None";
                MembershipStatusLB.ForeColor = Color.Black;
            }
            MemberStreakLB.Text = currentUser.MemberStreak.ToString();
            MembershipRenewalLB.Text = "No";
            UserPointsLB.Text = $"POINTS: {currentUser.Points}";
        }

        /* This function calculates the price for all the individuals that will be on the plan.
        * This function is activated every time a value in changed in the NumericUpDown boxes
        */
        private void PeopleOnMembership(object sender, EventArgs e)
        {
            // The membership price per individual
            decimal adultPriceBronze = 40;
            decimal studentPriceBronze = 37;
            decimal childPriceBronze = 30;

            decimal adultPriceSilver = 60;
            decimal studentPriceSilver = 67;
            decimal childPriceSilver = 50;

            decimal adultPriceGold = 90;
            decimal studentPriceGold = 87;
            decimal childPriceGold = 80;


            NumericUpDown numericUpDownData = sender as NumericUpDown;

            if (numericUpDownData.Name == "AdultMemberNU")
            {
                currentMembership.Adults = Convert.ToInt32(numericUpDownData.Value);
            }

            if (numericUpDownData.Name == "StudentMemberNU")
            {
                currentMembership.Students = Convert.ToInt32(numericUpDownData.Value);
            }

            if (numericUpDownData.Name == "ChildMemberNU")
            {
                currentMembership.Children = Convert.ToInt32(numericUpDownData.Value);
            }

            // Calculates the total price depending on what tier they chose
            if (TierTypeCB.SelectedIndex == 0)
            {
                currentMembership.TotalPrice = (currentMembership.Adults * adultPriceGold) + (currentMembership.Students * studentPriceGold) + (currentMembership.Children * childPriceGold);
                currentMembership.MemberType = "g";
            }
            else if (TierTypeCB.SelectedIndex == 1)
            {
                currentMembership.TotalPrice = (currentMembership.Adults * adultPriceSilver) + (currentMembership.Students * studentPriceSilver) + (currentMembership.Children * childPriceSilver);
                currentMembership.MemberType = "s";
            }
            else if (TierTypeCB.SelectedIndex == 2)
            {
                currentMembership.TotalPrice = (currentMembership.Adults * adultPriceBronze) + (currentMembership.Students * studentPriceBronze) + (currentMembership.Children * childPriceBronze);
                currentMembership.MemberType = "b";
            }
            TotalPriceMemLB.Text = $"TOTAL: £{currentMembership.TotalPrice}";
        }


        /* This function is run when the user presses buy on the 'Buying membership'. It will append and update the
        necessary data in the database */
        private void BuyMembershipBTN_Click(object sender, EventArgs e)
        {
            currentMembership.UserID = currentUser.UserID;
            if (RenewalCB.Checked == true)
            {
                currentMembership.Renewal = true;
            }

            try
            {

                string creditNumber = Interaction.InputBox("Enter your 16 card number", "Credit card", "Enter here", 500, 500);
                string pincode = Interaction.InputBox("Enter your 3 security code", "Credit card", "Enter here", 500, 500);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("InsertNewMember", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@givenUserID", currentUser.UserID);
                        command.Parameters.AddWithValue("@givenMemberType", currentMembership.MemberType);
                        command.Parameters.AddWithValue("@givenTotalPrice", currentMembership.TotalPrice);
                        command.Parameters.AddWithValue("@givenAdults", currentMembership.Adults);
                        command.Parameters.AddWithValue("@givenStudents", currentMembership.Students);
                        command.Parameters.AddWithValue("@givenChildren", currentMembership.Children);
                        command.Parameters.AddWithValue("@givenRenewal", currentMembership.Renewal);

                        command.ExecuteNonQuery();
                        command.Dispose();
                    }
                    connection.Close();

                    MessageBox.Show("Purchase authenticated", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BecomeAMemberPanel.Visible = false;
                    AdultMemberNU.Value = 0;
                    StudentMemberNU.Value = 0;
                    ChildMemberNU.Value = 0;
                    RenewalCB.Checked = false;
                    TotalPriceMemLB.Text = "TOTAL: £";
                    currentMembership.UserID = null;
                    currentMembership.MemberType = "f";
                    currentMembership.TotalPrice = 0;
                    currentMembership.Adults = 0;
                    currentMembership.Students = 0;
                    currentMembership.Children = 0;
                    currentMembership.Renewal = false;
                    memberPurchaseGB.Visible = false;
                    ProfileInitialise(currentUser.Username);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BecomeMemberRewBTN_Click(object sender, EventArgs e)
        {
            BecomeAMemberPanel.Visible = true;
        }
        // End of section


        private void MPProfile_Click(object sender, EventArgs e)
        {
            if (MyProfilePanel.Visible == false)
            {
                FirstNameMyProfileLB.Text = currentUser.FirstName;
                LastNameMyProfileLB.Text = currentUser.LastName;
                EmailMyProfileLB.Text = currentUser.Email;
                if (currentUser.MemberType == "g")
                {
                    MemberMyProfileLB.Text = "Gold";
                    MemberMyProfileLB.ForeColor = Color.Gold;
                    MemberMyProfileLB.BackColor = Color.Black;
                }
                else if (currentUser.MemberType == "s")
                {
                    MemberMyProfileLB.Text = "Silver";
                }
                else if (currentUser.MemberType == "b")
                {
                    MemberMyProfileLB.Text = "Gold";
                }
                else
                {
                    MemberMyProfileLB.Text = "None";
                }
                PointsMyProfileLB.Text = currentUser.Points.ToString();
                TwoAfMyProfileLB.Text = currentUser.IsTwoFA.ToString();
                MyProfilePanel.BringToFront();
                MyProfilePanel.Visible = true;
            }
            else if (MyProfilePanel.Visible == true)
            {
                MyProfilePanel.Visible = false;
            }
        }

        // This function allows the user to change their first name from the settings panel.
        private void ChangeFirstNameBTN_Click(object sender, EventArgs e)
        {
            // Asks the user for their new first name
            string newFirstName = Interaction.InputBox("Enter in the new First name", "First Name Change", "Enter here", 500, 500);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UpdateFirstName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@givenUserID", currentUser.UserID);
                    command.Parameters.AddWithValue("@givenFirstName", newFirstName);

                    command.ExecuteNonQuery();
                    command.Dispose();
                }
                connection.Close();
                MessageBox.Show("Last name has been changed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Replaces the old name with the name one while the appliciation is running
                ProfileInitialise(currentUser.Username);
            }
        }

        // This function allows the user to change their last name from the settings panel.
        private void ChangeLastNameBTN_Click(object sender, EventArgs e)
        {
            // Asks the user for their new last name
            string newLastName = Interaction.InputBox("Enter in the new Last name", "Last Name Change", "Enter here", 500, 500);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UpdateLastName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@givenUserID", currentUser.UserID);
                    command.Parameters.AddWithValue("@givenLastName", newLastName);

                    command.ExecuteNonQuery();
                    command.Dispose();
                }
                connection.Close();
                MessageBox.Show("Last name has been changed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Replaces the old name with the name one while the appliciation is running
                ProfileInitialise(currentUser.Username);
            }
        }

        private void ChangeDetailsBTN_Click(object sender, EventArgs e)
        {
            if (ChangeDetailsPanel.Visible == false)
            {
                ChangeDetailsPanel.Visible = true;
                ChangeDetailsPanel.BringToFront();
            }
            else
            {
                ChangeDetailsPanel.Visible = false;
            }
        }

        private void MembershipBannerAdPB_Click(object sender, EventArgs e)
        {
            MemberShipPanelContainer.Visible = true;
            if (currentUser.MemberType == "f")
            {
                BecomeAMemberPanel.Visible = true;
            }
        }

        private void ShortCutHotelBTN_Click(object sender, EventArgs e)
        {
            ReserveTicketPanel.Visible = true;
            Bookinginitialiser("Hotel");
        }

        private void ShortcutZooBTN_Click(object sender, EventArgs e)
        {
            ReserveTicketPanel.Visible = true;
            Bookinginitialiser("Zoo");
        }

        private void ShortcutEducationalBTN_Click(object sender, EventArgs e)
        {
            FaqTypeCB.SelectedIndex = 2;
            ExplorePanel.Visible = true;
            FaqContainerPanel.Visible = true;
            FaqHelpPanel.Visible = true;
        }

        private void ShortcutInquiryBTN_Click(object sender, EventArgs e)
        {
            FaqTypeCB.SelectedIndex = 0;
            ExplorePanel.Visible = true;
            FaqContainerPanel.Visible = true;
            FaqHelpPanel.Visible = true;
        }

        //Chatgpt used on this function.
        private void ResourceBTN_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Process.Start("https://example.com");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}

            // Get the path of the image file from the resources
            string resourcePath = Path.Combine(resourceFileDirectory, "Background\\BronzePanel.png");

            // Destination path to save the image (Desktop)
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string destinationPath = Path.Combine(desktopPath, "downloaded_image.jpg");

            try
            {
                // Read the image bytes from the resources
                using (Stream resourceStream = GetType().Assembly.GetManifestResourceStream(resourcePath))
                {
                    if (resourceStream != null)
                    {
                        // Save the image to the desktop
                        using (FileStream fileStream = File.Create(destinationPath))
                        {
                            resourceStream.CopyTo(fileStream);
                        }

                        MessageBox.Show("Image downloaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to access the image from resources.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error downloading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Image showcase section
        /* When user clicks 'next' button it will go to the next image. 
         * when the user clicks 'back' goes back to the previous image.
         */
        // page number
        int pageNumberShowcase = 1;
        private void NextImageBTN_Click(object sender, EventArgs e)
        {
            pageNumberShowcase++;
            // if page number is max (the length of the list) it will not go forward
            if (pageNumberShowcase == showcaseImagesList.Count)
            {
                pageNumberShowcase = showcaseImagesList.Count - 1;
                ZooShowCase.BackgroundImage = showcaseImagesList[pageNumberShowcase];
            }
            else
            {
                ZooShowCase.BackgroundImage = showcaseImagesList[pageNumberShowcase];
            }
        }

        private void BackImageBTN_Click(object sender, EventArgs e)
        {
            pageNumberShowcase--;
            // if page number is at -1 it will set it back to 0 so the user can't go backwards anymore. 
            if (pageNumberShowcase == -1)
            {
                pageNumberShowcase = 0;
                ZooShowCase.BackgroundImage = showcaseImagesList[pageNumberShowcase];
            }
            else
            {
                ZooShowCase.BackgroundImage = showcaseImagesList[pageNumberShowcase];
            }
        }

        private void SupportReserveLB_Click(object sender, EventArgs e)
        {
            FaqTypeCB.SelectedIndex = 0;
            ExplorePanel.Visible = true;
            FaqContainerPanel.Visible = true;
            FaqHelpPanel.Visible = true;
        }

        private void EdInfoReserveLB_Click(object sender, EventArgs e)
        {
            FaqTypeCB.SelectedIndex = 2;
            ExplorePanel.Visible = true;
            FaqContainerPanel.Visible = true;
            FaqHelpPanel.Visible = true;
        }

        private void Enable2FABTN_Click(object sender, EventArgs e)
        {
            // User has the ability to turn on or off 2-fa. 

            // Generates the token that will be sent off to the users email
            string token = TokenGenerator.VerificationToken();
            SendEmailVerification(token, currentUser.Username);

            // If user has 2-fa off it will enable it by sending an email which will contain a token to the users email that they will need to enter in a input box.
            if (currentUser.IsTwoFA == false)
            {
                string enteredToken = Interaction.InputBox("Enter in the token sent to your email to enable 2-factor authentication", "Enable 2-FA", "Enter here", 500, 500);

                // When the correct token is entered in 2-fa is tunred on
                if (enteredToken == token)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("UpdateTwoFA", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@givenUserID", currentUser.UserID);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Enabled", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Incorrect token entered", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // If user has 2-fa on it will disable it by sending an email which will contain a token to the users email that they will need to enter in a input box.
            else if (currentUser.IsTwoFA == true)
            {
                string enteredToken = Interaction.InputBox("Enter in the token sent to your email to disable 2-factor authentication", "Disable 2-FA", "Enter here", 500, 500);

                // When the correct token is entered in 2-fa is turned off
                if (enteredToken == token)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("UpdateTwoFAOff", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@givenUserID", currentUser.UserID);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Disabled", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Incorrect token entered", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GoToPaymentMemberBTN_Click(object sender, EventArgs e)
        {
            memberPurchaseGB.Visible = true;
        }

        private void MPShopBTN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Under Maintenance", "Notiec", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
