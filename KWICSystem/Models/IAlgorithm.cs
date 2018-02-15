using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWICSystem.Models
{
    public interface IAlgorithm<T>
    {
        T run(T input);
    }
}
