namespace KWICSystem.Models
{
    public interface IPipeline<T>
    {
        T PerformOperation(T input);
       PipelineManager<T> Register(IFilter<T> operation);
    }
}
