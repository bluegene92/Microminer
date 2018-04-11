namespace KWICSystem.Models
{
    public interface IAlgorithm<T>
    {
        T Run(ref T input);
    }
}
