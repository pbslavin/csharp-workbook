using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PigLatin
{
    class Program
    {
        public static void Main()
        {   
            Console.WriteLine("Please enter an English sentence:");
            string sentence = Console.ReadLine().ToLower();
            string [] words = sentence.Split(' ');
            List<string> translatedSentenceList = new List<string>();
            foreach (string word in words)
            {
                translatedSentenceList.Add(TranslateWord(word));
            }
            string translatedSentence = String.Join(" ", translatedSentenceList.ToArray());
            Console.WriteLine(translatedSentence);
            Console.ReadLine();
        }

        public static string TranslateWord(string pword)
        {   
            Dictionary<int, string> punctDict = new Dictionary<int, string>();
            string word = "";
            for (int i = 0; i < pword.Length; i ++)
            {
                if (Char.IsPunctuation(pword[i]))
                {
                    punctDict.Add(i, pword[i].ToString());
                } else {
                    word += pword[i].ToString();
                }
            }
            
            char [] vowels = new char [] {'a', 'e', 'i', 'o', 'u'};
            int vowelIndex = -1;
            if ((word.IndexOfAny(vowels) > -1 && word.IndexOfAny(vowels) < vowelIndex) || vowelIndex == -1) {
                vowelIndex = word.IndexOfAny(vowels);
            }
            string firstPart = word.Substring(0, vowelIndex);
            string secondPart = word.Substring(vowelIndex);
            if (word.Length == secondPart.Length) 
            {
                pword = word + "yay";
            } else {
                pword = secondPart + firstPart + "ay";
            }
            foreach (var key in punctDict.Keys)
            {
                if (key < word.Length)
                {
                    pword = pword.Insert(key, punctDict[key]);
                } else {
                    pword = pword + punctDict[key];
                }
            }
            return pword;
        }
    }
}
