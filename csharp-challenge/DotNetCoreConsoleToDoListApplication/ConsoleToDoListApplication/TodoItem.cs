using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleToDoListApplication
{
    class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; } = false;

        public void Display()
        {
            Console.WriteLine($"Id: {Id} ");
            Console.WriteLine($"Todo: {Name} ");
            Console.WriteLine($"Done?: {Done} ");
        }
    }
}
