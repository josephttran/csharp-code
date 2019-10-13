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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void LaunchMessage_Click(object sender, EventArgs e)
        {
            using (MessageCreation messageCreation = new MessageCreation())
            {
                messageCreation.ShowDialog();
            };
        }

        private void LaunchSubDashboard_Click(object sender, EventArgs e)
        {
            var subDashboardForm = Application.OpenForms["SubDashboard"];

            if (subDashboardForm == null)
            {
                SubDashboard subDashboard = new SubDashboard();
                subDashboard.Show();
            }
        }
    }
}
