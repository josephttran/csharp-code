using SodaMachineLibrary.Models;
using System;
using System.Collections.Generic;

namespace SodaMachineConsoleUI
{
    class SodaMachineDisplay
    {
        public SodaMachineDisplay()
        {
        }

        public void PrintAmountInserted(decimal money)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Currently inserted: { money }");
            Console.WriteLine("---------------------------");
        }

        public void PrintInsertMoneyChoice(List<decimal> acceptedCoinValues)
        {
            Console.WriteLine($"What coin do you want to insert:");

            foreach (decimal coinValue in acceptedCoinValues)
            {
                Console.WriteLine(coinValue.ToString());
            }

            Console.WriteLine();
            Console.Write("Enter a value: ");
        }
        public void PrintRefundAmount(decimal amount)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Refunded { amount }");
            Console.WriteLine("---------------------------");
        }

        public void PrintSodaInStock(List<SodaModel> sodas)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Number of soda in stock: " + sodas.Count);
            Console.WriteLine("Soda in stock:");
            Console.WriteLine("---------------------------");

            foreach (SodaModel soda in sodas)
            {
                Console.WriteLine($"{ soda.Name } at { soda.SlotOccupied }");
            }

            Console.WriteLine();
        }

        public void PrintSodaPrice(decimal price)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Soda cost { price }");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
        }

        public void PrintSodaToBuyChoice(List<SodaModel> sodas)
        {
            int index = 0;

            Console.WriteLine("What soda would you like to buy:");

            foreach (SodaModel soda in sodas)
            {
                Console.WriteLine($"{ index }) { soda.Name } at { soda.SlotOccupied }");
                index++;
            }

            Console.WriteLine();
            Console.Write($"Enter a value (0 - { sodas.Count - 1 }): ");
        }

        public void PrintSuccessMessage(SodaModel soda)
        {
            Console.WriteLine($"Thank you for you purchase. Enjoy your refreshing { soda.Name }.");
        }

        public void PrintTypesOfSoda(List<SodaModel> sodas)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Types of soda available:");
            Console.WriteLine("---------------------------");

            foreach (SodaModel soda in sodas)
            {
                Console.WriteLine(soda.Name);
            }

            Console.WriteLine();
        }
    }
}
