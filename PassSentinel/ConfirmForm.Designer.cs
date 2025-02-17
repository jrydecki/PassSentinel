namespace PassSentinel
{
    partial class ConfirmForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmForm));
            messageLabel = new Label();
            yesBtn = new Button();
            noBtn = new Button();
            SuspendLayout();
            // 
            // messageLabel
            // 
            messageLabel.Location = new Point(12, 19);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(201, 45);
            messageLabel.TabIndex = 0;
            messageLabel.Text = "Are you sure?";
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // yesBtn
            // 
            yesBtn.Location = new Point(32, 67);
            yesBtn.Name = "yesBtn";
            yesBtn.Size = new Size(75, 23);
            yesBtn.TabIndex = 1;
            yesBtn.Text = "Yes";
            yesBtn.UseVisualStyleBackColor = true;
            yesBtn.Click += yesBtn_Click;
            // 
            // noBtn
            // 
            noBtn.Location = new Point(113, 67);
            noBtn.Name = "noBtn";
            noBtn.Size = new Size(75, 23);
            noBtn.TabIndex = 2;
            noBtn.Text = "No";
            noBtn.UseVisualStyleBackColor = true;
            noBtn.Click += noBtn_Click;
            // 
            // ConfirmForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(229, 102);
            Controls.Add(noBtn);
            Controls.Add(yesBtn);
            Controls.Add(messageLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ConfirmForm";
            Text = "Confim - PassSentinel";
            Load += ConfirmForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label messageLabel;
        private Button yesBtn;
        private Button noBtn;
    }
}