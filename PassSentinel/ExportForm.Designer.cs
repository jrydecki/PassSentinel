namespace PassSentinel
{
    partial class ExportForm
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
            exportFormatComboBox = new ComboBox();
            exportFormatLabel = new Label();
            exportBtn = new Button();
            cancelBtn = new Button();
            descriptionLabel = new Label();
            exportSaveFileDialog = new SaveFileDialog();
            errorLabel = new Label();
            SuspendLayout();
            // 
            // exportFormatComboBox
            // 
            exportFormatComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            exportFormatComboBox.FormattingEnabled = true;
            exportFormatComboBox.Items.AddRange(new object[] { "PassSentinel", "LastPass", "Bitwarden", "1Password" });
            exportFormatComboBox.Location = new Point(183, 109);
            exportFormatComboBox.Name = "exportFormatComboBox";
            exportFormatComboBox.Size = new Size(121, 23);
            exportFormatComboBox.TabIndex = 0;
            // 
            // exportFormatLabel
            // 
            exportFormatLabel.AutoSize = true;
            exportFormatLabel.Location = new Point(92, 112);
            exportFormatLabel.Name = "exportFormatLabel";
            exportFormatLabel.Size = new Size(85, 15);
            exportFormatLabel.TabIndex = 1;
            exportFormatLabel.Text = "Export Format:";
            exportFormatLabel.Click += exportFormatLabel_Click;
            // 
            // exportBtn
            // 
            exportBtn.Location = new Point(12, 150);
            exportBtn.Name = "exportBtn";
            exportBtn.Size = new Size(75, 23);
            exportBtn.TabIndex = 2;
            exportBtn.Text = "Export";
            exportBtn.UseVisualStyleBackColor = true;
            exportBtn.Click += exportBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(304, 152);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(75, 23);
            cancelBtn.TabIndex = 3;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // descriptionLabel
            // 
            descriptionLabel.Location = new Point(12, 16);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(376, 90);
            descriptionLabel.TabIndex = 4;
            descriptionLabel.Text = "Please select the Password Manager you intend to use this export for. \r\n\r\nNOTE: This is create a file with all your passwords visible.";
            descriptionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(107, 150);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(180, 23);
            errorLabel.TabIndex = 5;
            errorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ExportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 185);
            Controls.Add(errorLabel);
            Controls.Add(descriptionLabel);
            Controls.Add(cancelBtn);
            Controls.Add(exportBtn);
            Controls.Add(exportFormatLabel);
            Controls.Add(exportFormatComboBox);
            Name = "ExportForm";
            Text = "Export - PassSentinel";
            Load += ExportForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox exportFormatComboBox;
        private Label exportFormatLabel;
        private Button exportBtn;
        private Button cancelBtn;
        private Label descriptionLabel;
        private SaveFileDialog exportSaveFileDialog;
        private Label errorLabel;
    }
}