using KWICSystem.Models;

namespace KWICSystem.Controllers
{
    public class AlphabetizerFilter : IFilter<IContext>
    {
        private IAlgorithm<IContext> _sortByAlphabet;

        public AlphabetizerFilter(IAlgorithm<IContext> sortByAlphabet)
        {
            this._sortByAlphabet = sortByAlphabet;
        }

        public IContext Execute(ref IContext input)
        {
            return _sortByAlphabet.Run(ref input);
        }
    }
}
