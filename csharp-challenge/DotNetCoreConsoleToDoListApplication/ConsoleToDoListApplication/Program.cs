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

        static void ShowHelp()
        {
            Console.WriteLine($"\n{"Command", -15} Command Information");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"{"Add", -15} Add a todo task");
            Console.WriteLine($"{"", -19} <todo> is your task");
            Console.WriteLine($"{"Clear",-15} Remove all items in todo list");
            Console.WriteLine($"{"Done",-15} Mark the task to done");
            Console.WriteLine($"{"", -19} <todo number> is id of task");
            Console.WriteLine($"{"Exit",-15} Quit the program");
            Console.WriteLine($"{"Print", -15} Display top 3 task in todo list");
            Console.WriteLine($"{"Print all", -15} Display all tasks in todo list");
        }

    }
}
