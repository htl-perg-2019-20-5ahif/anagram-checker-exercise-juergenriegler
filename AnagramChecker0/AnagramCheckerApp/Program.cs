using System;
using System.Collections.Generic;
using System.Linq;
using AnagramCheckerLogic;

namespace AnagramCheckerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectMode(args);
        }

        static void SelectMode(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Enter check to check two words for anagrams or getKnown for finding a words anagram.");
                return;
            }
            switch (args[0].ToUpper())
            {
                case "CHECK":
                    CheckForAnagram(args.Skip(1));
                    break;
                case "GETKNOWN":
                    GetKnownAnagram(args.Skip(1));
                    break;
            }
        }

        static void CheckForAnagram(IEnumerable<string> words)
        {
            if (words.Count() < 2)
            {
                Console.WriteLine("CHECK: two words are required for anagram comparison");
                return;
            }
            string w1 = words.ElementAt(0);
            string w2 = words.ElementAt(1);
            ITwoWordChecker twoWordChecker = new TwoAnagramChecker();
            if (twoWordChecker.checkTwoWords(w1, w2))
                Console.WriteLine(w1 + " and " + w2 + " are anagrams");
            else 
                Console.WriteLine(w1 + " and " + w2 + " are no anagrams");
        }


        static void GetKnownAnagram(IEnumerable<string> words)
        {
            Console.WriteLine("GETKNOWN: oen word is required for getting known anagrams");
        }
    }
}
