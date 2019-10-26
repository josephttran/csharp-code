using System.Collections.Generic;
using System.IO;

namespace CalculationsLibrary
{
    public class WriteText: IWriteText
    {
        public void WriteAllText(string fileName, List<string> lines)
        {
            File.WriteAllLines(fileName, lines);
        }
    }
}
