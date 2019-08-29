using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

            ReadAllConnectionStrings();
            ReadAllAppSettings();

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

        static void ReadAllConnectionStrings()
        {
            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;

            Console.WriteLine("\nCollection of connection string:");
            foreach (ConnectionStringSettings str in connectionStrings)
            {
                Console.WriteLine($"Name = { str.Name }, connection string = { str }");
            }
        }

        static void ReadAllAppSettings()
        {
            NameValueCollection appSetting = ConfigurationManager.AppSettings;

            Console.WriteLine("\nCollection of app setting:");
            foreach (string key in appSetting.AllKeys)
            {
                Console.WriteLine($"Key = { key }, Value = { appSetting[key] }");
            }
        }
    }
}
