using KWICSystem.Controllers;

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
            return input;
        }
    }
}
