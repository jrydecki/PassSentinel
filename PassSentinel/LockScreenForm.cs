using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PassSentinel
{
    public partial class LockScreenForm : Form
    {
        private PassSentinelDatabase db;

        public bool loginSuccess;
        public char[] password;

        public LockScreenForm()
        {
            InitializeComponent();

            this.loginSuccess = false;
            this.password = null;

            this.AcceptButton = unlockBtn; // 'Enter' presses the unlock button

            usernameTextBox.Text = Globals.Username;

        }

        private bool ValidInput()
        {
            if (string.IsNullOrEmpty(masterPassInput.Text))
            {
                errorLabel.Text = "Must enter password.";
                return false;
            }

            errorLabel.Text = "";
            return true;
        } // end ValidInput


        private void unlockBtn_Click(object sender, EventArgs e)
        {
            if (!ValidInput())
                return;

            byte[] masterSalt = Globals.DB.GetMasterSalt(Globals.Username);


            // Attempt to Login
            password = masterPassInput.Text.ToCharArray();
            if (Security.VerifyPassword(Globals.Username, password))
            {
                masterPassInput.Clear();
                this.loginSuccess = true;
                this.Close();
                return;
            }

            else
            {
                Array.Clear(password, 0, password.Length);
                masterPassInput.Clear();
                errorLabel.Text = "Login Failed. Wrong Password.";
                return;
            }

        } // end unlockBtn_Click

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            string applicationPath = Application.ExecutablePath;
            Process.Start(applicationPath);
            Application.Exit();
        } // end logoutBtnClick

        private void LockScreenForm_Load(object sender, EventArgs e)
        {

        }
    } // end class
} // end namespace
