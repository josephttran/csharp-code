using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationsLibrary
{
    public interface IWriteText
    {
        void WriteAllText(string fileName, List<string> lines);
    }
}
