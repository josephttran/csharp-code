using System;
using System.IO;
using System.Text;

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

        public static string CreateRandomPhoneNumber()
        {
            string phoneNumberPattern = "(###) ###-####";
            StringBuilder randomPhoneNumber = new StringBuilder();
            Random random = new Random();

            for (int index = 0; index < phoneNumberPattern.Length; index++)
            {
                if (phoneNumberPattern[index].Equals('#'))
                {
                    randomPhoneNumber.Append(random.Next(0, 10));
                }
                else
                {
                    randomPhoneNumber.Append(phoneNumberPattern[index]);
                }

            }

            return randomPhoneNumber.ToString();
        }
        public static string CreateRandomZipcode()
        {
            StringBuilder randomZipcode = new StringBuilder();
            Random random = new Random();

            for (int index = 0; index < 5; index++)
            {
                randomZipcode.Append(random.Next(0, 10));
            }

            randomZipcode.Append("-");

            for (int index = 0; index < 4; index++)
            {
                randomZipcode.Append(random.Next(0, 10));
            }

            return randomZipcode.ToString();
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
