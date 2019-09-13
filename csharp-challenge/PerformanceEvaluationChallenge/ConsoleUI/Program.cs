using System;
using System.Diagnostics;
using System.Text;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "AddMe";
            long concatenateTime = 0;
            long stringBuilderTime = 0;
            int concateRepetitionNumber = 500;
            int appendRepetitionNumber = 500;

            concatenateTime = GetConcatenatePerformanceTime(concateRepetitionNumber, text);
            PrintConcatenatePerformance(concateRepetitionNumber, concatenateTime);

            concateRepetitionNumber = 5000;
            concatenateTime = GetConcatenatePerformanceTime(concateRepetitionNumber, text);
            PrintConcatenatePerformance(concateRepetitionNumber, concatenateTime);

            concateRepetitionNumber = 50000;
            concatenateTime = GetConcatenatePerformanceTime(concateRepetitionNumber, text);
            PrintConcatenatePerformance(concateRepetitionNumber, concatenateTime);

            stringBuilderTime = GetStringBuilderPerformanceTime(appendRepetitionNumber, text);
            PrintStringBuilderPerformance(appendRepetitionNumber, stringBuilderTime);

            appendRepetitionNumber = 5000;
            stringBuilderTime = GetStringBuilderPerformanceTime(appendRepetitionNumber, text);
            PrintStringBuilderPerformance(appendRepetitionNumber, stringBuilderTime);

            appendRepetitionNumber = 50000;
            stringBuilderTime = GetStringBuilderPerformanceTime(appendRepetitionNumber, text);
            PrintStringBuilderPerformance(appendRepetitionNumber, stringBuilderTime);
        }

        static StringBuilder AppendText(int repetitionNumber, string text)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < repetitionNumber; i++)
            {
                stringBuilder.Append(text);
            }

            return stringBuilder;
        }

        static string ConcatenateText(int repetitionNumber, string text)
        {
            string newString = "";

            for (int i = 0; i < repetitionNumber; i++)
            {
                newString = string.Concat(newString, text);
            }

            return newString;
        }

        static long GetConcatenatePerformanceTime(int repetitionNumber, string text)
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            ConcatenateText(repetitionNumber, text);
            stopWatch.Stop();

            return stopWatch.ElapsedMilliseconds;
        }

        static long GetStringBuilderPerformanceTime(int repetitionNumber, string text)
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            AppendText(repetitionNumber, text);
            stopWatch.Stop();

            return stopWatch.ElapsedMilliseconds;
        }

        static void PrintConcatenatePerformance(int repetitionNumber, long stopWatchMilliseconds)
        {
            Console.WriteLine($"Append Text { repetitionNumber } rep: { stopWatchMilliseconds } ms");
        }

        static void PrintStringBuilderPerformance(int repetitionNumber, long stopWatchMilliseconds)
        {
            Console.WriteLine($"String builder { repetitionNumber } rep: { stopWatchMilliseconds } ms");
        }
    }
}
