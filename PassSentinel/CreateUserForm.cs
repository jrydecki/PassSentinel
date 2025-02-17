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
    public partial class CreateUserForm : Form
    {

        public string username = null;
        public CreateUserForm()
        {
            InitializeComponent();
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {

        }

        private void masterPassInput1_TextChanged(object sender, EventArgs e)
        {
        } // end masterPassInput1_TextChanged

        private void masterPassInput2_TextChanged(object sender, EventArgs e)
        {
            if (masterPassInput1.Text != masterPassInput2.Text)
                errorLabel.Text = "Passwords do not match!";

            else
                errorLabel.Text = "";


        } // end masterPassInput2_TextChanged

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            this.username = usernameTextBox.Text;
        } // end usernameTextBox_TextChanged

        private void createUserBtn_Click(object sender, EventArgs e)
        {
            if (username == null || username == "")
            {
                errorLabel.Text = "Enter a username!";
                return;
            }
            else if (this.masterPassInput1.Text == null
                || this.masterPassInput1.Text == ""
                || this.masterPassInput1.Text != this.masterPassInput2.Text)
            {
                errorLabel.Text = "Passwords do not match!";
                return;
            }


            // Generate Master Password Hash and Store It
            if (Globals.DB.UserExists(username))
            {
                errorLabel.Text = "Username taken!";
                return;
            }

            byte[] hashSalt = Security.GenerateSalt();
            char[] password = masterPassInput1.Text.ToCharArray();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            Globals.DB.CreateUser(
                username, // Username
                Security.GenerateSalt(), // Salt for Derivation
                hashSalt, // Salt for Verification Hash
                Security.Argon2Hash(hashSalt, passwordBytes) // Hash for Verification
            );
            Array.Clear(password, 0, password.Length);
            Array.Clear(passwordBytes, 0, passwordBytes.Length);
            masterPassInput1.Clear();
            masterPassInput2.Clear();

            this.Close();

        } // end createUserBtn_Click

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        } // end cancelBtn_Click
    } // end class
}
