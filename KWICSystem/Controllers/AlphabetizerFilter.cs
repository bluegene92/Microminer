using KWICSystem.Models;

namespace KWICSystem.Controllers
{
    public class AlphabetizerFilter : IFilter<IContext>
    {
        private SortByFirstChar _SortByFirstChar;

        public AlphabetizerFilter(SortByFirstChar sortByFirstCharAlgorithm)
        {
            this._SortByFirstChar = sortByFirstCharAlgorithm;
        }

        public IContext Execute(IContext input)
        {
            return _SortByFirstChar.run(input);
        }
    }
}
