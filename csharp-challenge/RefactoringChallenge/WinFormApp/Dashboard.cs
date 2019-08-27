using System;
using System.ComponentModel;
using System.Windows.Forms;
using DataLibrary;

namespace WinFormApp
{
    public partial class Dashboard : Form
    {
        BindingList<SystemUserModel> users = new BindingList<SystemUserModel>();
        DataAccess DataAccess { get; set; }

        public Dashboard()
        {
            InitializeComponent();

            userDisplayList.DataSource = users;
            userDisplayList.DisplayMember = "FullName";

            DataAccess = new DataAccess();

            SetUsersFromRecords();
        }

        private void SetUsersFromRecords()
        {
            var records = DataAccess.GetRecords<SystemUserModel>();

            users.Clear();
            records.ForEach(x => users.Add(x));
        }

        private void CreateUserButton_Click(object sender, EventArgs e)
        {
            var p = new
            {
                FirstName = firstNameText.Text,
                LastName = lastNameText.Text
            };

            DataAccess.CreateRecord(p);

            firstNameText.Text = "";
            lastNameText.Text = "";
            firstNameText.Focus();

            SetUsersFromRecords();
        }

        private void ApplyFilterButton_Click(object sender, EventArgs e)
        {
            var p = new
            {
                Filter = filterUsersText.Text
            };

            var records = DataAccess.GetRecords<SystemUserModel>(p);

            users.Clear();
            records.ForEach(x => users.Add(x));
        }
    }
}
