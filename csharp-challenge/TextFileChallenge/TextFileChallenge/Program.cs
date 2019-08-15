using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextFileChallenge
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string fileName = @"..\..\StandardDataSet.csv";
            Csv csv = new Csv(fileName);
            IEnumerable<UserModel> records = csv.GetRecords();

            Application.Run(new ChallengeForm(records));
        }
    }
}
