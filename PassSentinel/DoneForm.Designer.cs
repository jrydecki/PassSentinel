namespace PassSentinel
{
    partial class DoneForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoneForm));
            doneLabel = new Label();
            okBtn = new Button();
            SuspendLayout();
            // 
            // doneLabel
            // 
            doneLabel.Location = new Point(55, 3);
            doneLabel.Name = "doneLabel";
            doneLabel.Size = new Size(116, 41);
            doneLabel.TabIndex = 0;
            doneLabel.Text = "Done!";
            doneLabel.TextAlign = ContentAlignment.MiddleCenter;
            doneLabel.Click += doneLabel_Click;
            // 
            // okBtn
            // 
            okBtn.Location = new Point(77, 47);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(67, 24);
            okBtn.TabIndex = 1;
            okBtn.Text = "OK";
            okBtn.UseVisualStyleBackColor = true;
            okBtn.Click += okBtn_Click;
            // 
            // DoneForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(226, 83);
            Controls.Add(okBtn);
            Controls.Add(doneLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DoneForm";
            Text = "Done - PassSentinel";
            Load += DoneForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label doneLabel;
        private Button okBtn;
    }
}