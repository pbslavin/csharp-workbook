using System;

namespace PigLatin
{
    class Program
    {
        public static void Main()
        {   
            Console.WriteLine("Please enter an English word: ");
            string word = Console.ReadLine().ToLower();
            int vowelIndex = -1;
            if ((word.IndexOf('a') > -1 && word.IndexOf('a') < vowelIndex) || vowelIndex == -1) {
                vowelIndex = word.IndexOf('a');
            }
            if ((word.IndexOf('e') > -1 && word.IndexOf('e') < vowelIndex) || vowelIndex == -1) {
                vowelIndex = word.IndexOf('e');
            }
            if ((word.IndexOf('i') > -1 && word.IndexOf('i') < vowelIndex) || vowelIndex == -1) {
                vowelIndex = word.IndexOf('i');
            }
            if ((word.IndexOf('o') > -1 && word.IndexOf('o') < vowelIndex) || vowelIndex == -1) {
                vowelIndex = word.IndexOf('o');
            }
            if ((word.IndexOf('u') > -1 && word.IndexOf('u') < vowelIndex) || vowelIndex == -1) {
                vowelIndex = word.IndexOf('u');
            }
            string firstPart = word.Substring(0, vowelIndex);
            string secondPart = word.Substring(vowelIndex);
            if (word.Length == secondPart.Length) 
            {
                word += "yay";
            } else {
                word = secondPart + firstPart + "ay";
            }
            Console.WriteLine(word);

            Console.ReadLine();
        }
        
        public static string TranslateWord(string word)
        {
            // your code goes here
            return word;
        }
    }
}
