using System.Collections.Generic;

namespace KWICSystem.Models
{
    public interface IContext
    {
        void AddString(string input);
        List<string> GetBody();
        void SetBody(List<string> context);
        int GetSize();
        string GetLine(int lineIndex);
        string GetWord(int lineIndex, int wordIndex);
        char GetChar(int lineIndex, int wordIndex, int letterIndex);
        int WordCount(int lineIndex);
    }
}
