using KWICSystem.Models;
using System;

namespace KWICSystem.Controllers
{
    public class NoiseWordFilter : IFilter<IContext>
    {
        private IContext _newContext;
        private INoiseWordDictionary _noiseWordDictionary;

        public NoiseWordFilter(IContext context, INoiseWordDictionary noiseWordDictionary)
        {
            this._newContext = context;
            this._noiseWordDictionary = noiseWordDictionary;
        }

        public IContext Execute(IContext input)
        {
            NoiseWordDictionary noiseWordDictionary = new NoiseWordDictionary();
            for (int i = 0; i < input.GetSize(); ++i)
            {
                // Get first word of each line
                string firstWord = input.GetWord(i, 0);
                if (!this._noiseWordDictionary.IsNoiseWord(firstWord))
                {
                    this._newContext.AddString(input.GetLine(i));
                }
            }
            return this._newContext;
        }
    }
}
