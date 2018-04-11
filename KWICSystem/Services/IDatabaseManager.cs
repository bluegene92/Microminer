using KWICSystem.Models;
using System.Collections.Generic;

namespace KWICSystem.Services
{
    public interface IDatabaseManager
    {
        IEnumerable<Source> GetAllSource();
        Source GetSource(int id);
        bool Add(Source source);
        Source GetLastSource();


        IEnumerable<KWICSource> GetAllKWICSource();
        KWICSource GetKWICSource(int id);
        bool AddKWIC(KWICSource source);
        KWICSource GetLastKWICSource();
    }
}
