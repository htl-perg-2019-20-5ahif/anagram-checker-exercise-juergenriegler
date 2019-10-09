using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AnagramCheckerLogic;

namespace AnagramCheckerApp
{
    class Program
    {
        private static readonly string dictionaryFileName = "anagrams.txt";

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
                default:
                    Console.WriteLine("Enter check to check two words for anagrams or getKnown for finding a words anagram.");
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
            if (words.Count() < 1)
            {
                Console.WriteLine("GETKNOWN: oen word is required for getting known anagrams");
                return;
            }
            IMatchingWordFinder matchingWordFinder = new MatchingAnagramFinder();
            var matching = matchingWordFinder.FindMatching(words.ElementAt(0), dictionaryFileName);
            if (matching.Count() == 0) Console.WriteLine("GETKNOWN: no anagrams found");
            else Console.WriteLine("GETKNOWN: (" + words.ElementAt(0) + "): " + IEnumerableAsString(matching));

        }

        static string IEnumerableAsString(IEnumerable e)
        {
            string returnString = "";
            foreach (var i in e) returnString += i + " ";
            return returnString;
        }
    }
}
