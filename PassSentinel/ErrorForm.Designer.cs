namespace PassSentinel
{
    partial class ErrorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorForm));
            errorLabel = new Label();
            quitBtn = new Button();
            SuspendLayout();
            // 
            // errorLabel
            // 
            errorLabel.Location = new Point(12, 9);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(382, 92);
            errorLabel.TabIndex = 0;
            errorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // quitBtn
            // 
            quitBtn.Location = new Point(168, 104);
            quitBtn.Name = "quitBtn";
            quitBtn.Size = new Size(75, 23);
            quitBtn.TabIndex = 1;
            quitBtn.Text = "Quit";
            quitBtn.UseVisualStyleBackColor = true;
            quitBtn.Click += quitBtn_Click;
            // 
            // ErrorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 137);
            Controls.Add(quitBtn);
            Controls.Add(errorLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ErrorForm";
            Text = "Error - PassSentinel";
            Load += ErrorForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label errorLabel;
        private Button quitBtn;
    }
}