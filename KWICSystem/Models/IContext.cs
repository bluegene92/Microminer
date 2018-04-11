using System;
using System.Collections.Generic;

namespace KWICSystem.Models
{
    public interface IContext
    {
        List<string> GetBody();
        List<string> GetOutput();
        void SetBody(List<string> context);
        void SetIndexTable(ref List<Tuple<int, int>> indexTable);
        List<Tuple<int, int>> GetIndexTable();
        string GetLine(Tuple<int, int> tuple);
        int GetSize();
        int WordCount(int lineIndex);
    }
}
