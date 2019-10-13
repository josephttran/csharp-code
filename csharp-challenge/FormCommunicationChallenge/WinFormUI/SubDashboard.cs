using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class SubDashboard : Form
    {
        public SubDashboard()
        {
            InitializeComponent();
        }

        private void LaunchMessage_Click(object sender, EventArgs e)
        {
            MessageCreation messageCreation = new MessageCreation();
            messageCreation.ShowDialog();
        }
    }
}
