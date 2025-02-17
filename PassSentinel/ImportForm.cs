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
using CsvHelper;

namespace PassSentinel
{
    internal partial class ImportForm : Form
    {

        private Sentinel sentinel;

        public ImportForm(Sentinel sentinel)
        {
            InitializeComponent();
            this.sentinel = sentinel;
        }

        private void ImportForm_Load(object sender, EventArgs e)
        {

        }

        private bool ValidInput()
        {
            if (importSourceComboBox.SelectedItem == null)
            {
                errorLabel.Text = "Please Select a Password Manager.";
                return false;
            }

            if (filePathTextBox.Text == null || filePathTextBox.Text == "")
            {
                errorLabel.Text = "Please Select a File to Import.";
                return false;
            }

            errorLabel.Text = "";
            return true;
        } // end ValidInput

        private void ImportPassSentinel(string csvPath)
        {
            using (var reader = new StreamReader(csvPath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    // Read Items from CSV
                    List<CSV.PassSentinelItem> rows = csv.GetRecords<CSV.PassSentinelItem>().ToList();

                    // Convert Items to VaultItems
                    List<VaultItem> vaultItems = new List<VaultItem>();
                    foreach (CSV.PassSentinelItem item in rows)
                        vaultItems.Add(new VaultItem(item));


                    // Encrypt Items and Add to DB
                    VaultItemDAO dao = new VaultItemDAO();
                    foreach (VaultItem item in vaultItems)
                    {
                        sentinel.EncryptItem(item);
                        dao.Add(item);
                    } // end foreach

                } // end csv using
            } // end StreamReader using
        } // end ImportPassSentinel

        private void ImportLastPass(string csvPath)
        {

            using (var reader = new StreamReader(csvPath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    // Read Items from CSV
                    List<CSV.LastPassItem> rows = csv.GetRecords<CSV.LastPassItem>().ToList();

                    // Convert Items to VaultItems
                    List<VaultItem> vaultItems = new List<VaultItem>();
                    foreach (CSV.LastPassItem item in rows)
                        vaultItems.Add(new VaultItem(item));


                    // Encrypt Items and Add to DB
                    VaultItemDAO dao = new VaultItemDAO();
                    foreach (VaultItem item in vaultItems)
                    {
                        sentinel.EncryptItem(item);
                        dao.Add(item);
                    } // end foreach

                } // end csv using
            } // end StreamReader using


        } // end ImportLastPass

        private void ImportBitwarden(string csvPath)
        {
            using (var reader = new StreamReader(csvPath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    // Read Items from CSV
                    List<CSV.BitwardenItem> rows = csv.GetRecords<CSV.BitwardenItem>().ToList();

                    // Convert Items to VaultItems
                    List<VaultItem> vaultItems = new List<VaultItem>();
                    foreach (CSV.BitwardenItem item in rows)
                        vaultItems.Add(new VaultItem(item));


                    // Encrypt Items and Add to DB
                    VaultItemDAO dao = new VaultItemDAO();
                    foreach (VaultItem item in vaultItems)
                    {
                        sentinel.EncryptItem(item);
                        dao.Add(item);
                    } // end foreach

                } // end csv using
            } // end StreamReader using
        } // end ImportBitwarden

        private void Import1Password(string csvPath)
        {
            using (var reader = new StreamReader(csvPath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    // Read Items from CSV
                    List<CSV.OnePasswordItem> rows = csv.GetRecords<CSV.OnePasswordItem>().ToList();

                    // Convert Items to VaultItems
                    List<VaultItem> vaultItems = new List<VaultItem>();
                    foreach (CSV.OnePasswordItem item in rows)
                        vaultItems.Add(new VaultItem(item));


                    // Encrypt Items and Add to DB
                    VaultItemDAO dao = new VaultItemDAO();
                    foreach (VaultItem item in vaultItems)
                    {
                        sentinel.EncryptItem(item);
                        dao.Add(item);
                    } // end foreach

                } // end csv using
            } // end StreamReader using
        } // end Import1Password



        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void selectFileBtn_Click(object sender, EventArgs e)
        {
            selectFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";

            if (selectFileDialog.ShowDialog() == DialogResult.OK)
            {


                filePathTextBox.Text = selectFileDialog.FileName;
            } // end if
        } // end selectFileBtn_Click

        private void filePathTextBox_TextChanged(object sender, EventArgs e)
        {

        } // end filePathTextBox_TextChanged

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        } // end cancelBtn_Click

        private void importBtn_Click(object sender, EventArgs e)
        {
            if (!ValidInput())
                return;

            try
            {
                switch (importSourceComboBox.SelectedItem)
                {
                    case "PassSentinel":
                        ImportPassSentinel(filePathTextBox.Text);
                        break;

                    case "LastPass":
                        ImportLastPass(filePathTextBox.Text);
                        break;

                    case "Bitwarden":
                        ImportBitwarden(filePathTextBox.Text);
                        break;

                    case "1Password":
                        Import1Password(filePathTextBox.Text);
                        break;

                    default:
                        break;
                } // end switch

            }
            catch (CsvHelper.HeaderValidationException)
            {
                var doneForm = new DoneForm();
                doneForm.SetText("ERROR: Wrong Format Selected");
                doneForm.ShowDialog();
                return;
            }

            var confirmForm = new ConfirmForm();
            confirmForm.SetText("Done! Would you like to delete your export file?");
            confirmForm.ShowDialog();

            // If Confirmed, Delete Export File
            if (confirmForm.GetConfirmed())
                File.Delete(filePathTextBox.Text);
           

            this.Close();


        } // end importBtn_Click

        private void importSourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    } // end class
} // end namespace
