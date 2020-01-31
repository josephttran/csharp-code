using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //string primaryFilesDirectoryPath = @"..\..\..\PrimaryChallengeFiles";
            //string renamePrimaryFilesDirectoryPath = @"..\..\..\RenamePrimaryChallengeFiles";
            string bonusFilesDirectoryPath = @"..\..\..\BonusChallengeFiles";
            string renameBonusFilesDirectoryPath = @"..\..\..\RenameBonusChallengeFiles";

            //RenamePrimaryChallengeFiles(primaryFilesDirectoryPath, renamePrimaryFilesDirectoryPath);
            RenameBonusChallengeFiles(bonusFilesDirectoryPath, renameBonusFilesDirectoryPath);

            Console.WriteLine("Renaming done");
        }

        static void RenameBonusChallengeFiles(string bonusFilesDirectoryPath, string renameBonusFilesDirectoryPath)
        {
            IEnumerable<string> files = Directory.EnumerateFiles(bonusFilesDirectoryPath);

            if (files != null)
            {
                if (!Directory.Exists(renameBonusFilesDirectoryPath))
                {
                    Directory.CreateDirectory(renameBonusFilesDirectoryPath);
                }

                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    StreamReader streamReader = fileInfo.OpenText();
                    string firstLine = streamReader.ReadLine();
                    string extension = fileInfo.Extension;
                    string renameFile = firstLine + extension;
                    string renameFilePath = Path.Combine(renameBonusFilesDirectoryPath, renameFile);

                    streamReader.Close();

                    if (File.Exists(renameFilePath))
                    {
                        File.Delete(renameFilePath);
                    }

                    fileInfo.CopyTo(renameFilePath, true);
                }
            }
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
