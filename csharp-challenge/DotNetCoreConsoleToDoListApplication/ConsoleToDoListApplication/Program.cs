using System;
using System.Collections.Generic;

namespace ConsoleToDoListApplication
{
    class Program
    {
        static List<TodoItem> todoList = new List<TodoItem>();

        static void Main(string[] args)
        {
            Menu();
        }

        static void Add(TodoItem todoItem)
        {
            todoList.Add(todoItem);
        }

        static void Clear()
        {
            todoList.Clear();
        }

        static void Done(int id)
        {
            if (todoList[id] != null)
            {
                todoList[id].Done = true;
            }
            else
            {
                Console.WriteLine("\nInvalid Id");
            }
        }

        static void Exit()
        {
            Environment.Exit(0);
        }

        static void Menu()
        {
            Console.WriteLine("\n####################################");
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
            Console.Write("\nEnter an action: ");
        }

        static void Print()
        {
            if (todoList.Count > 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    todoList[i].Display();
                }
            }
            else
            {
                Console.WriteLine("Todo List is empty");
            }
        }

        static void PrintAll()
        {
            if (todoList.Count > 0)
            {
                foreach (TodoItem todoItem in todoList)
                {
                    todoItem.Display();
                }
            }
            else
            {
                Console.WriteLine("Todo List is empty");
            }
        }

        static void ShowHelp()
        {
            Console.WriteLine($"\n{"Command", -15} Command Information");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"{"Add", -15} Add a todo task");
            Console.WriteLine($"{"", -19} <todo> is your task");
            Console.WriteLine($"{"Clear", -15} Remove all items in todo list");
            Console.WriteLine($"{"Done", -15} Mark the task to done");
            Console.WriteLine($"{"", -19} <todo number> is id of task");
            Console.WriteLine($"{"Exit", -15} Quit the program");
            Console.WriteLine($"{"Print", -15} Display top 3 task in todo list");
            Console.WriteLine($"{"Print all", -15} Display all tasks in todo list");
        }
    }
}
