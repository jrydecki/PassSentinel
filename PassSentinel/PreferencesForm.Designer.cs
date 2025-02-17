namespace PassSentinel
{
    partial class PreferencesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesForm));
            updateBtn = new Button();
            cancelBtn = new Button();
            errorLabel = new Label();
            searchTab = new TabPage();
            urlCheck = new CheckBox();
            notesCheck = new CheckBox();
            usernameCheck = new CheckBox();
            searchLabel = new Label();
            label1 = new Label();
            passwordTab = new TabPage();
            symbolsCheck = new CheckBox();
            lengthTextBox = new TextBox();
            passwordLengthLabel = new Label();
            tabControl = new TabControl();
            generalTab = new TabPage();
            inactivityComboBox = new ComboBox();
            inactivityLabel = new Label();
            searchTab.SuspendLayout();
            passwordTab.SuspendLayout();
            tabControl.SuspendLayout();
            generalTab.SuspendLayout();
            SuspendLayout();
            // 
            // updateBtn
            // 
            updateBtn.Location = new Point(12, 196);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(75, 23);
            updateBtn.TabIndex = 1;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(284, 196);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(75, 23);
            cancelBtn.TabIndex = 2;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(97, 196);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(181, 23);
            errorLabel.TabIndex = 3;
            errorLabel.TextAlign = ContentAlignment.MiddleCenter;
            errorLabel.Click += errorLabel_Click;
            // 
            // searchTab
            // 
            searchTab.Controls.Add(urlCheck);
            searchTab.Controls.Add(notesCheck);
            searchTab.Controls.Add(usernameCheck);
            searchTab.Controls.Add(searchLabel);
            searchTab.Controls.Add(label1);
            searchTab.Location = new Point(4, 24);
            searchTab.Name = "searchTab";
            searchTab.Padding = new Padding(3);
            searchTab.Size = new Size(343, 150);
            searchTab.TabIndex = 0;
            searchTab.Text = "Search";
            searchTab.UseVisualStyleBackColor = true;
            // 
            // urlCheck
            // 
            urlCheck.AutoSize = true;
            urlCheck.CheckAlign = ContentAlignment.BottomCenter;
            urlCheck.Location = new Point(259, 62);
            urlCheck.Name = "urlCheck";
            urlCheck.Size = new Size(32, 33);
            urlCheck.TabIndex = 7;
            urlCheck.Text = "URL";
            urlCheck.UseVisualStyleBackColor = true;
            // 
            // notesCheck
            // 
            notesCheck.AutoSize = true;
            notesCheck.CheckAlign = ContentAlignment.BottomCenter;
            notesCheck.Location = new Point(149, 62);
            notesCheck.Name = "notesCheck";
            notesCheck.Size = new Size(42, 33);
            notesCheck.TabIndex = 6;
            notesCheck.Text = "Notes";
            notesCheck.UseVisualStyleBackColor = true;
            // 
            // usernameCheck
            // 
            usernameCheck.AutoSize = true;
            usernameCheck.CheckAlign = ContentAlignment.BottomCenter;
            usernameCheck.Location = new Point(37, 61);
            usernameCheck.Name = "usernameCheck";
            usernameCheck.Size = new Size(64, 33);
            usernameCheck.TabIndex = 5;
            usernameCheck.Text = "Username";
            usernameCheck.UseVisualStyleBackColor = true;
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.Location = new Point(57, 15);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(234, 15);
            searchLabel.TabIndex = 4;
            searchLabel.Text = "Fields to Search When Searching Your Vault";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(167, 15);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 3;
            // 
            // passwordTab
            // 
            passwordTab.Controls.Add(symbolsCheck);
            passwordTab.Controls.Add(lengthTextBox);
            passwordTab.Controls.Add(passwordLengthLabel);
            passwordTab.Location = new Point(4, 24);
            passwordTab.Name = "passwordTab";
            passwordTab.Padding = new Padding(3);
            passwordTab.Size = new Size(343, 150);
            passwordTab.TabIndex = 1;
            passwordTab.Text = "Password";
            passwordTab.UseVisualStyleBackColor = true;
            // 
            // symbolsCheck
            // 
            symbolsCheck.AutoSize = true;
            symbolsCheck.CheckAlign = ContentAlignment.BottomCenter;
            symbolsCheck.Location = new Point(144, 76);
            symbolsCheck.Name = "symbolsCheck";
            symbolsCheck.Size = new Size(56, 33);
            symbolsCheck.TabIndex = 4;
            symbolsCheck.Text = "Symbols";
            symbolsCheck.UseVisualStyleBackColor = true;
            // 
            // lengthTextBox
            // 
            lengthTextBox.Location = new Point(204, 24);
            lengthTextBox.Name = "lengthTextBox";
            lengthTextBox.Size = new Size(100, 23);
            lengthTextBox.TabIndex = 1;
            lengthTextBox.TextChanged += textBox1_TextChanged;
            // 
            // passwordLengthLabel
            // 
            passwordLengthLabel.AutoSize = true;
            passwordLengthLabel.Location = new Point(17, 27);
            passwordLengthLabel.Name = "passwordLengthLabel";
            passwordLengthLabel.Size = new Size(148, 15);
            passwordLengthLabel.TabIndex = 0;
            passwordLengthLabel.Text = "Random Password Length:";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(generalTab);
            tabControl.Controls.Add(passwordTab);
            tabControl.Controls.Add(searchTab);
            tabControl.Location = new Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(351, 178);
            tabControl.TabIndex = 0;
            // 
            // generalTab
            // 
            generalTab.Controls.Add(inactivityComboBox);
            generalTab.Controls.Add(inactivityLabel);
            generalTab.Location = new Point(4, 24);
            generalTab.Name = "generalTab";
            generalTab.Size = new Size(343, 150);
            generalTab.TabIndex = 2;
            generalTab.Text = "General";
            generalTab.UseVisualStyleBackColor = true;
            // 
            // inactivityComboBox
            // 
            inactivityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            inactivityComboBox.FormattingEnabled = true;
            inactivityComboBox.Items.AddRange(new object[] { "5", "15", "30", "60", "Never" });
            inactivityComboBox.Location = new Point(188, 35);
            inactivityComboBox.Name = "inactivityComboBox";
            inactivityComboBox.Size = new Size(121, 23);
            inactivityComboBox.TabIndex = 1;
            inactivityComboBox.SelectedIndexChanged += inactivityComboBox_SelectedIndexChanged;
            // 
            // inactivityLabel
            // 
            inactivityLabel.Location = new Point(12, 31);
            inactivityLabel.Name = "inactivityLabel";
            inactivityLabel.Size = new Size(170, 43);
            inactivityLabel.TabIndex = 0;
            inactivityLabel.Text = "Lock after how many minutes of inactivity:";
            // 
            // PreferencesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 225);
            Controls.Add(errorLabel);
            Controls.Add(cancelBtn);
            Controls.Add(updateBtn);
            Controls.Add(tabControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PreferencesForm";
            Text = "Preferences - PassSentinel";
            Load += PreferencesForm_Load;
            searchTab.ResumeLayout(false);
            searchTab.PerformLayout();
            passwordTab.ResumeLayout(false);
            passwordTab.PerformLayout();
            tabControl.ResumeLayout(false);
            generalTab.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button updateBtn;
        private Button cancelBtn;
        private Label errorLabel;
        private TabPage searchTab;
        private CheckBox urlCheck;
        private CheckBox notesCheck;
        private CheckBox usernameCheck;
        private Label searchLabel;
        private Label label1;
        private TabPage passwordTab;
        private CheckBox symbolsCheck;
        private TextBox lengthTextBox;
        private Label passwordLengthLabel;
        private TabControl tabControl;
        private TabPage generalTab;
        private Label inactivityLabel;
        private ComboBox inactivityComboBox;
    }
}