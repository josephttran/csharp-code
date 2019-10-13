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
        public MessageCreation()
        {
            InitializeComponent();
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
                        (control as TextBox).Text += $" { nameText.Text }: { messageText.Text }";
                    }
                }
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
            }
        }
    }
}
