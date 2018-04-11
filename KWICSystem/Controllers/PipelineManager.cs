using System.Collections.Generic;
using System.Linq;

namespace KWICSystem.Models
{
    public class PipelineManager<T> : IPipeline<T>
    {
        private readonly List<IFilter<T>> operations = new List<IFilter<T>>();

        public PipelineManager<T> Register(IFilter<T> operation)
        {
            operations.Add(operation);
            return this;
        }

        public T PerformOperation(T input)
        {
            return this.operations.Aggregate(input, (current, operations) => operations.Execute(ref current));
        }
    }
}
