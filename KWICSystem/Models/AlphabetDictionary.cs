using System;
using System.Collections.Generic;

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

            for (char letter = ' '; letter < 'A';)
            {
                charValueDictionary.Add(letter, startValue++);
                letter++;
            }

            for (char letter = '['; letter < 'a';)
            {
                charValueDictionary.Add(letter, startValue++);
                letter++;
            }
            charValueDictionary.Add('\t', startValue++);
        }

        public int GetValue(char character)
        {
            return charValueDictionary[character];
        }
    }
}
