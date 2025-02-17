namespace PassSentinel
{
    partial class AddVaultItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddVaultItemForm));
            errorLabel = new Label();
            addBtn = new Button();
            genPassBtn = new Button();
            viewPassBtn = new Button();
            notesLabel = new Label();
            urlLabel = new Label();
            passwordLabel = new Label();
            usernameLabel = new Label();
            nameLabel = new Label();
            notesTextBox = new TextBox();
            passwordTextBox = new TextBox();
            usernameTextBox = new TextBox();
            urlTextBox = new TextBox();
            nameTextBox = new TextBox();
            cancelBtn = new Button();
            SuspendLayout();
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(12, 389);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(579, 17);
            errorLabel.TabIndex = 27;
            errorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(32, 409);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(92, 25);
            addBtn.TabIndex = 26;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // genPassBtn
            // 
            genPassBtn.Location = new Point(112, 244);
            genPassBtn.Name = "genPassBtn";
            genPassBtn.Size = new Size(75, 23);
            genPassBtn.TabIndex = 25;
            genPassBtn.Text = "Generate";
            genPassBtn.UseVisualStyleBackColor = true;
            genPassBtn.Click += genPassBtn_Click;
            // 
            // viewPassBtn
            // 
            viewPassBtn.Location = new Point(35, 243);
            viewPassBtn.Name = "viewPassBtn";
            viewPassBtn.Size = new Size(71, 24);
            viewPassBtn.TabIndex = 24;
            viewPassBtn.Text = "View";
            viewPassBtn.UseVisualStyleBackColor = true;
            viewPassBtn.Click += viewPassBtn_Click;
            // 
            // notesLabel
            // 
            notesLabel.AutoSize = true;
            notesLabel.Location = new Point(309, 114);
            notesLabel.Name = "notesLabel";
            notesLabel.Size = new Size(41, 15);
            notesLabel.TabIndex = 23;
            notesLabel.Text = "Notes:";
            // 
            // urlLabel
            // 
            urlLabel.AutoSize = true;
            urlLabel.Location = new Point(309, 19);
            urlLabel.Name = "urlLabel";
            urlLabel.Size = new Size(31, 15);
            urlLabel.TabIndex = 22;
            urlLabel.Text = "URL:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(35, 197);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(60, 15);
            passwordLabel.TabIndex = 21;
            passwordLabel.Text = "Password:";
            passwordLabel.UseMnemonic = false;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(32, 114);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(63, 15);
            usernameLabel.TabIndex = 20;
            usernameLabel.Text = "Username:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(36, 20);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(42, 15);
            nameLabel.TabIndex = 19;
            nameLabel.Text = "Name:";
            // 
            // notesTextBox
            // 
            notesTextBox.Location = new Point(309, 134);
            notesTextBox.Multiline = true;
            notesTextBox.Name = "notesTextBox";
            notesTextBox.Size = new Size(258, 252);
            notesTextBox.TabIndex = 18;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(36, 216);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(199, 23);
            passwordTextBox.TabIndex = 17;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(36, 134);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(199, 23);
            usernameTextBox.TabIndex = 16;
            // 
            // urlTextBox
            // 
            urlTextBox.Location = new Point(309, 38);
            urlTextBox.Name = "urlTextBox";
            urlTextBox.Size = new Size(258, 23);
            urlTextBox.TabIndex = 15;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(36, 38);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(199, 23);
            nameTextBox.TabIndex = 14;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(472, 415);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(95, 23);
            cancelBtn.TabIndex = 28;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // AddVaultItemForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(610, 450);
            Controls.Add(cancelBtn);
            Controls.Add(errorLabel);
            Controls.Add(addBtn);
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
            Name = "AddVaultItemForm";
            Text = "New - PassSentinel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label errorLabel;
        private Button addBtn;
        private Button genPassBtn;
        private Button viewPassBtn;
        private Label notesLabel;
        private Label urlLabel;
        private Label passwordLabel;
        private Label usernameLabel;
        private Label nameLabel;
        private TextBox notesTextBox;
        private TextBox passwordTextBox;
        private TextBox usernameTextBox;
        private TextBox urlTextBox;
        private TextBox nameTextBox;
        private Button cancelBtn;
    }
}