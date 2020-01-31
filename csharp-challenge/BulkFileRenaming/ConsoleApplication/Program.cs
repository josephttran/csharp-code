using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string primaryFilesDirectoryPath = @"..\..\..\PrimaryChallengeFiles";
            string renamePrimaryFilesDirectoryPath = @"..\..\..\RenamePrimaryChallengeFiles";

            RenamePrimaryChallengeFiles(primaryFilesDirectoryPath, renamePrimaryFilesDirectoryPath);

            Console.WriteLine("Renaming done");
        }

        static void RenamePrimaryChallengeFiles(string primaryFilesDirectoryPath, string renamePrimaryFilesDirectoryPath)
        {
            string search = "acme";
            string replaceWith = "TimCo";
            IEnumerable<string> files = Directory.EnumerateFiles(primaryFilesDirectoryPath);

            if (files != null)
            {
                if (!Directory.Exists(renamePrimaryFilesDirectoryPath))
                {
                    Directory.CreateDirectory(renamePrimaryFilesDirectoryPath);
                }

                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    string fileName = Path.GetFileNameWithoutExtension(fileInfo.Name);
                    string extension = fileInfo.Extension;

                    string renameFile = StringRename.ToTitleCase(fileName);
                    renameFile = StringRename.ReplaceExact(renameFile, search, replaceWith);
                    renameFile = renameFile + extension;

                    string renameFilePath = Path.Combine(renamePrimaryFilesDirectoryPath, renameFile);

                    if (File.Exists(renameFilePath))
                    {
                        File.Delete(renameFilePath);
                    }

                    fileInfo.CopyTo(renameFilePath, true);
                }
            }
        }


    }
}
