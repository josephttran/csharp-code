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
    public partial class MessageCreation : Form
    {
        private IMessageMediator MessageMediator { get; set; }
        MessageModel NameMessage { get; set; }

        public MessageCreation(IMessageMediator messageMediator)
        {
            InitializeComponent();

            MessageMediator = messageMediator;
            NameMessage = new MessageModel();
        }

        private void CreateMessage_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                MessageMediator.MessageModel = NameMessage;
                MessageMediator.SendMessage();
                this.Close();
            }
        }

        private void NameText_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameText.Text))
            {
                e.Cancel = true;
                nameText.Focus();
                errorProvider.SetError(nameText, "Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(nameText, "");
                NameMessage.Name = nameText.Text;
            }
        }

        private void MessageText_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(messageText.Text))
            {
                e.Cancel = true;
                messageText.Focus();
                errorProvider.SetError(messageText, "Message should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(messageText, "");
                NameMessage.Message = messageText.Text;
            }
        }
    }
}
