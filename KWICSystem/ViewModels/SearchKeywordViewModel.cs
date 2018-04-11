using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWICSystem.ViewModels
{
    public class SearchKeywordViewModel
    {
        public string Body { get; set; }
        public string ResultBody { get; set; }
        public List<string> ResultListBody { get; set; }
        public double Time { get; set; }    
    }
}
