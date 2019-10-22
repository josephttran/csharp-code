using NUnit.Framework;
using System;
using System.Diagnostics;

namespace ActionMethod.Tests
{
    [TestFixture]
    public class PerformanceEvaluationTests
    {
        [Test]
        public void ExecuteTest()
        {
            int[] stringRepetitionNumbers = new int[] { 500, 5000, 50000 };
            int[] numberRepetitionNumbers = new int[] { 500000, 5000000 };
            string text = "newtext";
            double doubleNumber = 0.01;
            decimal decimalNumber = 0.01M;

            TestMethodPerformance<string>("String Concatenate", PerformanceEvaluation.UseStringConcatenate, stringRepetitionNumbers, text);
            TestMethodPerformance<string>("String Builder", PerformanceEvaluation.UseStringBuilder, stringRepetitionNumbers, text);
            TestMethodPerformance<double>("Double", PerformanceEvaluation.UseDouble, numberRepetitionNumbers, doubleNumber);
            TestMethodPerformance<decimal>("Decimal", PerformanceEvaluation.UseDecimal, numberRepetitionNumbers, decimalNumber);
        }

        public void TestMethodPerformance<T>(string description, Action<int, T> function, int[] repetitionList, T addOrAppend)
        {
            foreach (int repetitionNumber in repetitionList)
            {
                Stopwatch stopWatch = new Stopwatch();

                stopWatch.Start();
                function(repetitionNumber, addOrAppend);
                stopWatch.Stop();

                Assert.Greater(repetitionNumber, 0);
                Assert.That(stopWatch.ElapsedMilliseconds, Is.GreaterThanOrEqualTo(0));

                Console.WriteLine($"{ description } { repetitionNumber } rep: { stopWatch.ElapsedMilliseconds } ms");
            }
        }
    }
}