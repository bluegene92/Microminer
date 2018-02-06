namespace KWICSystem.Models
{
    public interface IFilter<T>
    {
        T Execute(T input);
    }
}
