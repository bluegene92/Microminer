using KWICSystem.Models;
using System.Collections.Generic;

namespace KWICSystem.Controllers
{
    public class CircularShiftFilter : IFilter<IContext>
    {
        public IContext Execute(IContext input)
        {
            return ParseContext(input);
        }

        public IContext ParseContext(IContext input)
        {
            List<string> context = input.GetContext();
            int contextCount = context.Count;
            List<string> circularList = new List<string>();

            int parseIndex = 0;
            for (int i = 0; i < contextCount; ++i)
            {
                circularList = ParseSentence(context[parseIndex++]);
                if (circularList.Count > 0)
                {
                    for (int j = 0; j < circularList.Count; ++j)
                    {
                        context.Insert(parseIndex++, circularList[j]);
                    }
                }
            }
            return input;
        }

        public List<string> ParseSentence(string sentence)
        {
            List<string> circularList = new List<string>();
            int wordCount = GetWordCount(sentence);
            if (wordCount > 1)
            {
                for (int i = 0; i < wordCount - 1; ++i)
                {
                    string newSentence = Shift(sentence);
                    circularList.Add(newSentence);
                    sentence = newSentence;
                }
            }
            return circularList;
        }

        public string Shift(string sentence)
        {
            int firstSpace = sentence.IndexOf(' ');
            string firstWord = sentence.Substring(0, firstSpace);
            string leftOverWords = sentence.Substring(firstSpace + 1);
            string newSentence = leftOverWords + " " + firstWord;
            return newSentence;
        }

        public int GetWordCount(string sentence)
        {
            int wordCount = 0;
            int index = 0;
            while (index < sentence.Length)
            {
                while (index < sentence.Length && !char.IsWhiteSpace(sentence[index]))
                    index++;

                wordCount++;

                while (index < sentence.Length && char.IsWhiteSpace(sentence[index]))
                    index++;
            }
            return wordCount;
        }  
    }
}
