using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string formatSpecifier = "C";
            decimal amountOwe = 0.10m;
            decimal amountPaid = 1.00m;
            decimal changeAmount = CalculateChangeAmount(amountOwe, amountPaid);

            PrintChangeInfo(formatSpecifier, amountOwe, amountPaid, changeAmount);
        }

        static decimal CalculateChangeAmount(decimal amountDue, decimal amountPaid)
        {
            return decimal.Subtract(amountPaid, amountDue);
        }

        static void PrintChangeInfo(string formatSpecifier, decimal amountOwe, decimal amountPaid, decimal change)
        {
            Console.WriteLine($"Amount to pay: { amountOwe.ToString(formatSpecifier) }");
            Console.WriteLine($"Amount paid: { amountPaid.ToString(formatSpecifier) }");
            Console.WriteLine($"The amount of change back is { change.ToString(formatSpecifier) }");
        }
    }
}
