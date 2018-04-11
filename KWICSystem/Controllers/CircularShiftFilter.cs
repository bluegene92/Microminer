using KWICSystem.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace KWICSystem.Controllers
{
    public class CircularShiftFilter : IFilter<IContext>
    {
        public IContext Execute(ref IContext input)
        {
            return BuildCircularIndexTable(ref input);
        }

        public IContext BuildCircularIndexTable(ref IContext context)
        {
            List<Tuple<int, int>> indexTable = new List<Tuple<int, int>>();

            for (int i = 0; i < context.GetSize(); i++)
            {
                int index = 0;
                bool firstLetter = false;
                var matchHttp = Regex.Match(context.GetBody()[i], @"\bhttp|https\b");
                int urlIndexHttp = matchHttp.Index;
                if (matchHttp.Success)
                {
                    urlIndexHttp = matchHttp.Index;
                } else
                {
                    urlIndexHttp = context.GetBody()[i].Length;
                }
               
                while (index < urlIndexHttp)
                {
                    while (index < urlIndexHttp &&
                            !char.IsWhiteSpace(context.GetBody()[i][index]) &&
                            !firstLetter)
                    {
                        context.GetIndexTable().Add(Tuple.Create(i, index));
                        firstLetter = true;
                    }
                    index++;
                    while (index < urlIndexHttp && 
                        char.IsWhiteSpace(context.GetBody()[i][index]))
                    {
                        firstLetter = false;
                        index++;
                    }
                }
            }
            return context;
        }
    }
}
