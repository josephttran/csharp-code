using System;
using System.Collections.Generic;
using System.Linq;

namespace TemperatureLibrary
{
    public class Temperature
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
