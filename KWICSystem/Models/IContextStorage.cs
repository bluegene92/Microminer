namespace KWICSystem.Models
{
    public interface IContextStorage
    {
        IContext GetContext();
        void SetContext(IContext context);
    }
}
