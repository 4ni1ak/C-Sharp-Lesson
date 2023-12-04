using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Please enter the directory path (exp, C:\\): ");
        string rootPath = Console.ReadLine();

        if (Directory.Exists(rootPath))
        {
            Console.Write("Please enter the depth level");
            string depthInput = Console.ReadLine();

            int maxDepth;
            if (int.TryParse(depthInput, out maxDepth))
            {
                string outputPath = "FileHierarchy.txt";

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    DirectoryInfo rootDirectory = new DirectoryInfo(rootPath);
                    WriteDirectoryTree(rootDirectory, writer, maxDepth);
                }

                Console.WriteLine($"File hierarchy successfully saved to {outputPath}");
            }
            else
            {
                Console.WriteLine("Invalid depth level. Going to the deepest level.");
            }
        }
        else
        {
            Console.WriteLine("The specified directory could not be found.");
        }
    }

    static void WriteDirectoryTree(DirectoryInfo directory, StreamWriter writer, int maxDepth, string indent = "")
    {
        if (maxDepth != 0)
        {
            writer.WriteLine($"{indent}[{directory.Name}]");

            foreach (FileInfo file in directory.GetFiles())
            {
                writer.WriteLine($"{indent}  {file.Name}");
            }

            foreach (DirectoryInfo subDirectory in directory.GetDirectories())
            {
                WriteDirectoryTree(subDirectory, writer, maxDepth - 1, indent + "  ");
            }
        }
    }
}