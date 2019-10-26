using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationsLibrary.Tests
{
    class FakeWriteText: IWriteText
    {
        public bool Done { get; set; }

        public void WriteAllText(string fileName, List<string> lines)
        {
            Console.WriteLine(fileName);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            Done = true;
        }
    }
}
