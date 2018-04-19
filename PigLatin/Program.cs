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
            string sentence = Console.ReadLine();
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
            // create dictionary of all existing punctuation marks with their original indices as keys, and a copy of the word string with all punctuation removed
            Dictionary<int, string> punctDict = new Dictionary<int, string>();
            bool capitalized = false;
            string word = "";
            int lastLetterIndex = 0;
            int firstLetterIndex = -1;
            int upToLastLetter;
            for (int i = 0; i < pword.Length; i ++)
            {
                if (Char.IsPunctuation(pword[i]))
                {

                    punctDict.Add(i, pword[i].ToString());
                } else {                    
                    if (firstLetterIndex == -1) 
                    {
                        // set firstLetterIndex
                        firstLetterIndex = i;
                    }
                    word += pword[i].ToString();
                    lastLetterIndex = i;
                }
            }
            // return original 'word' if only punctuation surrounded by spaces (like a dash)
            if (firstLetterIndex == -1) 
            {
                return pword;
            }
            if (Char.IsUpper(pword, firstLetterIndex)) 
            {
                capitalized = true;
            }
            word = word.ToLower();
            upToLastLetter = pword.Substring(0, lastLetterIndex).Length;
            // translate the original word, minus any punctuation
            char [] vowels = new char [] {'a', 'e', 'i', 'o', 'u'};
            int vowelIndex = -1;
            if ((word.IndexOfAny(vowels) > -1 && word.IndexOfAny(vowels) < vowelIndex) || vowelIndex == -1) 
            {
                vowelIndex = word.IndexOfAny(vowels);
            }
            if (vowelIndex == -1) 
            {
                // if there are no vowels except 'y', break word on the 'y'
                if (word.IndexOf('y') > -1)
                {
                    vowelIndex = word.IndexOf('y');
                } else {
                    vowelIndex = 0;
                }
            }
            string firstPart = word.Substring(0, vowelIndex);
            string secondPart = word.Substring(vowelIndex);
            if (word.Length == secondPart.Length) 
            {
                pword = word + "yay";
            } else {
                pword = secondPart + firstPart + "ay";
            }
            // reinsert all punctuation, either at its original index, or after the ending
            foreach (var key in punctDict.Keys)
            {
                // if punctuation appeared before the last letter,
                if (key < upToLastLetter)
                {
                    // and it's not an apostrophe, or it appears before the first letter in the word, or the word begins with a vowel, 
                    if (punctDict[key] != "'" || key < firstLetterIndex || word.IndexOfAny(vowels) == 0) 
                    {
                        // insert mark at original index in word;
                        pword = pword.Insert(key, punctDict[key]); 
                    } else {
                        // if an apostrophe, insert before the letter it originally preceded
                        pword = pword.Insert(key - vowelIndex, punctDict[key]); 
                    }
                // if an apostrophe at end of word, insert after letter it originally followed    
                } else if (punctDict[key] == "'" && pword[0].ToString() != "'") {
                    pword = pword.Insert(key - vowelIndex, punctDict[key]); 
                } else {
                    // otherwise, if punctuation at end of original word, place after 'ay' or 'yay'
                    pword = pword + punctDict[key]; 
                }
            }
            // re-capitalize words, including those whose capitalized first letter occurs after one or more punctuation marks
            if (capitalized) 
            {   
                pword = pword.Substring(0, firstLetterIndex) + pword[firstLetterIndex].ToString().ToUpper() + pword.Substring(firstLetterIndex + 1, pword.Length - firstLetterIndex - 1);
            }
            return pword;
        }
    }
}
