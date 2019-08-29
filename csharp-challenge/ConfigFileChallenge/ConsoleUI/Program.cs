using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadConnectionString("Default");
            ReadAppSetting("UserName");

            Console.ReadLine();
        }


        static void ReadConnectionString(string name)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            Console.WriteLine($"Connection string for { name }: { connectionString }");
        }

        static void ReadAppSetting(string key)
        {
            string appSetting = ConfigurationManager.AppSettings[key];
            Console.WriteLine($"App setting value for { key }: { appSetting }");
        }
    }
}
