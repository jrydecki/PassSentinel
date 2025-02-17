namespace PassSentinel
{
    partial class CreateUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateUserForm));
            masterPassInput1 = new TextBox();
            masterPassInput2 = new TextBox();
            masterPassLabel1 = new Label();
            masterPassLabel2 = new Label();
            errorLabel = new Label();
            createUserBtn = new Button();
            usernameLabel = new Label();
            usernameTextBox = new TextBox();
            cancelBtn = new Button();
            SuspendLayout();
            // 
            // masterPassInput1
            // 
            masterPassInput1.Location = new Point(185, 51);
            masterPassInput1.Name = "masterPassInput1";
            masterPassInput1.Size = new Size(217, 23);
            masterPassInput1.TabIndex = 1;
            masterPassInput1.UseSystemPasswordChar = true;
            masterPassInput1.TextChanged += masterPassInput1_TextChanged;
            // 
            // masterPassInput2
            // 
            masterPassInput2.Location = new Point(185, 80);
            masterPassInput2.Name = "masterPassInput2";
            masterPassInput2.Size = new Size(217, 23);
            masterPassInput2.TabIndex = 2;
            masterPassInput2.UseSystemPasswordChar = true;
            masterPassInput2.TextChanged += masterPassInput2_TextChanged;
            // 
            // masterPassLabel1
            // 
            masterPassLabel1.AutoSize = true;
            masterPassLabel1.Location = new Point(34, 54);
            masterPassLabel1.Name = "masterPassLabel1";
            masterPassLabel1.Size = new Size(145, 15);
            masterPassLabel1.TabIndex = 2;
            masterPassLabel1.Text = "Create a Master Password:";
            // 
            // masterPassLabel2
            // 
            masterPassLabel2.AutoSize = true;
            masterPassLabel2.Location = new Point(71, 88);
            masterPassLabel2.Name = "masterPassLabel2";
            masterPassLabel2.Size = new Size(108, 15);
            masterPassLabel2.TabIndex = 3;
            masterPassLabel2.Text = "Re-enter Password:";
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(34, 115);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(368, 20);
            errorLabel.TabIndex = 4;
            errorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // createUserBtn
            // 
            createUserBtn.Location = new Point(34, 149);
            createUserBtn.Name = "createUserBtn";
            createUserBtn.Size = new Size(75, 23);
            createUserBtn.TabIndex = 3;
            createUserBtn.Text = "Submit";
            createUserBtn.UseVisualStyleBackColor = true;
            createUserBtn.Click += createUserBtn_Click;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(79, 24);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(100, 15);
            usernameLabel.TabIndex = 6;
            usernameLabel.Text = "Create Username:";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(185, 22);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(217, 23);
            usernameTextBox.TabIndex = 0;
            usernameTextBox.TextChanged += usernameTextBox_TextChanged;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(327, 149);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(75, 23);
            cancelBtn.TabIndex = 4;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // CreateUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 196);
            Controls.Add(cancelBtn);
            Controls.Add(usernameTextBox);
            Controls.Add(usernameLabel);
            Controls.Add(createUserBtn);
            Controls.Add(errorLabel);
            Controls.Add(masterPassLabel2);
            Controls.Add(masterPassLabel1);
            Controls.Add(masterPassInput2);
            Controls.Add(masterPassInput1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateUserForm";
            Text = "Create New User - PassSentinel";
            Load += CreateUser_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox masterPassInput1;
        private TextBox masterPassInput2;
        private Label masterPassLabel1;
        private Label masterPassLabel2;
        private Label errorLabel;
        private Button createUserBtn;
        private Label usernameLabel;
        private TextBox usernameTextBox;
        private Button cancelBtn;
    }
}