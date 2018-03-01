using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWICSystem.Models
{
    public class AlphabetDictionary : IAlphabetDictionary
    {
        private Dictionary<char, int> charValueDictionary = new Dictionary<char, int>();
        public void Create()
        {
            int startValue = 0;
            for (char lowercaseLetter = 'a',
                    uppercaseLetter = 'A';
                    uppercaseLetter <= 'Z';)
            {
                charValueDictionary.Add(lowercaseLetter, startValue++);
                charValueDictionary.Add(uppercaseLetter, startValue++);
                lowercaseLetter++;
                uppercaseLetter++;
            }
            charValueDictionary.Add(' ', 52);
        }

        public int GetValue(char character)
        {
            return charValueDictionary[character];
        }
    }
}
