using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramCheckerLogic
{
    public class DictionaryFileReader : IDictionaryReader
    {
        public string ReadDictionary(string path) => System.IO.File.ReadAllText(path);
    }
}
