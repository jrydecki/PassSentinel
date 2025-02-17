namespace PassSentinel
{
    partial class ChangeMasterPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeMasterPasswordForm));
            currentPassLabel = new Label();
            newPassLabel1 = new Label();
            newPassLabel2 = new Label();
            currentPassTextBox = new TextBox();
            newPass1TextBox = new TextBox();
            newPass2TextBox = new TextBox();
            cancelBtn = new Button();
            updateBtn = new Button();
            errorLabel = new Label();
            SuspendLayout();
            // 
            // currentPassLabel
            // 
            currentPassLabel.AutoSize = true;
            currentPassLabel.Location = new Point(46, 44);
            currentPassLabel.Name = "currentPassLabel";
            currentPassLabel.Size = new Size(142, 15);
            currentPassLabel.TabIndex = 0;
            currentPassLabel.Text = "Current Master Password:";
            // 
            // newPassLabel1
            // 
            newPassLabel1.AutoSize = true;
            newPassLabel1.Location = new Point(32, 117);
            newPassLabel1.Name = "newPassLabel1";
            newPassLabel1.Size = new Size(156, 15);
            newPassLabel1.TabIndex = 1;
            newPassLabel1.Text = "Enter New Master Password:";
            // 
            // newPassLabel2
            // 
            newPassLabel2.AutoSize = true;
            newPassLabel2.Location = new Point(53, 161);
            newPassLabel2.Name = "newPassLabel2";
            newPassLabel2.Size = new Size(135, 15);
            newPassLabel2.TabIndex = 2;
            newPassLabel2.Text = "Re-enter New Password:";
            // 
            // currentPassTextBox
            // 
            currentPassTextBox.Location = new Point(211, 41);
            currentPassTextBox.Name = "currentPassTextBox";
            currentPassTextBox.Size = new Size(224, 23);
            currentPassTextBox.TabIndex = 3;
            currentPassTextBox.UseSystemPasswordChar = true;
            currentPassTextBox.TextChanged += currentPassTextBox_TextChanged;
            // 
            // newPass1TextBox
            // 
            newPass1TextBox.Location = new Point(211, 114);
            newPass1TextBox.Name = "newPass1TextBox";
            newPass1TextBox.Size = new Size(224, 23);
            newPass1TextBox.TabIndex = 4;
            newPass1TextBox.UseSystemPasswordChar = true;
            newPass1TextBox.TextChanged += newPass1TextBox_TextChanged;
            // 
            // newPass2TextBox
            // 
            newPass2TextBox.Location = new Point(211, 158);
            newPass2TextBox.Name = "newPass2TextBox";
            newPass2TextBox.Size = new Size(224, 23);
            newPass2TextBox.TabIndex = 5;
            newPass2TextBox.UseSystemPasswordChar = true;
            newPass2TextBox.TextChanged += newPass2TextBox_TextChanged;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(360, 243);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(75, 23);
            cancelBtn.TabIndex = 6;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // updateBtn
            // 
            updateBtn.Location = new Point(32, 243);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(75, 23);
            updateBtn.TabIndex = 7;
            updateBtn.Text = "Change";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(12, 222);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(459, 18);
            errorLabel.TabIndex = 8;
            errorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ChangeMasterPasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 285);
            Controls.Add(errorLabel);
            Controls.Add(updateBtn);
            Controls.Add(cancelBtn);
            Controls.Add(newPass2TextBox);
            Controls.Add(newPass1TextBox);
            Controls.Add(currentPassTextBox);
            Controls.Add(newPassLabel2);
            Controls.Add(newPassLabel1);
            Controls.Add(currentPassLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ChangeMasterPasswordForm";
            Text = "Change Password - PassSentinel";
            Load += ChangeMasterPasswordForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label currentPassLabel;
        private Label newPassLabel1;
        private Label newPassLabel2;
        private TextBox currentPassTextBox;
        private TextBox newPass1TextBox;
        private TextBox newPass2TextBox;
        private Button cancelBtn;
        private Button updateBtn;
        private Label errorLabel;
    }
}