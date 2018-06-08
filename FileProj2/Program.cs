using System;
using System.IO;

namespace FileProj2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordsArray = File.ReadAllLines("./words_alpha.txt");
            Random rnd = new Random();
            int index = rnd.Next(0, wordsArray.Length - 1);
            string word = wordsArray[index];
            Console.WriteLine(word);
            Console.Write("Try to guess my word: ");
            string guessedWord = Console.ReadLine();
            string [] words = new string [] {guessedWord, word};
            Array.Sort(words);
            if (guessedWord == word)
            {
                Console.WriteLine("That's it!");
            }
            else if (words[0] == word)
            {
                Console.WriteLine("Your word is after my word.");
            }
            else
            {
                Console.WriteLine("Your word is before my word.");
            }
        }
    }
}
