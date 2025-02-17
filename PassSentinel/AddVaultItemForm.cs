using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassSentinel
{
    internal partial class AddVaultItemForm : Form
    {

        private Sentinel sentinel;
        private VaultItemDAO dao;
        private VaultItem vaultItem;

        public AddVaultItemForm(Sentinel sentinel, VaultItemDAO dao)
        {
            InitializeComponent();
            this.sentinel = sentinel;
            this.dao = dao;

        } // end constructor

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (!ValidInput())
            {
                errorLabel.Text = "Not all necessary fields are filled!";
                return;
            }

            VaultItem item = new VaultItem();
            item.Name = nameTextBox.Text;
            item.URL = Util.Encode(urlTextBox.Text);
            item.Username = Util.Encode(usernameTextBox.Text);
            item.Password = Util.Encode(passwordTextBox.Text);
            item.Notes = Util.Encode(notesTextBox.Text);

            sentinel.EncryptItem(item);

            dao.Add(item);

            this.Close();

        } // end addBtn_Click

        private bool ValidInput()
        {
            if (nameTextBox.Text == null || nameTextBox.Text == "")
                return false;

            if (usernameTextBox.Text == null || usernameTextBox.Text == "")
                return false;

            if (passwordTextBox.Text == null || passwordTextBox.Text == "")
                return false;

            return true;
        } // end ValidInput


        private void viewPassBtn_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.UseSystemPasswordChar)
                passwordTextBox.UseSystemPasswordChar = false;

            else
                passwordTextBox.UseSystemPasswordChar = true;
        } // end viewPassBtn_Click

        private void genPassBtn_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == null || passwordTextBox.Text == "")
                passwordTextBox.Text = Security.RandomPassword(Preferences.RandomPasswordLength, Preferences.GenerateSymbols);
            
            else
            {
                ConfirmForm confirmForm = new ConfirmForm();
                confirmForm.SetText("CAUTION! This will replace the current password! Proceed with random password?");
                confirmForm.ShowDialog();

                if (confirmForm.GetConfirmed())
                {
                    passwordTextBox.Text = Security.RandomPassword(Preferences.RandomPasswordLength, Preferences.GenerateSymbols);
                }
            }

        } // end genPassBtn_Click

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // No confirmation if nothing as been typed
            if (String.IsNullOrEmpty(nameTextBox.Text)
                && String.IsNullOrEmpty(usernameTextBox.Text)
                && String.IsNullOrEmpty(passwordTextBox.Text)
                && String.IsNullOrEmpty(urlTextBox.Text)
                && String.IsNullOrEmpty(notesTextBox.Text)
               )
            {
                this.Close();
            }

            else {
                ConfirmForm confirmForm = new ConfirmForm();
                confirmForm.ShowDialog();
                if (confirmForm.GetConfirmed())
                    this.Close();
            }
        } // end cancelBtn_Click
    } // end class
}
