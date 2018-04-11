using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace KWICSystem.Models
{
    public class Context : IContext
    {
        private List<string> _body;

        // <lineNumber, indexOffset>
        private List<Tuple<int, int>> _indexTable;

        public Context()
        {
            this._body = new List<string>();
            this._indexTable = new List<Tuple<int, int>>();
        }

        public List<string> GetBody()
        {
            return this._body;
        }

        public void SetBody(List<string> content)
        {
            this._body = content;
        }

        public void SetIndexTable(ref List<Tuple<int, int>> indexTable)
        {
            this._indexTable = indexTable;
        }

        public List<Tuple<int, int>> GetIndexTable()
        {
            return this._indexTable;
        }

        public int GetSize()
        {
            return this._body.Count;
        }

        public string GetLine(Tuple<int, int> tuple)
        {
            int length = this._body[tuple.Item1].Length;
            this._body[tuple.Item1] = this._body[tuple.Item1].Replace("\t", " ");
            var match = Regex.Match(this._body[tuple.Item1], @"\bhttp|https\b");
            int urlIndex;
            if (match.Success)
            {
                urlIndex = match.Index;
            } else
            {
                urlIndex = this._body[tuple.Item1].Length;
            }

            string rightString = this._body[tuple.Item1]
                                .Substring(tuple.Item2, urlIndex - tuple.Item2);
            string leftString = this._body[tuple.Item1]
                                .Substring(0, tuple.Item2);
            return rightString + " " + leftString + " " + this._body[tuple.Item1].Substring(urlIndex);
        }

        public List<string> GetOutput()
        {
            List<string> outputContext = new List<string>();
            this._indexTable.ForEach(tuple => {
                outputContext.Add(GetLine(tuple));
            });
            return outputContext;
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
