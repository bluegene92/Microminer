namespace KWICSystem.Models
{
    public interface IPipeline<T>
    {
        PipelineManager<T> Register(IFilter<T> operation);
    }
}
