using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string actionToTake = "";
            string connectionString = ConfigurationManager.ConnectionStrings["DapperDemoDB"].ConnectionString;
            IDbConnection cnn = new SqlConnection(connectionString);

            do
            {
                Console.Write("What action do you want to take (Display, Add, or Quit): ");
                actionToTake = Console.ReadLine();

                switch (actionToTake.ToLower())
                {
                    case "display":
                        Display();
                        break;
                    case "add":
                        object firstLastName = getName();
                        Add(firstLastName);
                        break;
                    default:
                        break;
                }
            } while (actionToTake.ToLower() != "quit");

            cnn.Dispose();

            object getName()
            {
                Console.Write("What is the first name: ");
                string firstName = Console.ReadLine();

                Console.Write("What is the last name: ");
                string lastName = Console.ReadLine();

                return new { FirstName = firstName, LastName = lastName };
            }

            void Display()
            {
                var records = cnn.Query<UserModel>("spSystemUser_Get", commandType: CommandType.StoredProcedure).ToList();

                Console.WriteLine();
                records.ForEach(x => Console.WriteLine($"{ x.FirstName } { x.LastName }"));
                Console.WriteLine();
            }

            void Add(object firstLastName)
            {
                cnn.Execute("dbo.spSystemUser_Create", firstLastName, commandType: CommandType.StoredProcedure);
                Console.WriteLine();
            }
        }
    }
}
