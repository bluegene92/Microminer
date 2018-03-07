using System.Collections.Generic;

namespace KWICSystem.Models
{
    public class Context : IContext
    {
        private List<string> _body;

        public Context()
        {
            this._body = new List<string>();
        }

        public void AddString(string input)
        {
            this._body.Add(input);
        }

        public List<string> GetBody()
        {
            return this._body;
        }

        public void SetBody(List<string> content)
        {
            this._body = content;
        }

        public int GetSize()
        {
            return this._body.Count;
        }

        public string GetLine(int lineIndex)
        {
            return this._body[lineIndex];
        }

        public string GetWord(int lineIndex, int wordIndex)
        {
            string line = this._body[lineIndex];
            string[] words = line.Split(' ');
            return words[wordIndex];
        }

        public char GetChar(int lineIndex, int wordIndex, int letterIndex)
        {
            string line = this._body[lineIndex];
            string[] words = line.Split(' ');
            string word = words[wordIndex];
            char letter = word[letterIndex];
            return letter;
        }

        public int WordCount(int lineIndex)
        {
            string line = this._body[lineIndex];
            int wordCount = 0;
            int index = 0;

            while (index < line.Length)
            {
                while (index < line.Length && !char.IsWhiteSpace(line[index]))
                    index++;
                wordCount++;

                // Skip whitespace until reach next word
                while (index < line.Length && char.IsWhiteSpace(line[index]))
                    index++;
            }
            return wordCount;
        }
    }
}
