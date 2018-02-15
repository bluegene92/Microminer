using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWICSystem.Models
{
    public class SortByFirstChar : IAlgorithm<IContext>
    {
        public IContext run(IContext input)
        {
            input.SetContext(
                input.GetBody()
                .OrderBy(x => x.Substring(0, 1))
                .ThenBy(s => s.Length)
                .ToList());

            return input;
        }
    }
}
