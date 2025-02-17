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
    public partial class ConfirmForm : Form
    {
        public bool Confirmed;

        public ConfirmForm()
        {
            InitializeComponent();
            this.Confirmed = false;
        } // end constructor

        public void SetText(string text)
        {
            messageLabel.Text = text;
        } // end SetText

        public bool GetConfirmed()
        {
            return Confirmed;
        } // end GetConfirmed

        private void yesBtn_Click(object sender, EventArgs e)
        {
            Confirmed = true;
            this.Close();
        } // end yesBtn_Click

        private void noBtn_Click(object sender, EventArgs e)
        {
            Confirmed = false;
            this.Close();
        } // end noBtn_Click

        private void ConfirmForm_Load(object sender, EventArgs e)
        {

        }
    } // end class
}
