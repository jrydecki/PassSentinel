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
    public partial class GenerateForm : Form
    {
        public GenerateForm()
        {
            InitializeComponent();

            lengthTextBox.Text = Preferences.RandomPasswordLength.ToString();
            symbolsCheck.Checked = true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        } // end cancelBtn_Click

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        } // end okBtn_ClicK

        private bool ValidInput()
        {
            int x = 0;
            if (!Int32.TryParse(lengthTextBox.Text, out x))
            {
                errorLabel.Text = "Invalid Options";
                return false;
            }
            return true;
        } // end ValidInput

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void generateBtn_Click(object sender, EventArgs e)
        {

            if (!ValidInput())
                return;

            string password = Security.RandomPassword(Int32.Parse(lengthTextBox.Text), symbolsCheck.Checked);

            passwordTextBox.Text = password;

        } // end generateBtn_Click

        private void copyBtn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(passwordTextBox.Text);
            return;
        }
    } // end class
}
