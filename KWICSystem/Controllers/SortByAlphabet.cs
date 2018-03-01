using KWICSystem.Controllers;
using System.Collections.Generic;

namespace KWICSystem.Models
{

    public class SortByAlphabet : IAlgorithm<IContext>
    {

        AlphabetComparer _alphabetComparer;
        public SortByAlphabet(AlphabetComparer alphabetComparer)
        {
            this._alphabetComparer = alphabetComparer;
        }

        public IContext Run(IContext input)
        {
            input.GetBody().Sort(_alphabetComparer);
            //List<string> list = input.GetBody();
            //list.Add("BULLSHIT");
            //input.SetContext(list);
            return input;
        }
    }
}
