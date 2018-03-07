using KWICSystem.Models;
using System;

namespace KWICSystem.Controllers
{
    public class FilterFactory : IFilterFactory
    {
        public IFilter<IContext> GetFilter(string name)
        {
            if (name.Equals("CircularShiftFilter", StringComparison.InvariantCultureIgnoreCase))
            {
                return new CircularShiftFilter(new Context());
            }

            if (name.Equals("AlphabetizerFilter", StringComparison.InvariantCultureIgnoreCase))
            {
                return new AlphabetizerFilter(new Context(), 
                                              new SortByAlphabet(new AlphabetComparer(new AlphabetDictionary()))
                                              );
            }

            if (name.Equals("NoiseWordFilter", StringComparison.InvariantCultureIgnoreCase))
            {
                NoiseWordDictionary noiseWordDictionary = new NoiseWordDictionary();
                //“a”, “an”, “the”, “and”, “or”, “of”, “to”, “be”, “is”, “in”, “out”, “by”, “as”, “at”, “off”
                noiseWordDictionary.AddNoiseWord("a");
                noiseWordDictionary.AddNoiseWord("an");
                noiseWordDictionary.AddNoiseWord("the");
                noiseWordDictionary.AddNoiseWord("and");
                noiseWordDictionary.AddNoiseWord("or");
                noiseWordDictionary.AddNoiseWord("of");
                noiseWordDictionary.AddNoiseWord("to");
                noiseWordDictionary.AddNoiseWord("be");
                noiseWordDictionary.AddNoiseWord("is");
                noiseWordDictionary.AddNoiseWord("in");
                noiseWordDictionary.AddNoiseWord("out");
                noiseWordDictionary.AddNoiseWord("by");
                noiseWordDictionary.AddNoiseWord("as");
                noiseWordDictionary.AddNoiseWord("at");
                noiseWordDictionary.AddNoiseWord("off");
                return new NoiseWordFilter(new Context(), noiseWordDictionary);
            }

            return null;
        }
    }
}
