namespace KWICSystem.Models
{
    public class ContextStorage : IContextStorage
    {
        private IContext _context;

        public IContext GetContext()
        {
            return this._context;
        }

        public void SetContext(IContext context)
        {
            this._context = context;
        }

    }
}
