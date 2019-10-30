using System;
using System.Collections.Generic;
using System.Linq;

namespace TemperatureLibrary
{
    public class Temperature: ITemperature
    {
        public List<int> Temperatures { get; private set; }
        public double? Average { get; private set; } = null;
        public int? Maximum { get; private set; } = null;
        public int? Minimum { get; private set; } = null;

        public Temperature()
        {
            Temperatures = new List<int>();
        }

        public void Insert(int temperature)
        {
            Temperatures.Add(temperature);

            SetMinimum(temperature);
            SetMaximum(temperature);
            CalculateAverage();
        }
        public void Insert(string temperature)
        {
            Dictionary<string, int> wordToNumbers = new Dictionary<string, int>
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 },
                { "ten", 10 }
            };

            if (wordToNumbers.ContainsKey(temperature))
            {
                Temperatures.Add(wordToNumbers[temperature]);
                SetMinimum(wordToNumbers[temperature]);
                SetMaximum(wordToNumbers[temperature]);
                CalculateAverage();
            }
            else
            {
                Console.WriteLine("Cannot insert " + temperature);
            }
        }

        private void CalculateAverage()
        {
            Average = Math.Round((double)Temperatures.Sum() / Temperatures.Count, 2);
        }

        private void SetMaximum(int temperature)
        {
            if (!Maximum.HasValue)
            {
                Maximum = temperature;
            }
            else
            {
                if (Temperatures.Count == 0 || Maximum.Value.CompareTo(temperature) < 0)
                {
                    Maximum = temperature;
                }
            }
        }

        private void SetMinimum(int temperature)
        {
            if (!Minimum.HasValue)
            {
                Minimum = temperature;
            }
            else
            {
                if (Minimum.Value.CompareTo(temperature) > 0)
                {
                    Minimum = temperature;
                }
            }
        }
    }
}
