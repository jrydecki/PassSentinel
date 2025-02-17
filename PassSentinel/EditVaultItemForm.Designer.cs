namespace PassSentinel
{
    partial class EditVaultItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditVaultItemForm));
            nameTextBox = new TextBox();
            urlTextBox = new TextBox();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            notesTextBox = new TextBox();
            nameLabel = new Label();
            usernameLabel = new Label();
            passwordLabel = new Label();
            urlLabel = new Label();
            notesLabel = new Label();
            viewPassBtn = new Button();
            genPassBtn = new Button();
            updateBtn = new Button();
            errorLabel = new Label();
            cancelBtn = new Button();
            copyBtn = new Button();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(36, 41);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(199, 23);
            nameTextBox.TabIndex = 0;
            // 
            // urlTextBox
            // 
            urlTextBox.Location = new Point(309, 41);
            urlTextBox.Name = "urlTextBox";
            urlTextBox.Size = new Size(258, 23);
            urlTextBox.TabIndex = 1;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(36, 137);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(199, 23);
            usernameTextBox.TabIndex = 2;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(36, 219);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(199, 23);
            passwordTextBox.TabIndex = 3;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // notesTextBox
            // 
            notesTextBox.Location = new Point(309, 137);
            notesTextBox.Multiline = true;
            notesTextBox.Name = "notesTextBox";
            notesTextBox.Size = new Size(258, 252);
            notesTextBox.TabIndex = 4;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(36, 23);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(42, 15);
            nameLabel.TabIndex = 5;
            nameLabel.Text = "Name:";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(32, 117);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(63, 15);
            usernameLabel.TabIndex = 6;
            usernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(35, 200);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(60, 15);
            passwordLabel.TabIndex = 7;
            passwordLabel.Text = "Password:";
            passwordLabel.UseMnemonic = false;
            // 
            // urlLabel
            // 
            urlLabel.AutoSize = true;
            urlLabel.Location = new Point(309, 22);
            urlLabel.Name = "urlLabel";
            urlLabel.Size = new Size(31, 15);
            urlLabel.TabIndex = 8;
            urlLabel.Text = "URL:";
            // 
            // notesLabel
            // 
            notesLabel.AutoSize = true;
            notesLabel.Location = new Point(309, 117);
            notesLabel.Name = "notesLabel";
            notesLabel.Size = new Size(41, 15);
            notesLabel.TabIndex = 9;
            notesLabel.Text = "Notes:";
            // 
            // viewPassBtn
            // 
            viewPassBtn.Location = new Point(35, 246);
            viewPassBtn.Name = "viewPassBtn";
            viewPassBtn.Size = new Size(54, 24);
            viewPassBtn.TabIndex = 10;
            viewPassBtn.Text = "View";
            viewPassBtn.UseVisualStyleBackColor = true;
            viewPassBtn.Click += viewPassBtn_Click;
            // 
            // genPassBtn
            // 
            genPassBtn.Location = new Point(160, 246);
            genPassBtn.Name = "genPassBtn";
            genPassBtn.Size = new Size(75, 23);
            genPassBtn.TabIndex = 11;
            genPassBtn.Text = "Generate";
            genPassBtn.UseVisualStyleBackColor = true;
            genPassBtn.Click += genPassBtn_Click;
            // 
            // updateBtn
            // 
            updateBtn.Location = new Point(32, 412);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(92, 25);
            updateBtn.TabIndex = 12;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(12, 392);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(579, 17);
            errorLabel.TabIndex = 13;
            errorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(477, 412);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(90, 23);
            cancelBtn.TabIndex = 14;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // copyBtn
            // 
            copyBtn.Location = new Point(95, 246);
            copyBtn.Name = "copyBtn";
            copyBtn.Size = new Size(59, 23);
            copyBtn.TabIndex = 15;
            copyBtn.Text = "Copy";
            copyBtn.UseVisualStyleBackColor = true;
            copyBtn.Click += copyBtn_Click;
            // 
            // EditVaultItemForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(603, 449);
            Controls.Add(copyBtn);
            Controls.Add(cancelBtn);
            Controls.Add(errorLabel);
            Controls.Add(updateBtn);
            Controls.Add(genPassBtn);
            Controls.Add(viewPassBtn);
            Controls.Add(notesLabel);
            Controls.Add(urlLabel);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(nameLabel);
            Controls.Add(notesTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(urlTextBox);
            Controls.Add(nameTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditVaultItemForm";
            Text = "Edit - PassSentinel";
            Load += EditVaultItemForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private TextBox urlTextBox;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private TextBox notesTextBox;
        private Label nameLabel;
        private Label usernameLabel;
        private Label passwordLabel;
        private Label urlLabel;
        private Label notesLabel;
        private Button viewPassBtn;
        private Button genPassBtn;
        private Button updateBtn;
        private Label errorLabel;
        private Button cancelBtn;
        private Button copyBtn;
    }
}