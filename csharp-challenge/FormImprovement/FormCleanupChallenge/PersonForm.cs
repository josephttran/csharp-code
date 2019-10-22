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
    public partial class PersonForm : Form
    {
        public PersonForm()
        {
            InitializeComponent();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // This pretend code executes when the form is closed. This
            // could be data cleanup code or code to close down open
            // connections.
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
