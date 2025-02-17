namespace PassSentinel
{
    partial class PasswordConfirmPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordConfirmPopup));
            passwordLabel = new Label();
            passwordTextBox = new TextBox();
            deleteBtn = new Button();
            cancelBtn = new Button();
            errorLabel = new Label();
            descriptionLabel = new Label();
            SuspendLayout();
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(44, 61);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(60, 15);
            passwordLabel.TabIndex = 0;
            passwordLabel.Text = "Password:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(110, 58);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(177, 23);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.TextChanged += passwordTextBox_TextChanged;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(44, 108);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(75, 23);
            deleteBtn.TabIndex = 2;
            deleteBtn.Text = "DELETE";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(212, 108);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.RightToLeft = RightToLeft.No;
            cancelBtn.Size = new Size(75, 23);
            cancelBtn.TabIndex = 3;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(44, 84);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(243, 21);
            errorLabel.TabIndex = 4;
            errorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // descriptionLabel
            // 
            descriptionLabel.Location = new Point(2, 29);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(339, 26);
            descriptionLabel.TabIndex = 5;
            descriptionLabel.Text = "Enter master password to DELETE ALL ITEMS";
            descriptionLabel.TextAlign = ContentAlignment.MiddleCenter;
            descriptionLabel.Click += descriptionLabel_Click;
            // 
            // PasswordConfirmPopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(347, 153);
            Controls.Add(descriptionLabel);
            Controls.Add(errorLabel);
            Controls.Add(cancelBtn);
            Controls.Add(deleteBtn);
            Controls.Add(passwordTextBox);
            Controls.Add(passwordLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PasswordConfirmPopup";
            Text = "Confirm - PassSentinel";
            Load += PasswordConfirmPopup_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label passwordLabel;
        private TextBox passwordTextBox;
        private Button deleteBtn;
        private Button cancelBtn;
        private Label errorLabel;
        private Label descriptionLabel;
    }
}