using System.Collections.Generic;

namespace KWICSystem.Models
{
    public class Context : IContext
    {
        private List<string> Body;

        public Context()
        {
            Body = new List<string>();
        }

        public void AddString(string input)
        {
            Body.Add(input);
        }

        public List<string> GetBody()
        {
            return Body;
        }

        public void SetContext(List<string> content)
        {
            Body = content;
        }
    }
}
