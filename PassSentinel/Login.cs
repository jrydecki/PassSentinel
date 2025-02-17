using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassSentinel
{
    public partial class Login : Form
    {

        public string username = null;
        public char[] masterPassword = null;
        public char[] MasterPassword = null;
        public bool loginSuccess = false;
        public Int64 userID = -1;

        public Login()
        {
            InitializeComponent();

            this.ActiveControl = usernameTextBox; // Focus on username first

            this.AcceptButton = loginBtn; // 'Enter' presses the login btn

        } // end constructor


        public void ClearPassword()
        {
            Array.Clear(MasterPassword, 0, MasterPassword.Length);
        } // end ClearPassword

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (this.username == null || this.username == "")
            {
                errorLabel.Text = "Enter a username.";
                return;
            }
            else if (masterPassInput.Text == null || masterPassInput.Text == "")
            {
                errorLabel.Text = "Enter a password.";
                return;
            }
            else
                errorLabel.Text = "";


            byte[] masterSalt = Globals.DB.GetMasterSalt(username);

            // Attempt to Login
            MasterPassword = masterPassInput.Text.ToCharArray();
            if (Security.VerifyPassword(username, MasterPassword))
            {
                this.loginSuccess = true;
                this.userID = Globals.DB.GetUserID(username);
                this.Close();
                return;
            }

            else
            {
                errorLabel.Text = "Login Failed. Wrong Username or Password.";
                masterPassInput.Text = "";
                this.ClearPassword();
                return;
            }

        } // end loginBtn_Click

        private void Login_Load(object sender, EventArgs e)
        {

        } // end Login_Load

        private void masterPassInput_TextChanged(object sender, EventArgs e) { }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            this.username = usernameTextBox.Text;
        } // end usernameTextBox_TextChanged

        private void createUserLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var createUserForm = new CreateUserForm();
            createUserForm.ShowDialog();
            return;
        } // end createUserLinkLabel_LinkClicked

        private void errorLabel_Click(object sender, EventArgs e)
        {

        }
    } // end class
} // end namespace
