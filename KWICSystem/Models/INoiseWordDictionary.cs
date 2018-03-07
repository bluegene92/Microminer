using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWICSystem.Models
{
    public interface INoiseWordDictionary
    {
        void AddNoiseWord(string word);
        void RemoveNoiseWord(string word);
        bool IsNoiseWord(string word);
    }
}
