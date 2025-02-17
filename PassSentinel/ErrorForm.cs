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
    public partial class ErrorForm : Form
    {
        public ErrorForm()
        {
            InitializeComponent();
        }

        public ErrorForm(string message)
        {
            InitializeComponent();
            errorLabel.Text = message;
        }

        public void SetText(string message)
        {
            errorLabel.Text = message;
        } // end SetText

        private void ErrorForm_Load(object sender, EventArgs e)
        {

        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        } // end quitBtn_Click



    } // end class
} // end namespace
