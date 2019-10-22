using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormCleanupChallenge
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(FormEvent.FormClosedHandler);
        }

        private void DashBoardButton_Click(object sender, EventArgs e)
        {
            using (PersonForm personForm = new PersonForm())
            {
                personForm.ShowDialog(this);
            };
        }
    }
}
