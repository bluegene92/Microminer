using System.Collections.Generic;

namespace KWICSystem.Models
{
    public interface IContext
    {
        void AddString(string input);
        List<string> GetBody();
        void SetContext(List<string> context);
    }
}
