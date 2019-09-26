using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> coins = new Dictionary<string, decimal>()
            {
                { "quarter", 0.25m },
                { "dime", 0.10m },
                { "nickel", 0.05m },
                { "penny", 0.01m }
            };

            string formatSpecifier = "C";
            decimal amountOwe = 0.10m;
            decimal amountPaid = 1.20m;
            decimal changeAmount = CalculateChangeAmount(amountOwe, amountPaid);

            if (changeAmount < 0)
            {
                Console.WriteLine("You have under paid!");
            }
            else if (changeAmount == 0)
            {
                Console.WriteLine("Exact amount paid. Nothing is due.");
            }
            else
            {
                Dictionary<string, int> change = GetChangeInCoin(coins, changeAmount);
                PrintChangeInfo(formatSpecifier, amountOwe, amountPaid, changeAmount, change);
            }
        }

        static decimal CalculateChangeAmount(decimal amountDue, decimal amountPaid)
        {
            return decimal.Subtract(amountPaid, amountDue);
        }

        static Dictionary<string, int> GetChangeInCoin(Dictionary<string, decimal> coins, decimal changeAmount)
        {
            Dictionary<string, int> change = new Dictionary<string, int>();

            foreach (KeyValuePair<string, decimal> coin in coins)
            {
                while (coin.Value <= changeAmount)
                {
                    if (!change.ContainsKey(coin.Key))
                    {
                        change.Add(coin.Key, 1);
                    }
                    else
                    {
                        change[coin.Key]++;
                    }

                    changeAmount = decimal.Subtract(changeAmount, coin.Value);
                }
            }

            return change;
        }

        static void PrintChangeInfo(string formatSpecifier, decimal amountOwe, decimal amountPaid, decimal changeAmount, Dictionary<string, int> change)
        {
            Console.WriteLine($"Amount to pay: { amountOwe.ToString(formatSpecifier) }");
            Console.WriteLine($"Amount paid: { amountPaid.ToString(formatSpecifier) }");
            Console.WriteLine($"The amount of change back is { changeAmount.ToString(formatSpecifier) }");
            Console.WriteLine($"\nThe following change to give back: ");
            Console.WriteLine(String.Join(", ", change.Select(kv => $"{ kv.Value } { kv.Key }")));
        }
    }
}
