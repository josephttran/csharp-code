using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            (string firstTupleText, string secondTupleText) = UseTupleExample();

            UseOutParameterExample(out string firstOutText, out string secondOutText);

            Console.WriteLine($"Using out parameter: { firstOutText }, { secondOutText }");
            Console.WriteLine($"Using tuple: { firstTupleText }, { secondTupleText }");
        }

        static void UseOutParameterExample(out string firstOutText, out string secondOutText)
        {
            firstOutText = "first out parameter text";
            secondOutText = "second out parameter text";
        }

        static (string firstText, string secondText) UseTupleExample()
        {
            return ("first item", "second item");
        }
    }
}
