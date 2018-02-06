using KWICSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace KWICSystem.Controllers
{
    public class AlphabetizerFilter : IFilter<IContext>
    {
        public IContext Execute(IContext input)
        {
            List<string> context = input.GetContext();
            //var result = from element in input.GetContext()
            //             orderby element.Substring(0, 1)
            //             thenby element.Length
            //             select element;

            input.SetContext(context.OrderBy(x => x.Substring(0, 1)).ThenBy(s => s.Length).ToList());
            //input.SetContext(result.ToList());
            return input;
        }

        public int CompareByLowercase(string x, string y)
        {

            for (int i = 0; i < x.Length && i < y.Length; ++i)
            {
                // Cast char to int value
                int xValue = (int)x[i];
                int yValue = (int)y[i];

                if ((xValue > 64 && xValue < 91) || (xValue > 96 && xValue < 123))
                {
                    if (xValue < yValue) return 1;
                    if (xValue > yValue) return -1;
                } else
                {
                    if (xValue < yValue) return -1;
                    if (xValue > yValue) return 1;
                }
            }
            return 0;
        }
    }
}
