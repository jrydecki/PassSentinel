namespace PassSentinel
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            updateBtn = new Button();
            changePassLabel = new Label();
            changePassBtn = new Button();
            deleteVaultBtn = new Button();
            deleteVaultLabel = new Label();
            errorLabel = new Label();
            cancelBtn = new Button();
            deleteUserLabel = new Label();
            deleteUserBtn = new Button();
            preferencesLabel = new Label();
            preferencesBtn = new Button();
            exportLabel = new Label();
            exportBtn = new Button();
            exportSaveFileDialog = new SaveFileDialog();
            logoutBtn = new Button();
            SuspendLayout();
            // 
            // updateBtn
            // 
            updateBtn.Location = new Point(23, 360);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(75, 23);
            updateBtn.TabIndex = 4;
            updateBtn.Text = "OK";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // changePassLabel
            // 
            changePassLabel.AutoSize = true;
            changePassLabel.Location = new Point(23, 74);
            changePassLabel.Name = "changePassLabel";
            changePassLabel.Size = new Size(135, 15);
            changePassLabel.TabIndex = 3;
            changePassLabel.Text = "Change Master Pasword";
            // 
            // changePassBtn
            // 
            changePassBtn.Location = new Point(209, 70);
            changePassBtn.Name = "changePassBtn";
            changePassBtn.Size = new Size(75, 23);
            changePassBtn.TabIndex = 1;
            changePassBtn.Text = "Change...";
            changePassBtn.UseVisualStyleBackColor = true;
            changePassBtn.Click += changePassBtn_Click;
            // 
            // deleteVaultBtn
            // 
            deleteVaultBtn.Location = new Point(209, 122);
            deleteVaultBtn.Name = "deleteVaultBtn";
            deleteVaultBtn.Size = new Size(75, 23);
            deleteVaultBtn.TabIndex = 2;
            deleteVaultBtn.Text = "Delete";
            deleteVaultBtn.UseVisualStyleBackColor = true;
            deleteVaultBtn.Click += deleteVaultBtn_Click;
            // 
            // deleteVaultLabel
            // 
            deleteVaultLabel.AutoSize = true;
            deleteVaultLabel.Location = new Point(23, 126);
            deleteVaultLabel.Name = "deleteVaultLabel";
            deleteVaultLabel.Size = new Size(147, 15);
            deleteVaultLabel.TabIndex = 6;
            deleteVaultLabel.Text = "Delete All Items from Vault";
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(6, 334);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(309, 23);
            errorLabel.TabIndex = 7;
            errorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(209, 360);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(75, 23);
            cancelBtn.TabIndex = 5;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // deleteUserLabel
            // 
            deleteUserLabel.AutoSize = true;
            deleteUserLabel.Location = new Point(23, 180);
            deleteUserLabel.Name = "deleteUserLabel";
            deleteUserLabel.Size = new Size(66, 15);
            deleteUserLabel.TabIndex = 9;
            deleteUserLabel.Text = "Delete User";
            // 
            // deleteUserBtn
            // 
            deleteUserBtn.Location = new Point(209, 176);
            deleteUserBtn.Name = "deleteUserBtn";
            deleteUserBtn.Size = new Size(75, 23);
            deleteUserBtn.TabIndex = 3;
            deleteUserBtn.Text = "Delete";
            deleteUserBtn.UseVisualStyleBackColor = true;
            deleteUserBtn.Click += deleteUserBtn_Click;
            // 
            // preferencesLabel
            // 
            preferencesLabel.AutoSize = true;
            preferencesLabel.Location = new Point(23, 25);
            preferencesLabel.Name = "preferencesLabel";
            preferencesLabel.Size = new Size(68, 15);
            preferencesLabel.TabIndex = 10;
            preferencesLabel.Text = "Preferences";
            // 
            // preferencesBtn
            // 
            preferencesBtn.Location = new Point(209, 21);
            preferencesBtn.Name = "preferencesBtn";
            preferencesBtn.Size = new Size(75, 23);
            preferencesBtn.TabIndex = 0;
            preferencesBtn.Text = "Edit...";
            preferencesBtn.UseVisualStyleBackColor = true;
            preferencesBtn.Click += preferencesBtn_Click;
            // 
            // exportLabel
            // 
            exportLabel.AutoSize = true;
            exportLabel.Location = new Point(23, 233);
            exportLabel.Name = "exportLabel";
            exportLabel.Size = new Size(99, 15);
            exportLabel.TabIndex = 11;
            exportLabel.Text = "Export Passwords";
            exportLabel.Click += exportLabel_Click;
            // 
            // exportBtn
            // 
            exportBtn.Location = new Point(209, 229);
            exportBtn.Name = "exportBtn";
            exportBtn.Size = new Size(75, 23);
            exportBtn.TabIndex = 12;
            exportBtn.Text = "Export";
            exportBtn.UseVisualStyleBackColor = true;
            exportBtn.Click += exportBtn_Click;
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(118, 308);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(75, 23);
            logoutBtn.TabIndex = 15;
            logoutBtn.Text = "Logout";
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(316, 395);
            Controls.Add(logoutBtn);
            Controls.Add(exportBtn);
            Controls.Add(exportLabel);
            Controls.Add(preferencesBtn);
            Controls.Add(preferencesLabel);
            Controls.Add(deleteUserBtn);
            Controls.Add(deleteUserLabel);
            Controls.Add(cancelBtn);
            Controls.Add(errorLabel);
            Controls.Add(deleteVaultLabel);
            Controls.Add(deleteVaultBtn);
            Controls.Add(changePassBtn);
            Controls.Add(changePassLabel);
            Controls.Add(updateBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsForm";
            Text = "Settings - PassSentinel";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button updateBtn;
        private Label changePassLabel;
        private Button changePassBtn;
        private Button deleteVaultBtn;
        private Label deleteVaultLabel;
        private Label errorLabel;
        private Button cancelBtn;
        private Label deleteUserLabel;
        private Button deleteUserBtn;
        private Label preferencesLabel;
        private Button preferencesBtn;
        private Label exportLabel;
        private Button exportBtn;
        private SaveFileDialog exportSaveFileDialog;
        private Button logoutBtn;
    }
}