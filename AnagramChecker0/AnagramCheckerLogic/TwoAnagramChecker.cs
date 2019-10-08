using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AnagramCheckerLogic
{
    public class TwoAnagramChecker : ITwoWordChecker
    {
        public bool checkTwoWords(string w1, string w2)
            => String.Concat(w1.OrderBy(c => c)).ToUpper().Equals(String.Concat(w2.OrderBy(c => c)).ToUpper());
    }
}
