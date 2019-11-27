using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class SearchForDataUI : Form
    {
        readonly string primaryPath = @"../../Data/primary.txt";
        readonly string bonusPath = @"../../Data/bonus.txt";

        public SearchForDataUI()
        {
            InitializeComponent();
        }

        private void ButtonBonusSearch_Click(object sender, EventArgs e)
        {
            string pattern = @"\s\(\d{3}\)\s\d{3}-\d{4}\s";

            listBoxBonus.Items.Clear();

            IEnumerable<string> lines = File.ReadLines(bonusPath);

            if (lines != null)
            {
                foreach (string line in lines)
                {
                    if (Regex.IsMatch(line, pattern))
                    {
                        listBoxBonus.Items.Add(Regex.Match(line, pattern));
                    }
                }
            }
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
