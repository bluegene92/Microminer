using System.Collections.Generic;

namespace KWICSystem.Models
{
    public class Context : IContext
    {
        public List<string> SetOfText;

        public Context()
        {
            SetOfText = new List<string>();
        }

        public void AddString(string input)
        {
            SetOfText.Add(input);
        }

        public List<string> GetContext()
        {
            return SetOfText;
        }

        public void SetContext(List<string> context)
        {
            SetOfText = context;
        }
    }
}
