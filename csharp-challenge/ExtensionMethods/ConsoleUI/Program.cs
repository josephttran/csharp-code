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
        }
    }
}
