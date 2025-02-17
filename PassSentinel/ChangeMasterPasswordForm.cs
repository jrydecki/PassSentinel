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
    internal partial class ChangeMasterPasswordForm : Form
    {
        private Sentinel sentinel;

        public ChangeMasterPasswordForm(Sentinel sentinel)
        {
            InitializeComponent();
            this.sentinel = sentinel;
        }

        private void ChangeMasterPasswordForm_Load(object sender, EventArgs e)
        {

        }


        private bool ValidInput()
        {
            if (currentPassTextBox.Text == null || currentPassTextBox.Text == "")
            {
                errorLabel.Text = "Enter current password!";
                return false;
            }

            if (newPass1TextBox.Text == null || newPass1TextBox.Text == "" || newPass1TextBox.Text != newPass2TextBox.Text)
            {
                errorLabel.Text = "New passwords don't match!";
                return false;
            }

            return true;
        } // end ValidInput


        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        } // end cancelBtn_Click

        private void currentPassTextBox_TextChanged(object sender, EventArgs e) { }
        private void newPass1TextBox_TextChanged(object sender, EventArgs e) {  }
        private void newPass2TextBox_TextChanged(object sender, EventArgs e) 
        { 
            if (newPass2TextBox.Text != this.newPass1TextBox.Text)
                errorLabel.Text = "Passwords don't match!";
          
            else
                errorLabel.Text = "";
        } // end newPass2TextBox_TextChanged

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (!ValidInput())
                return;

            byte[] masterSalt = Globals.DB.GetMasterSalt(Globals.Username);

            char[] currentPassword = currentPassTextBox.Text.ToCharArray();

            // Check current password
            if (!Security.VerifyPassword(Globals.Username, currentPassword))
            {
                Array.Clear(currentPassword, 0, currentPassword.Length);
                currentPassTextBox.Clear();
                errorLabel.Text = "Wrong Password";
                return;
            }
            Array.Clear(currentPassword, 0, currentPassword.Length);
            currentPassTextBox.Clear();

            // Confirm Change Password
            ConfirmForm confirmForm = new ConfirmForm();
            confirmForm.SetText("Are you sure?\nOnce you change you cannot go back.");
            confirmForm.ShowDialog();

            if (!confirmForm.GetConfirmed())
                return;

            ChangeMasterPassword();

        } // end updateBtn_Click


        private void ChangeMasterPassword()
        {
            VaultItemDAO dao = new VaultItemDAO();

            // Decrypt all items & set new IV
            List<VaultItem> vaultItems = dao.GetAll();
            for (int i = 0; i < vaultItems.Count; i++)
            {
                sentinel.DecryptItem(vaultItems[i]);
                vaultItems[i].IV = Security.GenerateIV();
            }

            // Set new master password in DB
            byte[] hashSalt = Security.GenerateSalt();
            char[] newPassword = newPass1TextBox.Text.ToCharArray();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(newPassword);
            Globals.DB.UpdateUserPassword(
                Globals.UserID,
                Security.GenerateSalt(), // Salt for Derivation
                hashSalt, // Salt for Verificaton Hash
                Security.Argon2Hash(hashSalt, passwordBytes) // Hash for Verification
            );

            // Set key in Sentinel
            sentinel.DeriveKey(Globals.DB.GetMasterSalt(Globals.Username), newPassword);
            Array.Clear(newPassword, 0, newPassword.Length);
            Array.Clear(passwordBytes, 0, passwordBytes.Length);
            currentPassTextBox.Clear();
            newPass1TextBox.Clear();
            newPass2TextBox.Clear();

            // Re-encrypt each vault item
            for (int i = 0; i < vaultItems.Count; i++)
            {
                sentinel.EncryptItem(vaultItems[i]);
                dao.Update(vaultItems[i]);
            }

            DoneForm doneForm = new DoneForm();
            doneForm.ShowDialog();

            this.Close();

        } // end ChangeMasterPassword


    } // end class
}
