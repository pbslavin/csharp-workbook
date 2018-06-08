using System;

using System.IO;

namespace FileProj
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"./file1.txt";
            string path2 = @"./file2.txt";
            File.WriteAllText(path, "This is a text file.");
            Console.WriteLine(File.ReadAllText(path));
            File.WriteAllText(path, "This is a text file, and I can edit it.");
            Console.WriteLine(File.ReadAllText(path));
            File.Delete(path);
            File.WriteAllText(path2, "This is another text file.");
            string words = File.ReadAllText(path2);
            Console.WriteLine($"The number of words in file2.txt is {words.Split(" ").Length}.");
            string [] wordsArray = words.Split(" ");
            string max = "";
            foreach (string word in wordsArray)
            {
                if (word.Length > max.Length)
                {
                    max = word;
                }
            }
            Console.WriteLine($"The longest word in file2.txt is {max}");
        }
    }
}
