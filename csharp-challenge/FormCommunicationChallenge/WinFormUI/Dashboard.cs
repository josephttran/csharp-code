using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WinFormUI.Mediator;

namespace WinFormUI
{
    public partial class Dashboard : Form
    {
        MessageMediatorDashboard MessageMediator { get; set; }

        public Dashboard()
        {
            InitializeComponent();

            MessageMediator = new MessageMediatorDashboard
            {
                Dashboard = this
            };
        }

        private void LaunchMessage_Click(object sender, EventArgs e)
        {
            using (MessageCreation messageCreation = new MessageCreation(MessageMediator))
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

        public void AppendMessageToTextBox(MessageModel messageModel)
        {
            messageText.AppendText($"{ messageModel.Name } ");
        }
    }
}
