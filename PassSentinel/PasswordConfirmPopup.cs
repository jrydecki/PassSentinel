using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PassSentinel
{
    public partial class PasswordConfirmPopup : Form
    {

        private bool Confirmed;
        private bool ExtraConfirm;

        public PasswordConfirmPopup(string descriptionText, string buttonText="DELETE", bool extraConfirm=true)
        {
            InitializeComponent();
            descriptionLabel.Text = descriptionText;
            deleteBtn.Text = buttonText;
            this.ExtraConfirm = extraConfirm;
            this.Confirmed = false;

            this.ActiveControl = passwordTextBox; // Focus on password
            this.AcceptButton = deleteBtn; // 'Enter' presses the login btn
        }

        public bool GetConfirmed()
        {
            return Confirmed;
        }

        private bool ValidInput()
        {
            if (passwordTextBox.Text == "" || passwordTextBox.Text == null)
            {
                errorLabel.Text = "Enter your password!";
                return false;
            }
            return true;
        } // end ValidInput

        

        private void PasswordConfirmPopup_Load(object sender, EventArgs e)
        {

        }

        private void descriptionLabel_Click(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        } // end cancelBtn_Click

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (!ValidInput())
                return;
            else
                errorLabel.Text = "";

            byte[] masterSalt = Globals.DB.GetMasterSalt(Globals.Username);


            // Attempt to Login
            char[] password = passwordTextBox.Text.ToCharArray();
            if (Security.VerifyPassword(Globals.Username, password))
            {
                Array.Clear(password, 0, password.Length);

                // ExtraConfirm doesn't make sense for Export
                if (ExtraConfirm)
                {
                    ConfirmForm confirmForm = new ConfirmForm();
                    confirmForm.SetText("Are you sure? You CANNOT GO BACK.");
                    confirmForm.ShowDialog();

                    if (confirmForm.GetConfirmed())
                    {
                        this.Confirmed = true;
                        this.Close();
                    }
                    else
                    {
                        passwordTextBox.Clear();
                        return;
                    }
                }

                else
                {
                    this.Confirmed = true;
                    this.Close();
                }

            }

            else
            {
                passwordTextBox.Clear();
                Array.Clear(password, 0, password.Length);
                errorLabel.Text = "Verification Failed. Wrong Password.";
                return;
            }
        } // end deleteBtn_Click

        private void passwordTextBox_TextChanged(object sender, EventArgs e) {} 
    } // end class
} // end namespace
