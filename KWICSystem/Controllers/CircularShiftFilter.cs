using KWICSystem.Models;
using System.Collections.Generic;

namespace KWICSystem.Controllers
{
    public class CircularShiftFilter : IFilter<IContext>
    {
        private IContext _newContext;

        public CircularShiftFilter(IContext context)
        {
            this._newContext = context;
        }

        public IContext Execute(IContext input)
        {
            return ParseContext(input);
        }

        private IContext ParseContext(IContext input)
        {
            for (int i = 0; i < input.GetSize(); ++i)
            {
                ParseSentence(input.GetLine(i), input.WordCount(i));
            }
            return this._newContext;
        }

        private void ParseSentence(string sentence, int wordCount)
        {
            this._newContext.AddString(sentence);
            if (wordCount > 1)
            {
                for (int i = 0; i < wordCount - 1; ++i)
                {
                    string newSentence = Shift(sentence);
                    this._newContext.AddString(newSentence);
                    sentence = newSentence;
                }
            }
        }

        private string Shift(string sentence)
        {
            int firstSpace = sentence.IndexOf(' ');
            string firstWord = sentence.Substring(0, firstSpace);
            string leftOverWords = sentence.Substring(firstSpace + 1);
            string newSentence = leftOverWords + " " + firstWord;
            return newSentence;
        }
    }
}
