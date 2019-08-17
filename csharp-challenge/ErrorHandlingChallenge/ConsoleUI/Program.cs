using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;

namespace ConsoleUI
{
    class Program
    {
        static void HandleException(Exception ex, string message)
        {
            Exception inner = ex.InnerException;

            if (inner == null)
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.Write($"{ message } ");

                while (inner != null)
                {
                    Console.WriteLine(inner.Message);
                    inner = inner.InnerException;
                }
            }
        }

        static void Main(string[] args)
        {
            PaymentProcessor paymentProcessor = new PaymentProcessor();

            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    var result = paymentProcessor.MakePayment($"Demo{ i }", i);

                    if (result == null)
                    {
                        Console.WriteLine($"Null value for item { i }");
                    }
                    else
                    {
                        Console.WriteLine(result.TransactionAmount);
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    HandleException(ex, "Skipped invalid record");
                }
                catch (FormatException ex) when (i != 5)
                {
                    HandleException(ex, "Formatting Issue");
                }
                catch (Exception ex)
                {
                    HandleException(ex, $"Payment skipped for payment with { i } items");
                }
            }

            Console.ReadLine();
        }
    }
}
