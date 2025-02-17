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
    internal partial class EditVaultItemForm : Form
    {
        private Sentinel sentinel;
        private VaultItemDAO dao;
        private VaultItem vaultItem;

        public EditVaultItemForm(VaultItem item, Sentinel sentinel, VaultItemDAO dao)
        {
            InitializeComponent();
            this.sentinel = sentinel;
            this.dao = dao;
            this.vaultItem = item;

            PopulateFields();

            this.FormClosing += EditVaultItemForm_FormClosing;

        } // end constructor

        private void EditVaultItemForm_Load(object sender, EventArgs e) { }


        private void PopulateFields()
        {
            if (vaultItem.Encrypted)
                sentinel.DecryptItem(vaultItem);

            nameTextBox.Text = vaultItem.Name;
            urlTextBox.Text = Util.Decode(vaultItem.URL);
            usernameTextBox.Text = Util.Decode(vaultItem.Username);
            passwordTextBox.Text = Util.Decode(vaultItem.Password);
            notesTextBox.Text = Util.Decode(vaultItem.Notes);


        } // end PopulateFields


        private void viewPassBtn_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.UseSystemPasswordChar)
                passwordTextBox.UseSystemPasswordChar = false;

            else
                passwordTextBox.UseSystemPasswordChar = true;
        } // end viewPassBtn_Click

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

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (vaultItem.Encrypted)
                sentinel.DecryptItem(vaultItem);

            if (!ValidInput())
            {
                errorLabel.Text = "Not all fields are filled!";
                return;
            }

            vaultItem.Name = nameTextBox.Text;
            vaultItem.URL = Util.Encode(urlTextBox.Text);
            vaultItem.Username = Util.Encode(usernameTextBox.Text);
            vaultItem.Password = Util.Encode(passwordTextBox.Text);
            vaultItem.Notes = Util.Encode(notesTextBox.Text);

            sentinel.EncryptItem(vaultItem);

            dao.Update(vaultItem);
            this.Close();

        } // end updateBtn_Click

        private void EditVaultItemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Make sure item is encrypted on close
            if (!vaultItem.Encrypted)
                sentinel.EncryptItem(vaultItem);

        } // end EditVaultItemForm_FormClosing

        private void genPassBtn_Click(object sender, EventArgs e)
        {
            ConfirmForm confirmForm = new ConfirmForm();
            confirmForm.SetText("CAUTION! This will replace the current password! Proceed with random password?");
            confirmForm.ShowDialog();

            if (confirmForm.GetConfirmed())
            {
                passwordTextBox.Text = Security.RandomPassword(Preferences.RandomPasswordLength, Preferences.GenerateSymbols);
            }


        } // end genPassBtn_Click

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        } // end cancelBtn_Click

        private void copyBtn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(passwordTextBox.Text);
            return;
        } // copyBtn_Click
    } // end class
}
