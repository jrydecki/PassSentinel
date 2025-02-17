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
    public partial class DoneForm : Form
    {
        public DoneForm()
        {
            InitializeComponent();
        }

        public void SetText(string text)
        {
            this.doneLabel.Text = text;
        }

        private void DoneForm_Load(object sender, EventArgs e)
        {

        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void doneLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
