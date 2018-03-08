using System.Collections.Generic;

namespace KWICSystem.Models
{
    public class NoiseWordDictionary : INoiseWordDictionary
    {
        private Dictionary<string, string> _noiseWordDictionary = new Dictionary<string, string>();

        public void AddNoiseWord(string word)
        {
            string wordUpper = word.ToUpper();
            this._noiseWordDictionary.Add(word, word);
            this._noiseWordDictionary.Add(wordUpper, wordUpper);
        }

        public void RemoveNoiseWord(string word)
        {
            string wordUpper = word.ToUpper();
            this._noiseWordDictionary.Remove(word);
            this._noiseWordDictionary.Remove(wordUpper);
        }

        public bool IsNoiseWord(string word)
        {
            return this._noiseWordDictionary.ContainsValue(word);
        }
    }
}
