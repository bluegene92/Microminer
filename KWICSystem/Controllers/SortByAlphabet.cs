using System;
using System.Collections.Generic;

namespace KWICSystem.Models
{

    public class SortByAlphabet : IAlgorithm<IContext>
    {
        private IAlphabetDictionary _alphabetDictionary;
        public SortByAlphabet(AlphabetDictionary alphabetDictionary)
        {
            this._alphabetDictionary = alphabetDictionary;
            this._alphabetDictionary.Create();
        }

        public IContext Run(ref IContext context)
        {
            context.GetIndexTable().Sort(
                new AlphabetComparer(ref context, ref this._alphabetDictionary));
            return context;
        }
    }

    public class AlphabetComparer : IComparer<Tuple<int, int>>
    {
        private IContext _context;
        private IAlphabetDictionary _alphabetDictionary;
        public AlphabetComparer(ref IContext context, ref IAlphabetDictionary alphabetDictionary)
        {
            this._context = context;
            this._alphabetDictionary = alphabetDictionary;
        }
        public int Compare(Tuple<int, int> x, Tuple<int, int> y)
        {
            string s1 = this._context.GetLine(x);
            string s2 = this._context.GetLine(y);
            int charCount = Math.Min(s1.Length, s2.Length);
            for (int i = 0; i < charCount; ++i)
            {
                int v1 = this._alphabetDictionary.GetValue(s1[i]);
                int v2 = this._alphabetDictionary.GetValue(s2[i]);
                if (v1 == v2) continue;
                if (v1 < v2) return -1;
                else if (v1 > v2) return 1;
            }
            return 0;
        }
    }
}
