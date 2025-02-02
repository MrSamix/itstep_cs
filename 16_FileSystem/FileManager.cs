using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_FileSystem
{
    internal class FileManager
    {
        public string Path { get; set; }

        public FileManager(string path)
        {
            Path = path;
            Directory.SetCurrentDirectory(path);
            Console.WriteLine("Directory path: " + Directory.GetCurrentDirectory());
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("Menu: \n[1] Create Directory\n[2] Delete Directory\n[3] View Directory Contents\n[4] Delete File\n[5] Move File\n[6] View File Info\n[7] Change Directory\n[0] Exit");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        CreateDirectory();
                        break;
                    case "2":
                        DeleteDirectory();
                        break;
                    case "3":
                        ViewDirectoryContents();
                        break;
                    case "4":
                        DeleteFile();
                        break;
                    case "5":
                        MoveFile();
                        break;
                    case "6":
                        ViewFileInfo();
                        break;
                    case "7":
                        ChangeDirectory();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void CreateDirectory()
        {
            Console.Write("Enter directory name: ");
            string dirName = Console.ReadLine()!;
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("This folder is exist? Overrite it?");
                var choice = Console.ReadKey().Key;
                if (choice == ConsoleKey.Y)
                {
                    Directory.Delete(dirName, true);
                    Directory.CreateDirectory(dirName);
                    Console.WriteLine("\nDirectory " + dirName + " was overrided!");
                }
                else
                {
                    Console.WriteLine("Folder not overrided!!!");
                }
            }
            else
            {
                Directory.CreateDirectory(dirName);
                Console.WriteLine(dirName + " created");
            }
        }

        private void DeleteDirectory()
        {
            Console.Write("Enter directory name: ");
            string dirName = Console.ReadLine()!;
            if (!Directory.Exists(dirName))
            {
                Console.WriteLine(dirName + " not founded!");
            }
            else
            {
                if (Directory.GetFiles(dirName).Length > 0)
                {
                    Console.WriteLine(dirName + " folder have a " + Directory.GetFiles(dirName).Length + " files! Delete?(y/n)");
                    var choice = Console.ReadKey().Key;
                    if (choice == ConsoleKey.Y)
                    {
                        Directory.Delete(dirName, true);
                        Console.WriteLine("\n" + dirName + " deleted");
                    }
                    else
                    {
                        Console.WriteLine("\nDirectory not deleted!");
                    }
                }
                else
                {
                    Directory.Delete(dirName);
                    Console.WriteLine(dirName + " deleted");
                }
            }
        }

        private void ViewDirectoryContents()
        {
            Console.WriteLine("Contents of directory:");
            Console.OutputEncoding = Encoding.UTF8;
            var entries = Directory.GetFileSystemEntries(".");
            Console.WriteLine($"\n\n ---------- {Path}");
            foreach (var e in entries)
            {
                FileInfo fi = new FileInfo(e);
                string info = "<DIR>";
                if (!fi.Attributes.HasFlag(FileAttributes.Directory))
                {
                    info = fi.Length.ToString();
                }
                Console.WriteLine($"{fi.CreationTime,-22} {fi.Name,-30} {info,-15}");
            }
        }

        private void DeleteFile()
        {
            Console.Write("Enter file name: ");
            string fileName = Console.ReadLine()!;
            File.Delete(fileName);
            Console.WriteLine("File deleted.");
        }

        private void MoveFile()
        {
            Console.Write("Enter file name: ");
            string fileName = Console.ReadLine()!;
            Console.Write("Enter destination directory: ");
            string destDir = Console.ReadLine()!;
            string destPath = System.IO.Path.Combine(destDir, fileName);
            File.Move(fileName, destPath);
            Console.WriteLine("File moved.");
        }

        private void ViewFileInfo()
        {
            Console.Write("Enter file name: ");
            string fileName = Console.ReadLine()!;
            FileInfo fileInfo = new FileInfo(fileName);
            Console.WriteLine($"File Info:\nName: {fileInfo.Name}\nSize: {fileInfo.Length} bytes\nCreated: {fileInfo.CreationTime}");
        }

        private void ChangeDirectory()
        {
            Console.Write("Enter new directory path: ");
            string newPath = Console.ReadLine()!;
            if (Directory.Exists(newPath))
            {
                Directory.SetCurrentDirectory(newPath);
                Path = Directory.GetCurrentDirectory();
                Console.WriteLine("Current directory changed to: " + Path);
            }
            else
            {
                Console.WriteLine("Directory does not exist.");
            }
        }

    }
}
