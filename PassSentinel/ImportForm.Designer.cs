namespace PassSentinel
{
    partial class ImportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForm));
            filePathTextBox = new TextBox();
            selectFileBtn = new Button();
            selectFileDialog = new OpenFileDialog();
            importSourceComboBox = new ComboBox();
            sourceLabel = new Label();
            importBtn = new Button();
            cancelBtn = new Button();
            errorLabel = new Label();
            SuspendLayout();
            // 
            // filePathTextBox
            // 
            filePathTextBox.Location = new Point(34, 94);
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.ReadOnly = true;
            filePathTextBox.Size = new Size(173, 23);
            filePathTextBox.TabIndex = 0;
            filePathTextBox.TextChanged += filePathTextBox_TextChanged;
            // 
            // selectFileBtn
            // 
            selectFileBtn.Location = new Point(227, 94);
            selectFileBtn.Name = "selectFileBtn";
            selectFileBtn.Size = new Size(93, 23);
            selectFileBtn.TabIndex = 1;
            selectFileBtn.Text = "Select File...";
            selectFileBtn.UseVisualStyleBackColor = true;
            selectFileBtn.Click += selectFileBtn_Click;
            // 
            // selectFileDialog
            // 
            selectFileDialog.FileName = "openFileDialog1";
            // 
            // importSourceComboBox
            // 
            importSourceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            importSourceComboBox.FormattingEnabled = true;
            importSourceComboBox.Items.AddRange(new object[] { "PassSentinel", "LastPass", "Bitwarden", "1Password" });
            importSourceComboBox.Location = new Point(199, 55);
            importSourceComboBox.Name = "importSourceComboBox";
            importSourceComboBox.Size = new Size(121, 23);
            importSourceComboBox.TabIndex = 2;
            importSourceComboBox.SelectedIndexChanged += importSourceComboBox_SelectedIndexChanged;
            // 
            // sourceLabel
            // 
            sourceLabel.AutoSize = true;
            sourceLabel.Location = new Point(34, 58);
            sourceLabel.Name = "sourceLabel";
            sourceLabel.Size = new Size(130, 15);
            sourceLabel.TabIndex = 3;
            sourceLabel.Text = "Select Source Manager:";
            // 
            // importBtn
            // 
            importBtn.Location = new Point(34, 146);
            importBtn.Name = "importBtn";
            importBtn.Size = new Size(75, 23);
            importBtn.TabIndex = 4;
            importBtn.Text = "Import";
            importBtn.UseVisualStyleBackColor = true;
            importBtn.Click += importBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(245, 146);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(75, 23);
            cancelBtn.TabIndex = 5;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(34, 120);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(286, 23);
            errorLabel.TabIndex = 6;
            errorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ImportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 194);
            Controls.Add(errorLabel);
            Controls.Add(cancelBtn);
            Controls.Add(importBtn);
            Controls.Add(sourceLabel);
            Controls.Add(importSourceComboBox);
            Controls.Add(selectFileBtn);
            Controls.Add(filePathTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ImportForm";
            Text = "Import - PassSentinel";
            Load += ImportForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox filePathTextBox;
        private Button selectFileBtn;
        private OpenFileDialog selectFileDialog;
        private ComboBox importSourceComboBox;
        private Label sourceLabel;
        private Button importBtn;
        private Button cancelBtn;
        private Label errorLabel;
    }
}