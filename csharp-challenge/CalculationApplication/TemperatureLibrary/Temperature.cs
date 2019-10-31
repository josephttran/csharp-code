using System;
using System.Collections.Generic;
using System.Linq;

namespace TemperatureLibrary
{
    public class Temperature: ITemperature
    {
        public List<int> Temperatures { get; private set; }

        public double? Average
        {
            get
            {
                if (Temperatures.Count == 0)
                {
                    return null;
                }

                return Math.Round((double)Temperatures.Sum() / Temperatures.Count, 2);
            }
        }

        public int? Maximum
        {
            get
            {
                if (Temperatures.Count == 0)
                {
                    return null;
                }

                return Temperatures.Max();
            }
        }

        public int? Minimum
        {
            get
            {
                if (Temperatures.Count == 0)
                {
                    return null;
                }

                return Temperatures.Min();
            }
        }

        public Temperature()
        {
            Temperatures = new List<int>();
        }

        public void Insert(int temperature)
        {
            if (temperature > 0 && temperature < 101)
            {
                Temperatures.Add(temperature);
            }
            else
            {
                Console.WriteLine("Cannot insert " + temperature);
            }
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
            }
            else
            {
                Console.WriteLine("Cannot insert " + temperature);
            }
        }
    }
}
