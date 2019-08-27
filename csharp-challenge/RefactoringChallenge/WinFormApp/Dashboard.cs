using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp
{
    public partial class Dashboard : Form
    {
        BindingList<SystemUserModel> users = new BindingList<SystemUserModel>();
        IDbConnection Cnn { get; set; }

        public Dashboard()
        {
            InitializeComponent();

            userDisplayList.DataSource = users;
            userDisplayList.DisplayMember = "FullName";

            string connectionString = ConfigurationManager.ConnectionStrings["DapperDemoDB"].ConnectionString;

            Cnn = new SqlConnection(connectionString);

            SetUsersFromRecords();
        }

        ~Dashboard()
        {
            Cnn.Dispose();
        }

        private void SetUsersFromRecords()
        {
            var records = Cnn.Query<SystemUserModel>("spSystemUser_Get", commandType: CommandType.StoredProcedure).ToList();

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

            Cnn.Execute("dbo.spSystemUser_Create", p, commandType: CommandType.StoredProcedure);

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

            var records = Cnn.Query<SystemUserModel>("spSystemUser_GetFiltered", p, commandType: CommandType.StoredProcedure).ToList();

            users.Clear();
            records.ForEach(x => users.Add(x));
        }
    }
}
