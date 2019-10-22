using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextFileChallenge
{
    public partial class ChallengeForm : Form
    {
        BindingList<UserModel> users = new BindingList<UserModel>();
        Csv csv;

        public ChallengeForm(Csv csvObj)
        {
            csv = csvObj;

            InitializeComponent();
            InitializeUsers();
            WireUpDropDown();
        }

        private void InitializeUsers()
        {
            IEnumerable<UserModel> records = csv.GetRecords();

            foreach (var record in records)
            {
                users.Add(record);
            }
        }

        private void WireUpDropDown()
        {
            usersListBox.DataSource = users;
            usersListBox.DisplayMember = nameof(UserModel.DisplayText);
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                UserModel newUser = new UserModel
                {
                    FirstName = firstNameText.Text,
                    LastName = lastNameText.Text,
                    Age = Decimal.ToInt32(agePicker.Value),
                    IsAlive = isAliveCheckbox.Checked
                };
                users.Add(newUser);
            }
        }

        private void FirstNameText_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstNameText.Text))
            {
                e.Cancel = true;
                firstNameText.Focus();
                errorProviderNameText.SetError(firstNameText, "First name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderNameText.SetError(firstNameText, "");
            }
        }

        private void LastNameText_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lastNameText.Text))
            {
                e.Cancel = true;
                lastNameText.Focus();
                errorProviderNameText.SetError(lastNameText, "Last name should not be left blank!");
            }
            else if (lastNameText.Text.Contains(" "))
            {
                e.Cancel = true;
                lastNameText.Focus();
                errorProviderNameText.SetError(lastNameText, "Last name should not contain space!");
            }
            else
            {
                e.Cancel = false;
                errorProviderNameText.SetError(lastNameText, "");
            }
        }

        private void SaveListButton_Click(object sender, EventArgs e)
        {
            csv.SaveToCsv(users);
        }
    }
}
