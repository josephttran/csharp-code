using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

using SodaMachineLibrary.DataAccess;
using SodaMachineLibrary.Logics;
using System;
using SodaMachineLibrary.Models;
using System.Collections.Generic;

namespace SodaMachineConsoleUI
{
    class Program
    {
        private static ServiceProvider ServiceProvider { get; set; }

        static void Main()
        {
            ConfigureServices();
            SodaMachineLogic sodaMachineLogic = ActivatorUtilities.CreateInstance<SodaMachineLogic>(ServiceProvider);
            Menu menu = new Menu();
            SodaMachineDisplay sodaMachineDisplay = new SodaMachineDisplay();

            string userId = "user12";

            while (true)
            {
                menu.PrintMenu();
                string userChoice = Console.ReadLine();
                Console.WriteLine();

                switch (userChoice)
                {
                    case "1":
                        sodaMachineDisplay.PrintTypesOfSoda(sodaMachineLogic.ListTypesOfSoda());
                        break;
                    case "2":
                        sodaMachineDisplay.PrintSodaInStock(sodaMachineLogic.GetSodaInventory());
                        break;
                    case "3":
                        sodaMachineDisplay.PrintSodaPrice(sodaMachineLogic.GetSodaPrice());
                        break;
                    case "4":
                        sodaMachineDisplay.PrintInsertMoneyChoice(sodaMachineLogic.AcceptedCoinValues);
                        string userMoneyInput = Console.ReadLine();

                        if (decimal.TryParse(userMoneyInput, out decimal moneyResult))
                        {
                            decimal moneyInserted = sodaMachineLogic.MoneyInserted(userId, moneyResult);

                            if (moneyInserted != 0)
                            {
                                sodaMachineDisplay.PrintAmountInserted(moneyInserted);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid currency");
                        }

                        break;
                    case "5":
                        sodaMachineDisplay.PrintAmountInserted(sodaMachineLogic.GetMoneyInsertedTotal(userId));
                        break;
                    case "6":
                        List<SodaModel> availableSodas = sodaMachineLogic.ListTypesOfSoda();
                        sodaMachineDisplay.PrintSodaToBuyChoice(availableSodas);
                        string userSodaInput = Console.ReadLine();

                        if (int.TryParse(userSodaInput, out int sodaResult))
                        {
                            if (sodaResult >= 0 && sodaResult < availableSodas.Count)
                            {
                                SodaModel sodaInput = availableSodas[sodaResult];
                                var (soda, coins, message) = sodaMachineLogic.RequestSoda(sodaInput);

                                if (string.IsNullOrEmpty(soda.Name))
                                {
                                    Console.WriteLine(message);
                                }
                                else
                                {
                                    if (coins.Count > 0)
                                    {
                                        decimal change = 0;

                                        foreach(CoinModel coin in coins)
                                        {
                                            change += coin.Amount;
                                        }

                                        Console.WriteLine($"returned { change }");
                                    }

                                    sodaMachineDisplay.PrintSuccessMessage(soda);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid soda choice");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid soda choice");
                        }

                        break;
                    case "7":
                        decimal refund = sodaMachineLogic.IssueFullRefund(userId);
                        sodaMachineDisplay.PrintRefundAmount(refund);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }

        static void ConfigureServices()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            ServiceCollection serviceCollection = new ServiceCollection();

            IConfigurationRoot Configuration = builder.Build();

            serviceCollection.AddSingleton<IConfiguration>(Configuration);
            serviceCollection.AddTransient<IDataAccess, TextFileDataAccess>();   
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
