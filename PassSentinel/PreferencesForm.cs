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
    public partial class PreferencesForm : Form
    {
        private PassSentinelDatabase db;
        private Dictionary<string, object> prefDict;

        public PreferencesForm()
        {
            InitializeComponent();
        }

        private void PreferencesForm_Load(object sender, EventArgs e)
        {

            prefDict = Globals.DB.GetPreferences();

            lengthTextBox.Text = ((int)prefDict["RandomPasswordLength"]).ToString();
            symbolsCheck.Checked = (bool)prefDict["GenerateSymbols"];
            usernameCheck.Checked = (bool)prefDict["SearchUsername"];
            notesCheck.Checked = (bool)prefDict["SearchNotes"];
            urlCheck.Checked = (bool)prefDict["SearchURL"];
            viewUsernameCheck.Checked = (bool)prefDict["ViewUsername"];
            viewUrlCheck.Checked = (bool)prefDict["ViewURL"];

            if ((int)prefDict["InactivityTimer"] == -1)
                inactivityComboBox.SelectedItem = "Never";
            else
                inactivityComboBox.SelectedItem = ((int)prefDict["InactivityTimer"]).ToString();

        } // end PreferencesForm_Load

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private bool ValidInput()
        {
            int length;
            try
            {
                length = int.Parse(lengthTextBox.Text);
            }

            catch (Exception ex)
            {
                errorLabel.Text = "Must enter a number.";
                return false;
            }

            if (length < 8)
            {
                errorLabel.Text = "Length must be at least 8 characters!";
                return false;
            }

            errorLabel.Text = "";
            return true;
        } // end ValidInput

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        } // end cancelBtn_Click

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (!ValidInput())
                return;

            string timerLenStr = inactivityComboBox.SelectedItem.ToString();
            int timerLen = timerLenStr == "Never" ? -1 : Int32.Parse(timerLenStr);


            Preferences.RandomPasswordLength = Int32.Parse(lengthTextBox.Text);
            Preferences.GenerateSymbols = symbolsCheck.Checked;
            Preferences.SearchUsername = usernameCheck.Checked;
            Preferences.SearchNotes = notesCheck.Checked;
            Preferences.SearchURL = urlCheck.Checked;
            Preferences.InactivityTimer = timerLen;
            Preferences.ViewUsername = viewUsernameCheck.Checked;
            Preferences.ViewURL = viewUrlCheck.Checked;

            Globals.DB.UpdatePreferences(); // Updates based on Preferences static class

            this.Close();

        } // end updateBtn_Click

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void inactivityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void errorLabel_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void usernameCheck_CheckedChanged(object sender, EventArgs e)
        {

        }
    } // end class
} // end namespace
