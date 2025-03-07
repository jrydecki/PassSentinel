using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using System.Globalization;

namespace PassSentinel
{
    internal partial class SettingsForm : Form
    {
        private Sentinel sentinel;
        private VaultItemDAO dao;
        public bool DeletedVaultItems { get; set; }
        public bool DeletedUser { get; set; }

        public bool Logout { get; set; }

        public SettingsForm(Sentinel sentinel)
        {
            InitializeComponent();

            this.dao = new VaultItemDAO();
            this.sentinel = sentinel;

            this.DeletedVaultItems = false;
            this.DeletedUser = false;
            this.Logout = false;


        } // end constructor

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        } // end SettingsForm_Load



        private void DeleteAllVaultItems()
        {
            VaultItemDAO dao = new VaultItemDAO();

            List<VaultItem> vaultItems = dao.GetAll();

            foreach (VaultItem vaultItem in vaultItems)
                dao.Delete(vaultItem);

        } // end DeleteAllVaultItems


        private void DeleteUser()
        {
            Globals.DB.DeleteUser(Globals.UserID);
        } // end DeleteUser

        private void updateBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        } // end updateBtn_Click

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        } // end cancelBtn_Click

        private void changePassBtn_Click(object sender, EventArgs e)
        {
            ChangeMasterPasswordForm changeForm = new ChangeMasterPasswordForm(this.sentinel);
            changeForm.ShowDialog();
            return;
        } // end changePassBtn_Click

        private void deleteVaultBtn_Click(object sender, EventArgs e)
        {
            PasswordConfirmPopup passConfirmPopup = new PasswordConfirmPopup("Enter master password to DELETE ALL ITEMS");
            passConfirmPopup.ShowDialog();

            if (passConfirmPopup.GetConfirmed())
                DeleteAllVaultItems();

            return;
        } // end deleteVaultBtn_Click

        private void deleteUserBtn_Click(object sender, EventArgs e)
        {
            PasswordConfirmPopup passConfirmPopup = new PasswordConfirmPopup("Enter master password to DELETE USER AND ALL ITEMS");
            passConfirmPopup.ShowDialog();

            if (passConfirmPopup.GetConfirmed())
            {
                DeleteAllVaultItems();
                DeleteUser();
                var doneForm = new DoneForm();
                doneForm.SetText("PassSentinel Will Now Restart.");
                doneForm.ShowDialog();

                string applicationPath = Application.ExecutablePath;
                Process.Start(applicationPath);
                Application.Exit();
            }

            return;
        } // end deleteUserBtn_Click

        private void preferencesBtn_Click(object sender, EventArgs e)
        {

            PreferencesForm preferencesForm = new PreferencesForm();
            preferencesForm.ShowDialog();


        } // end preferencesBtn_Click

        private void exportLabel_Click(object sender, EventArgs e) { }

        private void ExportVault(string exportPath)
        {
            //// Make sure format is .csv
            //if (!exportPath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            //    exportPath += ".csv"; 

            using (var exportItems = new SecureList<CSV.PassSentinelItem>())
            {
                foreach (VaultItem vaultItem in dao.GetAll())
                {
                    exportItems.Add(
                        new CSV.PassSentinelItem(
                            vaultItem.Name,
                            Util.Decode(sentinel.Decrypt(vaultItem.URL, vaultItem.IV)),
                            Util.Decode(sentinel.Decrypt(vaultItem.Username, vaultItem.IV)),
                            Util.Decode(sentinel.Decrypt(vaultItem.Password, vaultItem.IV)),
                            Util.Decode(sentinel.Decrypt(vaultItem.Notes, vaultItem.IV))
                        )
                    );
                }

                // Write the Export File
                using (var writer = new StreamWriter(exportPath))
                {
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        csv.WriteRecords(exportItems);
                }

            } // end SecureList using
        } // end ExportVault

        private void exportBtn_Click(object sender, EventArgs e)
        {
            ExportForm exportForm = new ExportForm(sentinel);
            exportForm.ShowDialog();

            return;

        } // end exportBtn_Click

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Logout = true;
            this.Close();
        } // end logoutBtn_Click

    } // end class
} // end namespace
