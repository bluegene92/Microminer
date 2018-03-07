namespace KWICSystem.Models
{
    public interface IFilterFactory
    {
        IFilter<IContext> GetFilter(string name);
    }
}
