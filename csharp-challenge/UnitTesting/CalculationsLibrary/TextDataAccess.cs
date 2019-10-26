using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CalculationsLibrary
{
    public class TextDataAccess
    {
        private IWriteText WriteText { get; set; }

        public TextDataAccess(IWriteText writeText)
        {
            WriteText = writeText;
        }

        public void SaveText(string filePath, List<string> lines)
        {
            if (filePath.Length > 260)
            {
                throw new PathTooLongException("The path needs to be less than 261 characters long.");
            }

            string fileName = Path.GetFileName(filePath);

            WriteText.WriteAllText(fileName, lines);
        }
    }
}
