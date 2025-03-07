namespace PassSentinel
{
    partial class GenerateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerateForm));
            generateBtn = new Button();
            cancelBtn = new Button();
            passwordTextBox = new TextBox();
            copyBtn = new Button();
            okBtn = new Button();
            symbolsCheck = new CheckBox();
            lengthTextBox = new TextBox();
            lengthLabel = new Label();
            errorLabel = new Label();
            SuspendLayout();
            // 
            // generateBtn
            // 
            generateBtn.Location = new Point(123, 70);
            generateBtn.Name = "generateBtn";
            generateBtn.Size = new Size(75, 23);
            generateBtn.TabIndex = 2;
            generateBtn.Text = "Generate";
            generateBtn.UseVisualStyleBackColor = true;
            generateBtn.Click += generateBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(229, 162);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(75, 23);
            cancelBtn.TabIndex = 5;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(40, 117);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.ReadOnly = true;
            passwordTextBox.Size = new Size(204, 23);
            passwordTextBox.TabIndex = 6;
            passwordTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // copyBtn
            // 
            copyBtn.Location = new Point(252, 117);
            copyBtn.Name = "copyBtn";
            copyBtn.Size = new Size(45, 23);
            copyBtn.TabIndex = 3;
            copyBtn.Text = "Copy";
            copyBtn.UseVisualStyleBackColor = true;
            copyBtn.Click += copyBtn_Click;
            // 
            // okBtn
            // 
            okBtn.Location = new Point(17, 162);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(75, 23);
            okBtn.TabIndex = 4;
            okBtn.Text = "OK";
            okBtn.UseVisualStyleBackColor = true;
            okBtn.Click += okBtn_Click;
            // 
            // symbolsCheck
            // 
            symbolsCheck.AutoSize = true;
            symbolsCheck.CheckAlign = ContentAlignment.MiddleRight;
            symbolsCheck.Location = new Point(210, 25);
            symbolsCheck.Name = "symbolsCheck";
            symbolsCheck.Size = new Size(71, 19);
            symbolsCheck.TabIndex = 1;
            symbolsCheck.Text = "Symbols";
            symbolsCheck.UseVisualStyleBackColor = true;
            // 
            // lengthTextBox
            // 
            lengthTextBox.Location = new Point(126, 24);
            lengthTextBox.Name = "lengthTextBox";
            lengthTextBox.Size = new Size(44, 23);
            lengthTextBox.TabIndex = 0;
            lengthTextBox.TextAlign = HorizontalAlignment.Center;
            lengthTextBox.TextChanged += textBox2_TextChanged;
            // 
            // lengthLabel
            // 
            lengthLabel.AutoSize = true;
            lengthLabel.Location = new Point(20, 26);
            lengthLabel.Name = "lengthLabel";
            lengthLabel.Size = new Size(100, 15);
            lengthLabel.TabIndex = 7;
            lengthLabel.Text = "Password Length:";
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(98, 162);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(125, 23);
            errorLabel.TabIndex = 8;
            errorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GenerateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(316, 196);
            Controls.Add(errorLabel);
            Controls.Add(lengthLabel);
            Controls.Add(lengthTextBox);
            Controls.Add(symbolsCheck);
            Controls.Add(okBtn);
            Controls.Add(copyBtn);
            Controls.Add(cancelBtn);
            Controls.Add(generateBtn);
            Controls.Add(passwordTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GenerateForm";
            Text = "Generate Password - PassSentinel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button generateBtn;
        private Button cancelBtn;
        private TextBox passwordTextBox;
        private Button copyBtn;
        private Button okBtn;
        private CheckBox symbolsCheck;
        private TextBox lengthTextBox;
        private Label lengthLabel;
        private Label errorLabel;
    }
}