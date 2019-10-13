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
    public partial class MessageCreation : Form
    {
        private MessageModel NameMessage { get; set; }

        public MessageCreation()
        {
            InitializeComponent();
            NameMessage = new MessageModel();
        }

        private void CreateMessage_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                Control.ControlCollection parentControls = this.Owner.Controls;

                foreach (Control control in parentControls)
                {
                    if (control is TextBox)
                    {
                        if (this.Owner.Name == "Dashboard")
                        {
                            (control as TextBox).AppendText($"{ NameMessage.Message } ");
                        }

                        if (this.Owner.Name == "SubDashboard")
                        {
                            (control as TextBox).AppendText($"{ NameMessage.Name }: { NameMessage.Message } ");
                        }

                        (control as TextBox).AppendText(Environment.NewLine);
                    }
                }

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
