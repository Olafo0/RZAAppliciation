namespace RZAAppliciation
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            LoginPanel = new Panel();
            LoginBTN = new Button();
            LoginPasswordTB = new TextBox();
            LoginUsernameTB = new TextBox();
            ForgotPasswordLoginLB = new Label();
            SignUpLoginLB = new Label();
            label2 = new Label();
            label1 = new Label();
            AccountRegPanel = new Panel();
            FinalStepsGB = new GroupBox();
            CreateAccountBTN = new Button();
            ARBackToLoginLB = new Label();
            viewTandCLinkL = new LinkLabel();
            TAndCCB = new CheckBox();
            TwoFACB = new CheckBox();
            CreatePasswordGB = new GroupBox();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label9 = new Label();
            CreatePasswordTB = new TextBox();
            label8 = new Label();
            CreateAccountGB = new GroupBox();
            label7 = new Label();
            WarningUsernameLB = new Label();
            CreateUsernameTB = new TextBox();
            label10 = new Label();
            YourDetailsGB = new GroupBox();
            EmailWarningLB = new Label();
            label5 = new Label();
            AREmailaddressTB = new TextBox();
            ARHomeaddressTB = new TextBox();
            ARLastName = new TextBox();
            ARFirstnameTB = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            ForgotPasswordPanel = new Panel();
            FPSignUpAccountLabel = new Label();
            FPBackToLoginLB = new Label();
            panel1 = new Panel();
            label17 = new Label();
            pictureBox2 = new PictureBox();
            FPConfirmBTN = new Button();
            label18 = new Label();
            FPTokenTB = new TextBox();
            FPEnterEmailPanel = new Panel();
            FPEmailSentPB = new PictureBox();
            label16 = new Label();
            pictureBox1 = new PictureBox();
            FPSendCodeBTN = new Button();
            label15 = new Label();
            FPEmailTB = new TextBox();
            ResetPasswordPanel = new Panel();
            BackToLoginFromPR = new Label();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            label23 = new Label();
            label24 = new Label();
            ChangingPasswordBTN = new Button();
            PRnewUserPasswordTB = new TextBox();
            label22 = new Label();
            TwoFAPanel = new Panel();
            BackToLoginFromTwoFALB = new Label();
            label25 = new Label();
            EmailSentTwoFAPB = new PictureBox();
            ResendCodeTwoFABTN = new Button();
            ConfirmTwoFABTN = new Button();
            TwoFATokenTB = new TextBox();
            label28 = new Label();
            button1 = new Button();
            LoginPanel.SuspendLayout();
            AccountRegPanel.SuspendLayout();
            FinalStepsGB.SuspendLayout();
            CreatePasswordGB.SuspendLayout();
            CreateAccountGB.SuspendLayout();
            YourDetailsGB.SuspendLayout();
            ForgotPasswordPanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            FPEnterEmailPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FPEmailSentPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ResetPasswordPanel.SuspendLayout();
            TwoFAPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)EmailSentTwoFAPB).BeginInit();
            SuspendLayout();
            // 
            // LoginPanel
            // 
            LoginPanel.BackColor = Color.Transparent;
            LoginPanel.BackgroundImage = (Image)resources.GetObject("LoginPanel.BackgroundImage");
            LoginPanel.BackgroundImageLayout = ImageLayout.Stretch;
            LoginPanel.Controls.Add(LoginBTN);
            LoginPanel.Controls.Add(LoginPasswordTB);
            LoginPanel.Controls.Add(LoginUsernameTB);
            LoginPanel.Controls.Add(ForgotPasswordLoginLB);
            LoginPanel.Controls.Add(SignUpLoginLB);
            LoginPanel.Controls.Add(label2);
            LoginPanel.Controls.Add(label1);
            LoginPanel.Location = new Point(129, 223);
            LoginPanel.Name = "LoginPanel";
            LoginPanel.Size = new Size(322, 272);
            LoginPanel.TabIndex = 1;
            // 
            // LoginBTN
            // 
            LoginBTN.BackColor = Color.Transparent;
            LoginBTN.BackgroundImage = (Image)resources.GetObject("LoginBTN.BackgroundImage");
            LoginBTN.BackgroundImageLayout = ImageLayout.Stretch;
            LoginBTN.Cursor = Cursors.Hand;
            LoginBTN.FlatAppearance.BorderSize = 0;
            LoginBTN.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 0);
            LoginBTN.FlatAppearance.MouseOverBackColor = Color.Olive;
            LoginBTN.FlatStyle = FlatStyle.Flat;
            LoginBTN.Font = new Font("Segoe Print", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            LoginBTN.Location = new Point(103, 165);
            LoginBTN.Name = "LoginBTN";
            LoginBTN.Size = new Size(114, 48);
            LoginBTN.TabIndex = 6;
            LoginBTN.Text = "Login";
            LoginBTN.UseVisualStyleBackColor = false;
            LoginBTN.Click += LoginBTN_Click;
            // 
            // LoginPasswordTB
            // 
            LoginPasswordTB.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            LoginPasswordTB.Location = new Point(72, 120);
            LoginPasswordTB.Name = "LoginPasswordTB";
            LoginPasswordTB.Size = new Size(182, 33);
            LoginPasswordTB.TabIndex = 5;
            // 
            // LoginUsernameTB
            // 
            LoginUsernameTB.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            LoginUsernameTB.Location = new Point(72, 43);
            LoginUsernameTB.Name = "LoginUsernameTB";
            LoginUsernameTB.Size = new Size(182, 33);
            LoginUsernameTB.TabIndex = 4;
            // 
            // ForgotPasswordLoginLB
            // 
            ForgotPasswordLoginLB.AutoSize = true;
            ForgotPasswordLoginLB.Cursor = Cursors.Hand;
            ForgotPasswordLoginLB.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ForgotPasswordLoginLB.ForeColor = Color.FromArgb(192, 0, 192);
            ForgotPasswordLoginLB.Location = new Point(103, 227);
            ForgotPasswordLoginLB.Name = "ForgotPasswordLoginLB";
            ForgotPasswordLoginLB.Size = new Size(112, 21);
            ForgotPasswordLoginLB.TabIndex = 3;
            ForgotPasswordLoginLB.Text = "Forgot password";
            ForgotPasswordLoginLB.Click += ForgotPasswordLoginLB_Click;
            // 
            // SignUpLoginLB
            // 
            SignUpLoginLB.AutoSize = true;
            SignUpLoginLB.Cursor = Cursors.Hand;
            SignUpLoginLB.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SignUpLoginLB.ForeColor = Color.Purple;
            SignUpLoginLB.Location = new Point(59, 248);
            SignUpLoginLB.Name = "SignUpLoginLB";
            SignUpLoginLB.Size = new Size(209, 21);
            SignUpLoginLB.TabIndex = 2;
            SignUpLoginLB.Text = "Don't have an account? Sign up!";
            SignUpLoginLB.Click += SignUpLoginLB_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(69, 89);
            label2.Name = "label2";
            label2.Size = new Size(88, 28);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(69, 12);
            label1.Name = "label1";
            label1.Size = new Size(91, 28);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // AccountRegPanel
            // 
            AccountRegPanel.BackColor = Color.Transparent;
            AccountRegPanel.BackgroundImage = (Image)resources.GetObject("AccountRegPanel.BackgroundImage");
            AccountRegPanel.BackgroundImageLayout = ImageLayout.Stretch;
            AccountRegPanel.Controls.Add(FinalStepsGB);
            AccountRegPanel.Controls.Add(CreatePasswordGB);
            AccountRegPanel.Controls.Add(CreateAccountGB);
            AccountRegPanel.Controls.Add(YourDetailsGB);
            AccountRegPanel.Location = new Point(12, 619);
            AccountRegPanel.Name = "AccountRegPanel";
            AccountRegPanel.Size = new Size(531, 549);
            AccountRegPanel.TabIndex = 2;
            AccountRegPanel.Visible = false;
            // 
            // FinalStepsGB
            // 
            FinalStepsGB.Controls.Add(CreateAccountBTN);
            FinalStepsGB.Controls.Add(ARBackToLoginLB);
            FinalStepsGB.Controls.Add(viewTandCLinkL);
            FinalStepsGB.Controls.Add(TAndCCB);
            FinalStepsGB.Controls.Add(TwoFACB);
            FinalStepsGB.Font = new Font("Segoe Print", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FinalStepsGB.Location = new Point(313, 327);
            FinalStepsGB.Name = "FinalStepsGB";
            FinalStepsGB.Size = new Size(207, 219);
            FinalStepsGB.TabIndex = 14;
            FinalStepsGB.TabStop = false;
            FinalStepsGB.Text = "Final steps";
            // 
            // CreateAccountBTN
            // 
            CreateAccountBTN.BackColor = Color.Transparent;
            CreateAccountBTN.BackgroundImage = (Image)resources.GetObject("CreateAccountBTN.BackgroundImage");
            CreateAccountBTN.BackgroundImageLayout = ImageLayout.Stretch;
            CreateAccountBTN.Cursor = Cursors.Hand;
            CreateAccountBTN.FlatAppearance.BorderSize = 0;
            CreateAccountBTN.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 0);
            CreateAccountBTN.FlatAppearance.MouseOverBackColor = Color.Olive;
            CreateAccountBTN.FlatStyle = FlatStyle.Flat;
            CreateAccountBTN.Font = new Font("Segoe Print", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            CreateAccountBTN.Location = new Point(17, 135);
            CreateAccountBTN.Name = "CreateAccountBTN";
            CreateAccountBTN.Size = new Size(165, 47);
            CreateAccountBTN.TabIndex = 9;
            CreateAccountBTN.Text = "Create Account";
            CreateAccountBTN.UseVisualStyleBackColor = false;
            CreateAccountBTN.Click += CreateAccountBTN_Click;
            // 
            // ARBackToLoginLB
            // 
            ARBackToLoginLB.AutoSize = true;
            ARBackToLoginLB.Cursor = Cursors.Hand;
            ARBackToLoginLB.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ARBackToLoginLB.ForeColor = Color.Purple;
            ARBackToLoginLB.Location = new Point(70, 188);
            ARBackToLoginLB.Name = "ARBackToLoginLB";
            ARBackToLoginLB.Size = new Size(60, 21);
            ARBackToLoginLB.TabIndex = 8;
            ARBackToLoginLB.Text = "Go Back";
            ARBackToLoginLB.Click += ARBackToLoginLB_Click;
            // 
            // viewTandCLinkL
            // 
            viewTandCLinkL.AutoSize = true;
            viewTandCLinkL.Location = new Point(61, 105);
            viewTandCLinkL.Name = "viewTandCLinkL";
            viewTandCLinkL.Size = new Size(76, 23);
            viewTandCLinkL.TabIndex = 2;
            viewTandCLinkL.TabStop = true;
            viewTandCLinkL.Text = "View T&C";
            viewTandCLinkL.UseMnemonic = false;
            // 
            // TAndCCB
            // 
            TAndCCB.AutoSize = true;
            TAndCCB.Cursor = Cursors.Hand;
            TAndCCB.ForeColor = Color.FromArgb(0, 0, 192);
            TAndCCB.Location = new Point(17, 73);
            TAndCCB.Name = "TAndCCB";
            TAndCCB.Size = new Size(173, 27);
            TAndCCB.TabIndex = 1;
            TAndCCB.Text = "You agree to the T&C";
            TAndCCB.UseMnemonic = false;
            TAndCCB.UseVisualStyleBackColor = true;
            // 
            // TwoFACB
            // 
            TwoFACB.AutoSize = true;
            TwoFACB.Cursor = Cursors.Hand;
            TwoFACB.Location = new Point(11, 42);
            TwoFACB.Name = "TwoFACB";
            TwoFACB.Size = new Size(194, 27);
            TwoFACB.TabIndex = 0;
            TwoFACB.Text = "2-Factor Authentication";
            TwoFACB.UseVisualStyleBackColor = true;
            // 
            // CreatePasswordGB
            // 
            CreatePasswordGB.Controls.Add(label14);
            CreatePasswordGB.Controls.Add(label13);
            CreatePasswordGB.Controls.Add(label12);
            CreatePasswordGB.Controls.Add(label11);
            CreatePasswordGB.Controls.Add(label9);
            CreatePasswordGB.Controls.Add(CreatePasswordTB);
            CreatePasswordGB.Controls.Add(label8);
            CreatePasswordGB.Font = new Font("Segoe Print", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CreatePasswordGB.Location = new Point(9, 327);
            CreatePasswordGB.Name = "CreatePasswordGB";
            CreatePasswordGB.Size = new Size(298, 219);
            CreatePasswordGB.TabIndex = 11;
            CreatePasswordGB.TabStop = false;
            CreatePasswordGB.Text = "Create Username";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe Print", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(14, 89);
            label14.Name = "label14";
            label14.Size = new Size(91, 21);
            label14.TabIndex = 13;
            label14.Text = "Requirements";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(12, 190);
            label13.Name = "label13";
            label13.Size = new Size(194, 21);
            label13.TabIndex = 12;
            label13.Text = "- Be at least 8 character long";
            label13.Click += label13_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(12, 169);
            label12.Name = "label12";
            label12.Size = new Size(271, 21);
            label12.TabIndex = 11;
            label12.Text = "- Contain at least one numerical character";
            label12.Click += label12_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(12, 149);
            label11.Name = "label11";
            label11.Size = new Size(251, 21);
            label11.TabIndex = 10;
            label11.Text = "- Contain at least one special character";
            label11.Click += label11_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(13, 110);
            label9.Name = "label9";
            label9.Size = new Size(221, 42);
            label9.TabIndex = 8;
            label9.Text = "- Contain at least one Upper and \r\nLower character";
            // 
            // CreatePasswordTB
            // 
            CreatePasswordTB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CreatePasswordTB.Location = new Point(60, 54);
            CreatePasswordTB.MaxLength = 50;
            CreatePasswordTB.Name = "CreatePasswordTB";
            CreatePasswordTB.Size = new Size(169, 29);
            CreatePasswordTB.TabIndex = 7;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(60, 30);
            label8.Name = "label8";
            label8.Size = new Size(67, 21);
            label8.TabIndex = 6;
            label8.Text = "Password";
            // 
            // CreateAccountGB
            // 
            CreateAccountGB.Controls.Add(label7);
            CreateAccountGB.Controls.Add(WarningUsernameLB);
            CreateAccountGB.Controls.Add(CreateUsernameTB);
            CreateAccountGB.Controls.Add(label10);
            CreateAccountGB.Font = new Font("Segoe Print", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CreateAccountGB.Location = new Point(9, 188);
            CreateAccountGB.Name = "CreateAccountGB";
            CreateAccountGB.Size = new Size(511, 138);
            CreateAccountGB.TabIndex = 10;
            CreateAccountGB.TabStop = false;
            CreateAccountGB.Text = "Create Username";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(147, 103);
            label7.Name = "label7";
            label7.Size = new Size(214, 21);
            label7.TabIndex = 7;
            label7.Text = "Please create an unique Username";
            // 
            // WarningUsernameLB
            // 
            WarningUsernameLB.AutoSize = true;
            WarningUsernameLB.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            WarningUsernameLB.ForeColor = Color.DarkRed;
            WarningUsernameLB.Location = new Point(189, 82);
            WarningUsernameLB.Name = "WarningUsernameLB";
            WarningUsernameLB.Size = new Size(121, 21);
            WarningUsernameLB.TabIndex = 6;
            WarningUsernameLB.Text = "Username is taken";
            WarningUsernameLB.Visible = false;
            // 
            // CreateUsernameTB
            // 
            CreateUsernameTB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CreateUsernameTB.Location = new Point(171, 49);
            CreateUsernameTB.MaxLength = 20;
            CreateUsernameTB.Name = "CreateUsernameTB";
            CreateUsernameTB.Size = new Size(169, 29);
            CreateUsernameTB.TabIndex = 5;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(171, 25);
            label10.Name = "label10";
            label10.Size = new Size(69, 21);
            label10.TabIndex = 1;
            label10.Text = "Username";
            // 
            // YourDetailsGB
            // 
            YourDetailsGB.Controls.Add(EmailWarningLB);
            YourDetailsGB.Controls.Add(label5);
            YourDetailsGB.Controls.Add(AREmailaddressTB);
            YourDetailsGB.Controls.Add(ARHomeaddressTB);
            YourDetailsGB.Controls.Add(ARLastName);
            YourDetailsGB.Controls.Add(ARFirstnameTB);
            YourDetailsGB.Controls.Add(label6);
            YourDetailsGB.Controls.Add(label4);
            YourDetailsGB.Controls.Add(label3);
            YourDetailsGB.Font = new Font("Segoe Print", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            YourDetailsGB.Location = new Point(9, 6);
            YourDetailsGB.Name = "YourDetailsGB";
            YourDetailsGB.Size = new Size(511, 181);
            YourDetailsGB.TabIndex = 0;
            YourDetailsGB.TabStop = false;
            YourDetailsGB.Text = "Your Details";
            // 
            // EmailWarningLB
            // 
            EmailWarningLB.AutoSize = true;
            EmailWarningLB.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            EmailWarningLB.ForeColor = Color.DarkRed;
            EmailWarningLB.Location = new Point(304, 154);
            EmailWarningLB.Name = "EmailWarningLB";
            EmailWarningLB.Size = new Size(144, 21);
            EmailWarningLB.TabIndex = 11;
            EmailWarningLB.Text = "Email is already in use";
            EmailWarningLB.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(287, 31);
            label5.Name = "label5";
            label5.Size = new Size(95, 21);
            label5.TabIndex = 10;
            label5.Text = "Home address";
            // 
            // AREmailaddressTB
            // 
            AREmailaddressTB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AREmailaddressTB.Location = new Point(287, 122);
            AREmailaddressTB.MaxLength = 100;
            AREmailaddressTB.Name = "AREmailaddressTB";
            AREmailaddressTB.Size = new Size(169, 29);
            AREmailaddressTB.TabIndex = 9;
            // 
            // ARHomeaddressTB
            // 
            ARHomeaddressTB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ARHomeaddressTB.Location = new Point(287, 55);
            ARHomeaddressTB.MaxLength = 100;
            ARHomeaddressTB.Name = "ARHomeaddressTB";
            ARHomeaddressTB.Size = new Size(169, 29);
            ARHomeaddressTB.TabIndex = 8;
            // 
            // ARLastName
            // 
            ARLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ARLastName.Location = new Point(31, 122);
            ARLastName.MaxLength = 100;
            ARLastName.Name = "ARLastName";
            ARLastName.Size = new Size(169, 29);
            ARLastName.TabIndex = 6;
            // 
            // ARFirstnameTB
            // 
            ARFirstnameTB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ARFirstnameTB.Location = new Point(31, 55);
            ARFirstnameTB.MaxLength = 50;
            ARFirstnameTB.Name = "ARFirstnameTB";
            ARFirstnameTB.Size = new Size(169, 29);
            ARFirstnameTB.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(287, 98);
            label6.Name = "label6";
            label6.Size = new Size(95, 21);
            label6.TabIndex = 4;
            label6.Text = "Email Address";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(31, 98);
            label4.Name = "label4";
            label4.Size = new Size(74, 21);
            label4.TabIndex = 2;
            label4.Text = "Last name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(31, 31);
            label3.Name = "label3";
            label3.Size = new Size(75, 21);
            label3.TabIndex = 1;
            label3.Text = "First name";
            // 
            // ForgotPasswordPanel
            // 
            ForgotPasswordPanel.BackColor = Color.Transparent;
            ForgotPasswordPanel.BackgroundImageLayout = ImageLayout.Stretch;
            ForgotPasswordPanel.Controls.Add(FPSignUpAccountLabel);
            ForgotPasswordPanel.Controls.Add(FPBackToLoginLB);
            ForgotPasswordPanel.Controls.Add(panel1);
            ForgotPasswordPanel.Controls.Add(FPEnterEmailPanel);
            ForgotPasswordPanel.Location = new Point(559, 30);
            ForgotPasswordPanel.Name = "ForgotPasswordPanel";
            ForgotPasswordPanel.Size = new Size(447, 533);
            ForgotPasswordPanel.TabIndex = 3;
            ForgotPasswordPanel.Visible = false;
            // 
            // FPSignUpAccountLabel
            // 
            FPSignUpAccountLabel.AutoSize = true;
            FPSignUpAccountLabel.Cursor = Cursors.Hand;
            FPSignUpAccountLabel.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FPSignUpAccountLabel.ForeColor = Color.Purple;
            FPSignUpAccountLabel.Location = new Point(233, 509);
            FPSignUpAccountLabel.Name = "FPSignUpAccountLabel";
            FPSignUpAccountLabel.Size = new Size(209, 21);
            FPSignUpAccountLabel.TabIndex = 16;
            FPSignUpAccountLabel.Text = "Don't have an account? Sign up!";
            FPSignUpAccountLabel.Click += FPSignUpAccountLabel_Click;
            // 
            // FPBackToLoginLB
            // 
            FPBackToLoginLB.AutoSize = true;
            FPBackToLoginLB.Cursor = Cursors.Hand;
            FPBackToLoginLB.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FPBackToLoginLB.ForeColor = Color.Purple;
            FPBackToLoginLB.Location = new Point(15, 509);
            FPBackToLoginLB.Name = "FPBackToLoginLB";
            FPBackToLoginLB.Size = new Size(116, 21);
            FPBackToLoginLB.TabIndex = 15;
            FPBackToLoginLB.Text = "Go Back to Login";
            FPBackToLoginLB.Click += FPBackToLoginLB_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(label17);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(FPConfirmBTN);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(FPTokenTB);
            panel1.Location = new Point(7, 266);
            panel1.Name = "panel1";
            panel1.Size = new Size(437, 232);
            panel1.TabIndex = 14;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(78, 119);
            label17.Name = "label17";
            label17.Size = new Size(276, 63);
            label17.TabIndex = 12;
            label17.Text = "Once confirmed that this account is your's\r\nyou will be redirected to a page where you \r\ncan reset your password\r\n";
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(39, 128);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(29, 34);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // FPConfirmBTN
            // 
            FPConfirmBTN.BackColor = Color.Transparent;
            FPConfirmBTN.BackgroundImage = (Image)resources.GetObject("FPConfirmBTN.BackgroundImage");
            FPConfirmBTN.BackgroundImageLayout = ImageLayout.Stretch;
            FPConfirmBTN.Cursor = Cursors.Hand;
            FPConfirmBTN.FlatAppearance.BorderSize = 0;
            FPConfirmBTN.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 0);
            FPConfirmBTN.FlatAppearance.MouseOverBackColor = Color.Olive;
            FPConfirmBTN.FlatStyle = FlatStyle.Flat;
            FPConfirmBTN.Font = new Font("Segoe Print", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            FPConfirmBTN.Location = new Point(248, 56);
            FPConfirmBTN.Name = "FPConfirmBTN";
            FPConfirmBTN.Size = new Size(165, 33);
            FPConfirmBTN.TabIndex = 10;
            FPConfirmBTN.Text = "Confirm";
            FPConfirmBTN.UseVisualStyleBackColor = false;
            FPConfirmBTN.Click += FPConfirmBTN_Click;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label18.Location = new Point(41, 27);
            label18.Name = "label18";
            label18.Size = new Size(111, 28);
            label18.TabIndex = 6;
            label18.Text = "Enter Token";
            // 
            // FPTokenTB
            // 
            FPTokenTB.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            FPTokenTB.Location = new Point(41, 56);
            FPTokenTB.MaxLength = 9;
            FPTokenTB.Name = "FPTokenTB";
            FPTokenTB.Size = new Size(182, 33);
            FPTokenTB.TabIndex = 5;
            // 
            // FPEnterEmailPanel
            // 
            FPEnterEmailPanel.BackColor = Color.Transparent;
            FPEnterEmailPanel.BackgroundImage = (Image)resources.GetObject("FPEnterEmailPanel.BackgroundImage");
            FPEnterEmailPanel.BackgroundImageLayout = ImageLayout.Stretch;
            FPEnterEmailPanel.Controls.Add(FPEmailSentPB);
            FPEnterEmailPanel.Controls.Add(label16);
            FPEnterEmailPanel.Controls.Add(pictureBox1);
            FPEnterEmailPanel.Controls.Add(FPSendCodeBTN);
            FPEnterEmailPanel.Controls.Add(label15);
            FPEnterEmailPanel.Controls.Add(FPEmailTB);
            FPEnterEmailPanel.Location = new Point(7, 6);
            FPEnterEmailPanel.Name = "FPEnterEmailPanel";
            FPEnterEmailPanel.Size = new Size(437, 232);
            FPEnterEmailPanel.TabIndex = 2;
            // 
            // FPEmailSentPB
            // 
            FPEmailSentPB.BackgroundImage = (Image)resources.GetObject("FPEmailSentPB.BackgroundImage");
            FPEmailSentPB.BackgroundImageLayout = ImageLayout.Stretch;
            FPEmailSentPB.Location = new Point(136, 12);
            FPEmailSentPB.Name = "FPEmailSentPB";
            FPEmailSentPB.Size = new Size(156, 40);
            FPEmailSentPB.TabIndex = 13;
            FPEmailSentPB.TabStop = false;
            FPEmailSentPB.Visible = false;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(78, 134);
            label16.Name = "label16";
            label16.Size = new Size(316, 63);
            label16.TabIndex = 12;
            label16.Text = "A token will be sent out to your Email after\r\nclicking 'Send code'. Please enter this token below \r\nto reset your password\r\n";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(39, 143);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(29, 34);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // FPSendCodeBTN
            // 
            FPSendCodeBTN.BackColor = Color.Transparent;
            FPSendCodeBTN.BackgroundImage = (Image)resources.GetObject("FPSendCodeBTN.BackgroundImage");
            FPSendCodeBTN.BackgroundImageLayout = ImageLayout.Stretch;
            FPSendCodeBTN.Cursor = Cursors.Hand;
            FPSendCodeBTN.FlatAppearance.BorderSize = 0;
            FPSendCodeBTN.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 0);
            FPSendCodeBTN.FlatAppearance.MouseOverBackColor = Color.Olive;
            FPSendCodeBTN.FlatStyle = FlatStyle.Flat;
            FPSendCodeBTN.Font = new Font("Segoe Print", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            FPSendCodeBTN.Location = new Point(248, 86);
            FPSendCodeBTN.Name = "FPSendCodeBTN";
            FPSendCodeBTN.Size = new Size(165, 33);
            FPSendCodeBTN.TabIndex = 10;
            FPSendCodeBTN.Text = "Send code";
            FPSendCodeBTN.UseVisualStyleBackColor = false;
            FPSendCodeBTN.Click += FPSendCodeBTN_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(41, 57);
            label15.Name = "label15";
            label15.Size = new Size(106, 28);
            label15.TabIndex = 6;
            label15.Text = "Enter email";
            // 
            // FPEmailTB
            // 
            FPEmailTB.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            FPEmailTB.Location = new Point(41, 86);
            FPEmailTB.MaxLength = 100;
            FPEmailTB.Name = "FPEmailTB";
            FPEmailTB.Size = new Size(182, 33);
            FPEmailTB.TabIndex = 5;
            // 
            // ResetPasswordPanel
            // 
            ResetPasswordPanel.BackColor = Color.Transparent;
            ResetPasswordPanel.BackgroundImage = (Image)resources.GetObject("ResetPasswordPanel.BackgroundImage");
            ResetPasswordPanel.BackgroundImageLayout = ImageLayout.Stretch;
            ResetPasswordPanel.Controls.Add(BackToLoginFromPR);
            ResetPasswordPanel.Controls.Add(label19);
            ResetPasswordPanel.Controls.Add(label20);
            ResetPasswordPanel.Controls.Add(label21);
            ResetPasswordPanel.Controls.Add(label23);
            ResetPasswordPanel.Controls.Add(label24);
            ResetPasswordPanel.Controls.Add(ChangingPasswordBTN);
            ResetPasswordPanel.Controls.Add(PRnewUserPasswordTB);
            ResetPasswordPanel.Controls.Add(label22);
            ResetPasswordPanel.Location = new Point(559, 601);
            ResetPasswordPanel.Name = "ResetPasswordPanel";
            ResetPasswordPanel.Size = new Size(414, 309);
            ResetPasswordPanel.TabIndex = 4;
            // 
            // BackToLoginFromPR
            // 
            BackToLoginFromPR.AutoSize = true;
            BackToLoginFromPR.Cursor = Cursors.Hand;
            BackToLoginFromPR.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            BackToLoginFromPR.ForeColor = Color.FromArgb(192, 0, 192);
            BackToLoginFromPR.Location = new Point(137, 278);
            BackToLoginFromPR.Name = "BackToLoginFromPR";
            BackToLoginFromPR.Size = new Size(142, 21);
            BackToLoginFromPR.TabIndex = 19;
            BackToLoginFromPR.Text = "Go back to login page";
            BackToLoginFromPR.Click += BackToLoginFromPR_Click;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe Print", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label19.ForeColor = Color.Black;
            label19.Location = new Point(64, 85);
            label19.Name = "label19";
            label19.Size = new Size(91, 21);
            label19.TabIndex = 18;
            label19.Text = "Requirements";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label20.ForeColor = Color.Black;
            label20.Location = new Point(62, 186);
            label20.Name = "label20";
            label20.Size = new Size(194, 21);
            label20.TabIndex = 17;
            label20.Text = "- Be at least 8 character long";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label21.ForeColor = Color.Black;
            label21.Location = new Point(62, 165);
            label21.Name = "label21";
            label21.Size = new Size(271, 21);
            label21.TabIndex = 16;
            label21.Text = "- Contain at least one numerical character";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label23.ForeColor = Color.Black;
            label23.Location = new Point(62, 145);
            label23.Name = "label23";
            label23.Size = new Size(251, 21);
            label23.TabIndex = 15;
            label23.Text = "- Contain at least one special character";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label24.ForeColor = Color.Black;
            label24.Location = new Point(63, 106);
            label24.Name = "label24";
            label24.Size = new Size(221, 42);
            label24.TabIndex = 14;
            label24.Text = "- Contain at least one Upper and \r\nLower character";
            // 
            // ChangingPasswordBTN
            // 
            ChangingPasswordBTN.BackColor = Color.Transparent;
            ChangingPasswordBTN.BackgroundImage = (Image)resources.GetObject("ChangingPasswordBTN.BackgroundImage");
            ChangingPasswordBTN.BackgroundImageLayout = ImageLayout.Stretch;
            ChangingPasswordBTN.Cursor = Cursors.Hand;
            ChangingPasswordBTN.FlatAppearance.BorderSize = 0;
            ChangingPasswordBTN.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 0);
            ChangingPasswordBTN.FlatAppearance.MouseOverBackColor = Color.Olive;
            ChangingPasswordBTN.FlatStyle = FlatStyle.Flat;
            ChangingPasswordBTN.Font = new Font("Segoe Print", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ChangingPasswordBTN.Location = new Point(127, 225);
            ChangingPasswordBTN.Name = "ChangingPasswordBTN";
            ChangingPasswordBTN.Size = new Size(151, 48);
            ChangingPasswordBTN.TabIndex = 6;
            ChangingPasswordBTN.Text = "Reset Password";
            ChangingPasswordBTN.UseVisualStyleBackColor = false;
            ChangingPasswordBTN.Click += ChangingPasswordBTN_Click;
            // 
            // PRnewUserPasswordTB
            // 
            PRnewUserPasswordTB.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            PRnewUserPasswordTB.Location = new Point(114, 46);
            PRnewUserPasswordTB.Name = "PRnewUserPasswordTB";
            PRnewUserPasswordTB.Size = new Size(182, 33);
            PRnewUserPasswordTB.TabIndex = 4;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label22.Location = new Point(112, 17);
            label22.Name = "label22";
            label22.Size = new Size(184, 28);
            label22.TabIndex = 0;
            label22.Text = "Create new Password";
            // 
            // TwoFAPanel
            // 
            TwoFAPanel.BackColor = Color.Transparent;
            TwoFAPanel.BackgroundImage = (Image)resources.GetObject("TwoFAPanel.BackgroundImage");
            TwoFAPanel.BackgroundImageLayout = ImageLayout.Stretch;
            TwoFAPanel.Controls.Add(BackToLoginFromTwoFALB);
            TwoFAPanel.Controls.Add(label25);
            TwoFAPanel.Controls.Add(EmailSentTwoFAPB);
            TwoFAPanel.Controls.Add(ResendCodeTwoFABTN);
            TwoFAPanel.Controls.Add(ConfirmTwoFABTN);
            TwoFAPanel.Controls.Add(TwoFATokenTB);
            TwoFAPanel.Controls.Add(label28);
            TwoFAPanel.Location = new Point(515, 12);
            TwoFAPanel.Name = "TwoFAPanel";
            TwoFAPanel.Size = new Size(322, 272);
            TwoFAPanel.TabIndex = 5;
            TwoFAPanel.Visible = false;
            // 
            // BackToLoginFromTwoFALB
            // 
            BackToLoginFromTwoFALB.AutoSize = true;
            BackToLoginFromTwoFALB.Cursor = Cursors.Hand;
            BackToLoginFromTwoFALB.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            BackToLoginFromTwoFALB.ForeColor = Color.FromArgb(192, 0, 192);
            BackToLoginFromTwoFALB.Location = new Point(107, 244);
            BackToLoginFromTwoFALB.Name = "BackToLoginFromTwoFALB";
            BackToLoginFromTwoFALB.Size = new Size(127, 21);
            BackToLoginFromTwoFALB.TabIndex = 10;
            BackToLoginFromTwoFALB.Text = "Back to login page!";
            BackToLoginFromTwoFALB.Click += BackToLoginFromTwoFALB_Click;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label25.Location = new Point(39, 136);
            label25.Name = "label25";
            label25.Size = new Size(263, 42);
            label25.TabIndex = 9;
            label25.Text = "Enter in the 9-digit token we have sent \r\nto your email, to confirm it's you.\r\n";
            label25.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EmailSentTwoFAPB
            // 
            EmailSentTwoFAPB.BackgroundImage = (Image)resources.GetObject("EmailSentTwoFAPB.BackgroundImage");
            EmailSentTwoFAPB.BackgroundImageLayout = ImageLayout.Stretch;
            EmailSentTwoFAPB.Location = new Point(58, 10);
            EmailSentTwoFAPB.Name = "EmailSentTwoFAPB";
            EmailSentTwoFAPB.Size = new Size(114, 33);
            EmailSentTwoFAPB.TabIndex = 8;
            EmailSentTwoFAPB.TabStop = false;
            // 
            // ResendCodeTwoFABTN
            // 
            ResendCodeTwoFABTN.BackColor = Color.Transparent;
            ResendCodeTwoFABTN.BackgroundImage = (Image)resources.GetObject("ResendCodeTwoFABTN.BackgroundImage");
            ResendCodeTwoFABTN.BackgroundImageLayout = ImageLayout.Stretch;
            ResendCodeTwoFABTN.Cursor = Cursors.Hand;
            ResendCodeTwoFABTN.FlatAppearance.BorderSize = 0;
            ResendCodeTwoFABTN.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 0);
            ResendCodeTwoFABTN.FlatAppearance.MouseOverBackColor = Color.Olive;
            ResendCodeTwoFABTN.FlatStyle = FlatStyle.Flat;
            ResendCodeTwoFABTN.Font = new Font("Segoe Print", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ResendCodeTwoFABTN.Location = new Point(179, 7);
            ResendCodeTwoFABTN.Name = "ResendCodeTwoFABTN";
            ResendCodeTwoFABTN.Size = new Size(104, 39);
            ResendCodeTwoFABTN.TabIndex = 7;
            ResendCodeTwoFABTN.Text = "Resend";
            ResendCodeTwoFABTN.UseVisualStyleBackColor = false;
            ResendCodeTwoFABTN.Click += ResendCodeTwoFABTN_Click;
            // 
            // ConfirmTwoFABTN
            // 
            ConfirmTwoFABTN.BackColor = Color.Transparent;
            ConfirmTwoFABTN.BackgroundImage = (Image)resources.GetObject("ConfirmTwoFABTN.BackgroundImage");
            ConfirmTwoFABTN.BackgroundImageLayout = ImageLayout.Stretch;
            ConfirmTwoFABTN.Cursor = Cursors.Hand;
            ConfirmTwoFABTN.FlatAppearance.BorderSize = 0;
            ConfirmTwoFABTN.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 0);
            ConfirmTwoFABTN.FlatAppearance.MouseOverBackColor = Color.Olive;
            ConfirmTwoFABTN.FlatStyle = FlatStyle.Flat;
            ConfirmTwoFABTN.Font = new Font("Segoe Print", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ConfirmTwoFABTN.Location = new Point(106, 195);
            ConfirmTwoFABTN.Name = "ConfirmTwoFABTN";
            ConfirmTwoFABTN.Size = new Size(114, 48);
            ConfirmTwoFABTN.TabIndex = 6;
            ConfirmTwoFABTN.Text = "Confirm";
            ConfirmTwoFABTN.UseVisualStyleBackColor = false;
            ConfirmTwoFABTN.Click += ConfirmTwoFABTN_Click;
            // 
            // TwoFATokenTB
            // 
            TwoFATokenTB.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            TwoFATokenTB.Location = new Point(72, 85);
            TwoFATokenTB.MaxLength = 9;
            TwoFATokenTB.Name = "TwoFATokenTB";
            TwoFATokenTB.Size = new Size(182, 33);
            TwoFATokenTB.TabIndex = 4;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label28.Location = new Point(61, 54);
            label28.Name = "label28";
            label28.Size = new Size(209, 28);
            label28.TabIndex = 0;
            label28.Text = "2-Factor Authentication";
            // 
            // button1
            // 
            button1.Location = new Point(92, 63);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += button1_Click_1;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(578, 641);
            Controls.Add(button1);
            Controls.Add(TwoFAPanel);
            Controls.Add(ResetPasswordPanel);
            Controls.Add(ForgotPasswordPanel);
            Controls.Add(AccountRegPanel);
            Controls.Add(LoginPanel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            LoginPanel.ResumeLayout(false);
            LoginPanel.PerformLayout();
            AccountRegPanel.ResumeLayout(false);
            FinalStepsGB.ResumeLayout(false);
            FinalStepsGB.PerformLayout();
            CreatePasswordGB.ResumeLayout(false);
            CreatePasswordGB.PerformLayout();
            CreateAccountGB.ResumeLayout(false);
            CreateAccountGB.PerformLayout();
            YourDetailsGB.ResumeLayout(false);
            YourDetailsGB.PerformLayout();
            ForgotPasswordPanel.ResumeLayout(false);
            ForgotPasswordPanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            FPEnterEmailPanel.ResumeLayout(false);
            FPEnterEmailPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)FPEmailSentPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResetPasswordPanel.ResumeLayout(false);
            ResetPasswordPanel.PerformLayout();
            TwoFAPanel.ResumeLayout(false);
            TwoFAPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)EmailSentTwoFAPB).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel LoginPanel;
        private Button LoginBTN;
        private TextBox LoginPasswordTB;
        private TextBox LoginUsernameTB;
        private Label ForgotPasswordLoginLB;
        private Label SignUpLoginLB;
        private Label label2;
        private Label label1;
        private Panel AccountRegPanel;
        private GroupBox YourDetailsGB;
        private Label label3;
        private TextBox ARLastName;
        private TextBox ARFirstnameTB;
        private Label label6;
        private Label label4;
        private GroupBox CreateAccountGB;
        private TextBox CreateUsernameTB;
        private Label label10;
        private TextBox AREmailaddressTB;
        private TextBox ARHomeaddressTB;
        private GroupBox CreatePasswordGB;
        private TextBox CreatePasswordTB;
        private Label label8;
        private Label label7;
        private Label WarningUsernameLB;
        private Label label9;
        private Label label5;
        private GroupBox FinalStepsGB;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private CheckBox TAndCCB;
        private CheckBox TwoFACB;
        private Label ARBackToLoginLB;
        private Button CreateAccountBTN;
        private LinkLabel viewTandCLinkL;
        private Panel ForgotPasswordPanel;
        private Panel FPEnterEmailPanel;
        private PictureBox pictureBox1;
        private Button FPSendCodeBTN;
        private Label label15;
        private TextBox FPEmailTB;
        private Label label16;
        private Panel panel1;
        private Label label17;
        private PictureBox pictureBox2;
        private Button FPConfirmBTN;
        private Label label18;
        private TextBox FPTokenTB;
        private Label FPSignUpAccountLabel;
        private Label FPBackToLoginLB;
        private Label EmailWarningLB;
        private Panel ResetPasswordPanel;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label23;
        private Label label24;
        private Button ChangingPasswordBTN;
        private TextBox PRnewUserPasswordTB;
        private Label label22;
        private Label BackToLoginFromPR;
        private PictureBox FPEmailSentPB;
        private Panel TwoFAPanel;
        private Button ConfirmTwoFABTN;
        private TextBox TwoFATokenTB;
        private Label label28;
        private Button ResendCodeTwoFABTN;
        private PictureBox EmailSentTwoFAPB;
        private Label label25;
        private Label BackToLoginFromTwoFALB;
        private Button button1;
    }
}