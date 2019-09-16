using System;
using System.Collections.Generic;
using System.Text;

namespace ActionMethod
{
    public class PerformanceEvaluation
    {
        static public void UseStringBuilder(int repetitionNumber, string text)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < repetitionNumber; i++)
            {
                stringBuilder.Append(text);
            }
        }

        static public void UseStringConcatenate(int repetitionNumber, string text)
        {
            string newString = "";

            for (int i = 0; i < repetitionNumber; i++)
            {
                newString = string.Concat(newString, text);
            }
        }

        static public void UseDouble(int repetitionNumber, double number)
        {
            double myDouble = 0.00;

            for (int i = 0; i < repetitionNumber; i++)
            {
                myDouble +=  number;
            }
        }

        static public void UseDecimal(int repetitionNumber, decimal number)
        {
            decimal myDecimal = 0.00M;

            for (int i = 0; i < repetitionNumber; i++)
            {
                myDecimal = Decimal.Add(myDecimal, number);
            }
        }
    }
}
