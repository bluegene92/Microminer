using KWICSystem.Models;
using System;
using System.Collections.Generic;

namespace KWICSystem.Controllers
{
    public class NoiseWordFilter : IFilter<IContext>
    {
        private INoiseWordDictionary _noiseWordDictionary;

        public NoiseWordFilter(INoiseWordDictionary noiseWordDictionary)
        {
            this._noiseWordDictionary = noiseWordDictionary;
        }

        public IContext Execute(ref IContext context)
        {
            List<Tuple<int, int>> indexTable = new List<Tuple<int, int>>();
            for (int i = 0; i < context.GetIndexTable().Count; i++)
            {
                string tempLine = context.GetLine(context.GetIndexTable()[i]);
                var firstWord = tempLine.Substring(0, tempLine.IndexOf(" "));
                if (!this._noiseWordDictionary.IsNoiseWord(firstWord))
                {
                    indexTable.Add(context.GetIndexTable()[i]);
                }
            }
            context.SetIndexTable(ref indexTable);
            return context;
        }
    }
}
