using KWICSystem.Models;

namespace KWICSystem.Controllers
{
    public class AlphabetizerFilter : IFilter<IContext>
    {
        private IAlgorithm<IContext> _sortByAlphabet;
        private IContext _newContext;

        public AlphabetizerFilter(IContext context, IAlgorithm<IContext> sortByAlphabet)
        {
            this._newContext = context;
            this._sortByAlphabet = sortByAlphabet;
        }

        public IContext Execute(IContext input)
        {
            this._newContext.SetBody(input.GetBody());
            return _sortByAlphabet.Run(this._newContext);
        }
    }
}
