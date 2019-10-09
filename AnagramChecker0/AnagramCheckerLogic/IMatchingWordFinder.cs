using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramCheckerLogic
{
    public interface IMatchingWordFinder
    {
        IEnumerable<string> FindMatching(string word, string dictPath);
    }
}
