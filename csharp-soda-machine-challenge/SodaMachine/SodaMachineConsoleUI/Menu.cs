using System;
using System.Collections.Generic;

namespace SodaMachineConsoleUI
{
    class Menu
    {
        public List<string> MenuItems { get; set; }
        public string MenuHeader { get; set; }

        public Menu()
        {
            MenuHeader = "Soda Machine Menu";
            MenuItems = new List<string>()
            {
                "1) List types of sodas",
                "2) List soda in stock",
                "3) Get soda price",
                "4) Insert money",
                "5) Current amount of money inserted",
                "6) Buy a soda",
                "7) Issuse refund"
            };
        }

        public void PrintMenu()
        {
            PrintHeader();
            PrintAllMenuItems();
            Console.WriteLine();
            PromptUserForChoice();
        }

        private void PrintHeader()
        {
            Console.WriteLine("#########################");
            Console.WriteLine($"  { MenuHeader }  ");
            Console.WriteLine("#########################");
        }

        private void PrintAllMenuItems()
        {
            foreach(string item in MenuItems)
            {
                Console.WriteLine(item);
            }
        }

        private void PromptUserForChoice()
        {
            Console.Write($"Enter your choice(1 - { MenuItems.Count }): ");
        }
    }
}
