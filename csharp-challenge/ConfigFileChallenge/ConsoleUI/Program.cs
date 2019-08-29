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
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
                Console.WriteLine($"Connection string for { name }: { connectionString }");
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading connection setting");
            }
        }

        static void ReadAppSetting(string key)
        {
            try
            {
                string appSetting = ConfigurationManager.AppSettings[key];
                Console.WriteLine($"App setting value for { key }: { appSetting }");
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app setting");
            }
        }

        static void ReadAllConnectionStrings()
        {
            try
            {
                ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;

                if (connectionStrings.Count == 0)
                {
                    Console.WriteLine("Connection strings is empty.");
                }
                else
                {
                    Console.WriteLine("\nCollection of connection string:");
                    foreach (ConnectionStringSettings str in connectionStrings)
                    {
                        Console.WriteLine($"Name = { str.Name }, connection string = { str }");

                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading connection settings");
            }
        }

        static void ReadAllAppSettings()
        {
            try
            {
                NameValueCollection appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    Console.WriteLine("\nCollection of app setting:");
                    foreach (string key in appSettings.AllKeys)
                    {
                        Console.WriteLine($"Key = { key }, Value = { appSettings[key] }");
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }
    }
}
