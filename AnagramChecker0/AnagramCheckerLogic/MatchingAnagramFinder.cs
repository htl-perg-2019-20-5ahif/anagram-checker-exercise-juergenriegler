using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AnagramCheckerLogic
{
    public class MatchingAnagramFinder : IMatchingWordFinder
    {
        public IEnumerable<string> FindMatching(string word, string dictPath)
        {
            IDictionaryReader reader = new DictionaryFileReader();
            var dictWords = reader.ReadDictionary(dictPath)
                .Replace("\r", string.Empty)
                .Split('\n');

            ITwoWordChecker checker = new TwoAnagramChecker();
            var matching = dictWords
                .Where(x => checker.checkTwoWords(x, word))
                .Where(x => !x.ToUpper().Equals(word.ToUpper()));
            return matching;
        }
    }
}
