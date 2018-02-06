using System.Collections.Generic;

namespace KWICSystem.Models
{
    public interface IContext
    {
        void AddString(string input);
        List<string> GetContext();
        void SetContext(List<string> context);
    }
}
