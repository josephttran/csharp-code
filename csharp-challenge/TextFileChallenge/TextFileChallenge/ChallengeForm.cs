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

        public ChallengeForm(IEnumerable<UserModel> records)
        {
            InitializeComponent();
            InitializeUsers(records);
            WireUpDropDown();
        }

        private void InitializeUsers(IEnumerable<UserModel> records)
        {
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
}
