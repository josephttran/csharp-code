using System;
using System.Collections.Generic;
using System.IO;

namespace FileManagementConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceDirectoryPath = @"..\..\..\Folder1";
            string targetDirectoryPath = @"..\..\..\Folder2";

            CopyAllFiles(sourceDirectoryPath, targetDirectoryPath);
        }

        static void CopyAllFiles(string source, string target)
        {
            try
            {
                IEnumerable<string> files = Directory.EnumerateFiles(source);

                if (!Directory.Exists(target))
                {
                    Directory.CreateDirectory(target);
                }

                foreach (string file in files)
                {
                    string fileName = file.Substring(source.Length + 1);

                    string sourceFilePath = Path.Combine(source, fileName);
                    string targetFilePath = Path.Combine(target, fileName);

                    if (!File.Exists(targetFilePath))
                    {
                        File.Copy(sourceFilePath, targetFilePath);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
