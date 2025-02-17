namespace PassSentinel
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            masterPassInput = new TextBox();
            promptLabel = new Label();
            loginBtn = new Button();
            errorLabel = new Label();
            usernameLabel = new Label();
            usernameTextBox = new TextBox();
            createUserLinkLabel = new LinkLabel();
            SuspendLayout();
            // 
            // masterPassInput
            // 
            masterPassInput.Location = new Point(135, 71);
            masterPassInput.Name = "masterPassInput";
            masterPassInput.Size = new Size(228, 23);
            masterPassInput.TabIndex = 1;
            masterPassInput.UseSystemPasswordChar = true;
            masterPassInput.TextChanged += masterPassInput_TextChanged;
            // 
            // promptLabel
            // 
            promptLabel.AutoSize = true;
            promptLabel.Location = new Point(30, 74);
            promptLabel.Name = "promptLabel";
            promptLabel.Size = new Size(99, 15);
            promptLabel.TabIndex = 5;
            promptLabel.Text = "Master Password:";
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(209, 123);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(75, 23);
            loginBtn.TabIndex = 2;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.ImageAlign = ContentAlignment.TopLeft;
            errorLabel.Location = new Point(30, 97);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(429, 23);
            errorLabel.TabIndex = 3;
            errorLabel.TextAlign = ContentAlignment.MiddleCenter;
            errorLabel.Click += errorLabel_Click;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(66, 38);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(63, 15);
            usernameLabel.TabIndex = 4;
            usernameLabel.Text = "Username:";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(135, 35);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(228, 23);
            usernameTextBox.TabIndex = 0;
            usernameTextBox.TextChanged += usernameTextBox_TextChanged;
            // 
            // createUserLinkLabel
            // 
            createUserLinkLabel.AutoSize = true;
            createUserLinkLabel.Location = new Point(12, 131);
            createUserLinkLabel.Name = "createUserLinkLabel";
            createUserLinkLabel.Size = new Size(94, 15);
            createUserLinkLabel.TabIndex = 3;
            createUserLinkLabel.TabStop = true;
            createUserLinkLabel.Text = "Create New User";
            createUserLinkLabel.LinkClicked += createUserLinkLabel_LinkClicked;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 159);
            Controls.Add(createUserLinkLabel);
            Controls.Add(usernameTextBox);
            Controls.Add(usernameLabel);
            Controls.Add(errorLabel);
            Controls.Add(loginBtn);
            Controls.Add(promptLabel);
            Controls.Add(masterPassInput);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            Text = "Login - PassSentinel";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox masterPassInput;
        private Label promptLabel;
        private Button loginBtn;
        private Label errorLabel;
        private Label usernameLabel;
        private TextBox usernameTextBox;
        private LinkLabel createUserLinkLabel;
    }
}