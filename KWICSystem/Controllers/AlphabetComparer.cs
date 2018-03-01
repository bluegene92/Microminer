using System;
using System.Collections.Generic;
using KWICSystem.Models;
namespace KWICSystem.Controllers
{
    public class AlphabetComparer : IComparer<string>
    {
        AlphabetDictionary _alphabetDictionary;
        public AlphabetComparer(AlphabetDictionary alphabetDictionary)
        {
            this._alphabetDictionary = alphabetDictionary;
            this._alphabetDictionary.Create();
        }

        public int Compare(string s1, string s2)
        {
            int charCount = Math.Min(s1.Length, s2.Length);
            for (int i = 0; i < charCount; ++i)
            {
                int v1 = _alphabetDictionary.GetValue(s1[i]);
                int v2 = _alphabetDictionary.GetValue(s2[i]);
                if (v1 == v2) continue;
                if (v1 < v2) return -1;
                else if (v1 > v2) return 1;

            }
            return 0;
        }
    }
}
