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

            AnotherMethod();
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

        static void AnotherMethod()
        {
            string anotherText;

            FirstModifyVariableWithoutReturn(out anotherText);
            Console.WriteLine($"First way modified variable: { anotherText }");

            SecondModifyVariableWithoutReturn(ref anotherText);
            Console.WriteLine($"Second way modified variable: { anotherText }");
        }

        static void FirstModifyVariableWithoutReturn(out string text)
        {
            text = "modified variable with out parameter";
        }

        static void SecondModifyVariableWithoutReturn(ref string text)
        {
            text = "modified variable with ref parameter";
        }
    }
}
