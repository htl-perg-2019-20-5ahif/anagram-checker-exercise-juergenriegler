using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnagramCheckerLogic
{
    public interface IDictionaryReader
    {
       string ReadDictionary(string path);
    }
}
