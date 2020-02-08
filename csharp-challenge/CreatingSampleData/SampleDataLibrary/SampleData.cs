﻿using System;
using System.IO;

namespace SampleDataLibrary
{
    public static class SampleData
    {
        public static string CreateFullName()
        {
            string firstName = GetRandomFirstName();
            string lastName = GetRandomLastName();

            string fullName = $"{ firstName } { lastName }";

            return fullName;
        }

        public static bool CreateRandomBoolean()
        {
            Random random = new Random();
            bool randomBool = random.NextDouble() > 0.5;
            return randomBool;
        }

        // Max exclusive
        public static double CreateRandomDouble(double minRange, double maxRange)
        {
            Random random = new Random();
            double randomDouble = random.NextDouble() * (maxRange - minRange) + minRange;
            return randomDouble;
        }

        // Max inclusive
        public static int CreateRandomInteger(int minRange, int maxRange)
        {
            Random random = new Random();
            int randomInteger = random.Next(minRange, maxRange + 1);
            return randomInteger;
        }

        public static string GetRandomFirstName()
        {
            string firstNamePath = @".\TextData\firstName.txt";

            string[] firstNames = File.ReadAllLines(firstNamePath);

            Random random = new Random();
            int randomIndex = random.Next(firstNames.Length);
            string randomFirstName = firstNames[randomIndex];

            return randomFirstName;
        }

        public static string GetRandomLastName()
        {
            string lastNamePath = @".\TextData\lastName.txt";

            string[] lastNames = File.ReadAllLines(lastNamePath);

            Random random = new Random();
            int randomIndex = random.Next(lastNames.Length);
            string randomLastName = lastNames[randomIndex];

            return randomLastName;
        }

    }
}
