namespace PassSentinel
{
    partial class LockScreenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LockScreenForm));
            usernameTextBox = new TextBox();
            usernameLabel = new Label();
            errorLabel = new Label();
            unlockBtn = new Button();
            promptLabel = new Label();
            masterPassInput = new TextBox();
            logoutBtn = new Button();
            SuspendLayout();
            // 
            // usernameTextBox
            // 
            usernameTextBox.BackColor = SystemColors.ControlLight;
            usernameTextBox.Location = new Point(124, 31);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.ReadOnly = true;
            usernameTextBox.Size = new Size(228, 23);
            usernameTextBox.TabIndex = 6;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(55, 34);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(63, 15);
            usernameLabel.TabIndex = 11;
            usernameLabel.Text = "Username:";
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.ImageAlign = ContentAlignment.TopLeft;
            errorLabel.Location = new Point(19, 93);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(429, 23);
            errorLabel.TabIndex = 10;
            errorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // unlockBtn
            // 
            unlockBtn.Location = new Point(198, 119);
            unlockBtn.Name = "unlockBtn";
            unlockBtn.Size = new Size(75, 23);
            unlockBtn.TabIndex = 1;
            unlockBtn.Text = "Unlock";
            unlockBtn.UseVisualStyleBackColor = true;
            unlockBtn.Click += unlockBtn_Click;
            // 
            // promptLabel
            // 
            promptLabel.AutoSize = true;
            promptLabel.Location = new Point(19, 70);
            promptLabel.Name = "promptLabel";
            promptLabel.Size = new Size(99, 15);
            promptLabel.TabIndex = 12;
            promptLabel.Text = "Master Password:";
            // 
            // masterPassInput
            // 
            masterPassInput.Location = new Point(124, 67);
            masterPassInput.Name = "masterPassInput";
            masterPassInput.Size = new Size(228, 23);
            masterPassInput.TabIndex = 0;
            masterPassInput.UseSystemPasswordChar = true;
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(12, 119);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(75, 23);
            logoutBtn.TabIndex = 2;
            logoutBtn.Text = "Logout";
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // LockScreenForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(466, 147);
            Controls.Add(logoutBtn);
            Controls.Add(usernameTextBox);
            Controls.Add(usernameLabel);
            Controls.Add(errorLabel);
            Controls.Add(unlockBtn);
            Controls.Add(promptLabel);
            Controls.Add(masterPassInput);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LockScreenForm";
            Text = "Locked - PassSentinel";
            Load += LockScreenForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usernameTextBox;
        private Label usernameLabel;
        private Label errorLabel;
        private Button unlockBtn;
        private Label promptLabel;
        private TextBox masterPassInput;
        private Button logoutBtn;
    }
}