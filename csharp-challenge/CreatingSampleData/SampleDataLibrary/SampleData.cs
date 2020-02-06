using System;
using System.Collections.Generic;
using System.Text;

namespace SampleDataLibrary
{
    public class SampleData
    {
        public static bool CreateRandomBoolean()
        {
            Random random = new Random();
            bool randomBool = random.NextDouble() > 0.5;
            return randomBool;
        }

        public static int CreateRandomInteger(int minRange, int maxRange)
        {
            Random random = new Random();
            int randomInteger = random.Next(minRange, maxRange + 1);
            return randomInteger;
        }
    }
}
