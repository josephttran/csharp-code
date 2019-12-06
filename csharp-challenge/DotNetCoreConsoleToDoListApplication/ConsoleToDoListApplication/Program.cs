using System;

namespace ConsoleToDoListApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("####################################");
            Console.WriteLine("The Todo List Application");
            Console.WriteLine("Here is a list of available actions:");
            Console.WriteLine("####################################");
            Console.WriteLine("Print");
            Console.WriteLine("Print all");
            Console.WriteLine("Add <todo>");
            Console.WriteLine("Done <todo number>");
            Console.WriteLine("Clear");
            Console.WriteLine("Help");
            Console.WriteLine("Exit");
            Console.WriteLine("\nEnter an action: ");
        }


    }
}
