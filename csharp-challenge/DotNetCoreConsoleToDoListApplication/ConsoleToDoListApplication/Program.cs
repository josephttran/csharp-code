using System;
using System.Collections.Generic;

namespace ConsoleToDoListApplication
{
    class Program
    {
        static List<TodoItem> todoList = new List<TodoItem>();

        static void Main(string[] args)
        {
            while(true)
            {
                Menu();
                HandleUserInput();
            }
        }

        static void Add(TodoItem todoItem)
        {
            todoItem.Id = todoList.Count;
            todoList.Add(todoItem);
            Console.WriteLine($"{ todoItem.Name } added to todo list");
        }

        static void Clear()
        {
            todoList.Clear();
            Console.WriteLine("Todo list is now empty");
        }

        static void Done(int id)
        {
            if (id < todoList.Count && id > -1)
            {
                todoList[id].Done = true;
            }
            else
            {
                Console.WriteLine($"\nItem with id { id } does not exist");
            }
        }

        static void Exit()
        {
            Environment.Exit(0);
        }

        static void HandleUserInput()
        {
            string userCommand = Console.ReadLine();

            switch (userCommand.ToLower())
            {
                case string _ when userCommand.Length > 4 && userCommand.ToLower().Substring(0, 4) == "add ":
                    TodoItem todoItem = new TodoItem { Name = userCommand.Substring(4) };
                    Add(todoItem);
                    break;
                case "clear":
                    Clear();
                    break;
                case string _ when userCommand.Length > 5 && userCommand.ToLower().Substring(0, 5).Equals("done "):
                    if (int.TryParse(userCommand.Substring(5), out int id))
                    {
                        Done(id);
                    }
                    else
                    {
                        Console.WriteLine("\nNot valid id number!");
                    }

                    break;
                case "exit":
                    Exit();
                    break;
                case "help":
                    ShowHelp();
                    break;
                case "print":
                    Print();
                    break;
                case "print all":
                    PrintAll();
                    break;
                case string _ when userCommand.Length > 8 && userCommand.ToLower().Substring(0, 8).Equals("reorder "):
                    string[] positions = userCommand.Substring(8).Split(" ");

                    if (positions.Length == 2)
                    {
                        if (int.TryParse(positions[0], out int fromPosition) &&
                            int.TryParse(positions[1], out int toPosition)
                            )
                        {
                            ReOrder(fromPosition, toPosition);
                        }
                        else
                        {
                            Console.WriteLine("\nArguments are not valid!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nArguments are not valid!");
                    }

                    break;
                default:
                    Console.WriteLine("\nNot valid command!");
                    break;
            }
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
            Console.WriteLine("Reorder <item position> <new position>");
            Console.WriteLine("Clear");
            Console.WriteLine("Help");
            Console.WriteLine("Exit");
            Console.Write("\nEnter an action: ");
        }

        static void Print()
        {
            if (todoList.Count > 0)
            {
                if (todoList.Count < 3)
                {
                    foreach (var item in todoList)
                    {
                        item.Display();
                    }
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        todoList[i].Display();
                    }
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

        static void ReOrder(int fromPosition, int toPosition)
        {
            if (fromPosition > 0 &&
                fromPosition < todoList.Count &&
                toPosition > 0 &&
                toPosition < todoList.Count
                )
            {
                TodoItem todoItem = todoList[fromPosition];
                todoList.RemoveAt(fromPosition);
                todoList.Insert(toPosition, todoItem);
            }
            else
            {
                Console.WriteLine("\nInvalid position");
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
            Console.WriteLine($"{"Reorder, -15"} Move item by position in todo list");
        }
    }
}
