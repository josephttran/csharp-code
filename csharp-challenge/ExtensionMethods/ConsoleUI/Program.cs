using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            "Hello World.".Print();
            "Hello World.".Excite();

            Person person = new Person();

            person.Fill().Print();

            double initialNumber = 4.00;

            double chainNumber = initialNumber.Add(4).Subtract(2).MultiplyBy(8).DivideBy(3);

            Console.WriteLine($"\nThe calculated number is { chainNumber }");
        }
    }
}
