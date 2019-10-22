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
    public partial class SubDashboard : Form
    {
        MessageMediatorSubDashboard MessageMediator { get; set; }

        public SubDashboard()
        {
            InitializeComponent();

            MessageMediator = new MessageMediatorSubDashboard
            {
                SubDashboard = this,
                RequireName = true
            };
        }

        private void LaunchMessage_Click(object sender, EventArgs e)
        {
            using (MessageCreation messageCreation = new MessageCreation(MessageMediator))
            {
                messageCreation.ShowDialog();
            };
        }

        public void AppendNameAndMessageToTextBox()
        {
            nameAndMessageText.AppendText($"{ MessageMediator.MessageModel.Name }: { MessageMediator.MessageModel.Message } ");
            nameAndMessageText.AppendText(Environment.NewLine);
        }
    }
}
