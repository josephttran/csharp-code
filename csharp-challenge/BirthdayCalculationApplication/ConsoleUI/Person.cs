using System;

namespace ConsoleUI
{
    class Person
    {
        public DateTime Birthday { get; set; }

        public int AgeInYears { get; private set; }

        public int AgeInMonths { get; private set; }

        public int AgeInDays { get; private set; }

        public Person(DateTime birthday)
        {
            Birthday = birthday;
            AgeInYears = AgeHelper.CalculateAgeInYears(Birthday);
            AgeInMonths = AgeHelper.CalculateAgeInMonths(Birthday);
            AgeInDays = AgeHelper.CalculateAgeInDays(Birthday);
        }
    }
}
