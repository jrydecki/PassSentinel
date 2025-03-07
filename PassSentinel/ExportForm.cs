using CsvHelper;
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
    internal partial class ExportForm : Form
    {
        private Sentinel sentinel;
        private VaultItemDAO dao;
        public ExportForm(Sentinel sentinel)
        {
            InitializeComponent();

            this.sentinel = sentinel;
            this.dao = new VaultItemDAO();

            exportFormatComboBox.SelectedIndex = 0;


        }

        private void exportFormatLabel_Click(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        } // end cancelBtn_Click

        private void ExportForm_Load(object sender, EventArgs e)
        {

        }

        private void ExportVault(string exportPath, string outFormat)
        {

            switch (outFormat)
            {
                case "PassSentinel":
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
                        } // end foreach
                        using (var writer = new StreamWriter(exportPath))
                            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                                csv.WriteRecords(exportItems);
                        
                    } // end using
                    break;

                case "LastPass":
                    using (var exportItems = new SecureList<CSV.LastPassItem>())
                    {
                        foreach (VaultItem vaultItem in dao.GetAll())
                        {
                            exportItems.Add(
                                new CSV.LastPassItem(
                                    vaultItem.Name,
                                    Util.Decode(sentinel.Decrypt(vaultItem.URL, vaultItem.IV)),
                                    Util.Decode(sentinel.Decrypt(vaultItem.Username, vaultItem.IV)),
                                    Util.Decode(sentinel.Decrypt(vaultItem.Password, vaultItem.IV)),
                                    Util.Decode(sentinel.Decrypt(vaultItem.Notes, vaultItem.IV))
                                )
                            );
                        } // end foreach
                        using (var writer = new StreamWriter(exportPath))
                            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                                csv.WriteRecords(exportItems);
                    } // end using
                    break;

                case "Bitwarden":
                    using (var exportItems = new SecureList<CSV.BitwardenItem>())
                    {
                        foreach (VaultItem vaultItem in dao.GetAll())
                        {
                            exportItems.Add(
                                new CSV.BitwardenItem(
                                    vaultItem.Name,
                                    Util.Decode(sentinel.Decrypt(vaultItem.URL, vaultItem.IV)),
                                    Util.Decode(sentinel.Decrypt(vaultItem.Username, vaultItem.IV)),
                                    Util.Decode(sentinel.Decrypt(vaultItem.Password, vaultItem.IV)),
                                    Util.Decode(sentinel.Decrypt(vaultItem.Notes, vaultItem.IV))
                                )
                            );
                        } // end foreach
                        using (var writer = new StreamWriter(exportPath))
                            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                                csv.WriteRecords(exportItems);
                    } // end using
                    break;

                case "1Password":
                    using (var exportItems = new SecureList<CSV.OnePasswordItem>())
                    {
                        foreach (VaultItem vaultItem in dao.GetAll())
                        {
                            exportItems.Add(
                                new CSV.OnePasswordItem(
                                    vaultItem.Name,
                                    Util.Decode(sentinel.Decrypt(vaultItem.URL, vaultItem.IV)),
                                    Util.Decode(sentinel.Decrypt(vaultItem.Username, vaultItem.IV)),
                                    Util.Decode(sentinel.Decrypt(vaultItem.Password, vaultItem.IV)),
                                    Util.Decode(sentinel.Decrypt(vaultItem.Notes, vaultItem.IV))
                                )
                            );
                        } // end foreach
                        using (var writer = new StreamWriter(exportPath))
                            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                                csv.WriteRecords(exportItems);
                    } // end using
                    break;

                default:
                    return;

            } // end switch

            
        } // end ExportVault


        private void exportBtn_Click(object sender, EventArgs e)
        {
            PasswordConfirmPopup passwordForm = new PasswordConfirmPopup("Enter Password to Create an UNENCRYPTED Passwords Export.", "Export", false);
            passwordForm.ShowDialog();

            if (!passwordForm.GetConfirmed())
            {
                errorLabel.Text = "Export Canceled.";
                return;
            }

            exportSaveFileDialog.Title = "Export PassSentinel Passwords";
            exportSaveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            exportSaveFileDialog.DefaultExt = "csv";
            exportSaveFileDialog.AddExtension = true;
            exportSaveFileDialog.ShowDialog();

            if (String.IsNullOrEmpty(exportSaveFileDialog.FileName))
            {
                errorLabel.Text = "Export Canceled.";
                return;
            }

            ExportVault(exportSaveFileDialog.FileName, exportFormatComboBox.SelectedItem.ToString());

            this.Close();

        } // end exportBtn_click
    }
}
