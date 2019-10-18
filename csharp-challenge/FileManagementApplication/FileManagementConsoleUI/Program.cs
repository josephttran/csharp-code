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

            //CopyAllFiles(sourceDirectoryPath, targetDirectoryPath);
            CopyAllSubFoldersAndFiles(sourceDirectoryPath, targetDirectoryPath);
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
                    Console.WriteLine(fileName);
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

        static void CopyAllSubFoldersAndFiles(string source, string target)
        {
            DirectoryInfo root = new DirectoryInfo(source);
            List<DirectoryInfo> directories = new List<DirectoryInfo>();
            List<FileInfo> filesPath = new List<FileInfo>();

            TraverseSubDirectories(root, directories, filesPath);

            // Create directories for copy files
            if (directories != null)
            {
                foreach (var directory in directories)
                {
                    string sourceDirectoryFullPath = Path.GetFullPath(source);
                    string sourceDirectoryRelativePath = directory.FullName.Substring(sourceDirectoryFullPath.Length + 1);
                    string targetDirectoryPath = Path.Combine(Path.GetFullPath(target), sourceDirectoryRelativePath);

                    if (!Directory.Exists(targetDirectoryPath))
                    {
                        Directory.CreateDirectory(targetDirectoryPath);
                    }
                }
            }

            // Copy files
            if (filesPath != null)
            {
                foreach (var file in filesPath)
                {
                    string sourceDirectoryPath = Path.GetFullPath(source);
                    string fileName = file.FullName.Substring(sourceDirectoryPath.Length + 1);

                    string sourceFilePath = Path.Combine(source, fileName);
                    string targetFilePath = Path.Combine(target, fileName);

                    if (!File.Exists(targetFilePath))
                    {
                        File.Copy(sourceFilePath, targetFilePath);
                    }
                }
            }
        }

        // Recursive get all sub directories and files
        static void TraverseSubDirectories(DirectoryInfo root, List<DirectoryInfo> directories, List<FileInfo> filesPath)
        {
            try
            {
                DirectoryInfo[] subDirectories = root.GetDirectories();

                if (root.GetFiles() != null)
                {
                    foreach (var file in root.GetFiles())
                    {
                        filesPath.Add(file);
                    }
                }

                foreach (var subDirectory in subDirectories)
                {
                    directories.Add(subDirectory);
                    TraverseSubDirectories(subDirectory, directories, filesPath);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
