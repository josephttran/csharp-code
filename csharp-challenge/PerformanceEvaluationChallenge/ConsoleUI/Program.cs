using System;
using System.Diagnostics;
using ActionMethod;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] stringRepetitionNumbers = new int[] { 500, 5000, 50000 };
            int[] numberRepetitionNumbers = new int[] { 500000, 5000000 };
            string text = "newtext";
            double doubleNumber = 0.01;
            decimal decimalNumber = 0.01M;

            PrintMethodPerformance<string>("String Concatenate", PerformanceEvaluation.UseStringConcatenate, stringRepetitionNumbers, text);
            PrintMethodPerformance<string>("String Builder", PerformanceEvaluation.UseStringBuilder, stringRepetitionNumbers, text);
            PrintMethodPerformance<double>("Double", PerformanceEvaluation.UseDouble, numberRepetitionNumbers, doubleNumber);
            PrintMethodPerformance<decimal>("Decimal", PerformanceEvaluation.UseDecimal, numberRepetitionNumbers, decimalNumber);
        }

        static public void PrintMethodPerformance<T>(string description, Action<int, T> function, int[] repetitionList, T addOrAppend)
        {
            foreach (int repetitionNumber in repetitionList)
            {
                Stopwatch stopWatch = new Stopwatch();

                stopWatch.Start();
                function(repetitionNumber, addOrAppend);
                stopWatch.Stop();

                Console.WriteLine($"{ description } { repetitionNumber } rep: { stopWatch.ElapsedMilliseconds } ms");
            }
        }
    }
}
