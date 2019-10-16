using System;

namespace ConsoleUI
{
    static class BirthdayHelper
    {
        public static int CalcluateNextBirthday(DateTime birthday)
        {
            int months;

            if (birthday.Month == DateTime.Now.Month && birthday.Day >= DateTime.Now.Day)
            {
                months = 12;
            }
            else if (birthday.Month == DateTime.Now.Month && birthday.Day < DateTime.Now.Day)
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
    }
}
