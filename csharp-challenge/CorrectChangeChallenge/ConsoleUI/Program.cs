using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> currency = new Dictionary<string, decimal>()
            {
                { "quarter", 0.25m },
                { "nickel", 0.05m },
                { "penny", 0.01m },
                { "dime", 0.10m },
                { "one dollar", 1.00m },
                { "five dollar", 5.00m },
                { "ten dollar", 10.00m },
                { "twenty dollar", 20.00m },
                { "fifty dollar", 50.00m },
            };
            currency = currency.OrderByDescending(keyValuePair => keyValuePair.Value)
                         .ToDictionary(keyValuePair => keyValuePair.Key, keyValuePair => keyValuePair.Value);
            string formatSpecifier = "C";
            decimal amountOwe = 100.11m;
            decimal amountPaid = 200.00m;
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
                Dictionary<string, int> change = GetChangeInCoin(currency, changeAmount);
                PrintChangeInfo(formatSpecifier, amountOwe, amountPaid, changeAmount, change);
            }
        }

        static decimal CalculateChangeAmount(decimal amountDue, decimal amountPaid)
        {
            return decimal.Subtract(amountPaid, amountDue);
        }

        static Dictionary<string, int> GetChangeInCoin(Dictionary<string, decimal> currency, decimal changeAmount)
        {
            Dictionary<string, int> change = new Dictionary<string, int>();

            foreach (KeyValuePair<string, decimal> coin in currency)
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
