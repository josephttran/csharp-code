using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormCleanupChallenge
{
    public static class FormEvent
    {
        public static void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("Handle form closed");
            // This pretend code executes when the form is closed. This
            // could be data cleanup code or code to close down open
            // connections.
        }
    }
}
