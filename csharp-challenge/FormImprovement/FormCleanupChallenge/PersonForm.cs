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
            this.FormClosed += new FormClosedEventHandler(FormEvent.FormClosedHandler);
        }
    }
}
