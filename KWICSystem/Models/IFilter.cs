namespace KWICSystem.Models
{
    public interface IFilter<T>
    {
        T Execute(ref T input);
    }
}
