namespace KWICSystem.Models
{
    public interface IAlgorithm<T>
    {
        T Run(T input);
    }
}
