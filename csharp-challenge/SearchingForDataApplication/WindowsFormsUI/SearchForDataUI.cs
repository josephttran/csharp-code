using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class SearchForDataUI : Form
    {
        readonly string primaryPath = @"../../Data/primary.txt";

        public SearchForDataUI()
        {
            InitializeComponent();
        }

        private void ButtonBonusSearch_Click(object sender, EventArgs e)
        {

        }

        private void ButtonPrimarySearch_Click(object sender, EventArgs e)
        {
            string searchValue = textBoxPrimarySearch.Text.ToLower();

            if (!string.IsNullOrEmpty(searchValue))
            {
                listBoxPrimary.Items.Clear();

                IEnumerable<string> lines = File.ReadLines(primaryPath);

                foreach (string line in lines)
                {
                    if (line.ToLower().IndexOf(searchValue) > -1)
                    {
                        listBoxPrimary.Items.Add(line);
                    }
                }
            }
        }
    }
}
