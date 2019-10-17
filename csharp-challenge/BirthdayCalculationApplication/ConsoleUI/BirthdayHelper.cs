using System;

namespace ConsoleUI
{
    static class BirthdayHelper
    {
        public static int CalcluateNextBirthday(DateTime birthday)
        {
            int months;

            if (birthday.Month == DateTime.Now.Month && birthday.Day <= DateTime.Now.Day)
            {
                months = 12;
            }
            else if (birthday.Month == DateTime.Now.Month && birthday.Day > DateTime.Now.Day)
            {
                months = 0;
            }
            else if (birthday.Month > DateTime.Now.Month)
            {
                months = birthday.Month - DateTime.Now.Month;
            }
            else
            {
                months = 12 - (DateTime.Now.Month - birthday.Month);
            }

            return months;
        }

        public static int CalcluateWeekendsUntilNextBirthday(DateTime birthday)
        {
            int weekends = 0;
            DateTime nextBirthDay;
            DateTime tempDate = DateTime.Now;

            if (birthday.Month < DateTime.Now.Month || birthday.Month == DateTime.Now.Month && birthday.Day <= DateTime.Now.Day)
            {
                nextBirthDay = new DateTime(DateTime.Now.Year + 1, birthday.Month, birthday.Day);
            }
            else
            {
                nextBirthDay = new DateTime(DateTime.Now.Year, birthday.Month, birthday.Day);
            }

            while (tempDate <= nextBirthDay)
            {
                tempDate = tempDate.AddDays(1);

                if (tempDate.DayOfWeek.ToString().ToLower() == "saturday")
                {
                    weekends++;
                }
            }

            return weekends;
        }
    }
}
