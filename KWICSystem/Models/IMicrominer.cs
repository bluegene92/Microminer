using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWICSystem.Controllers
{
    public interface IMicrominer
    {
        List<string> FindUrl(string keywords);
    }
}
