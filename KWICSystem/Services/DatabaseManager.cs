using KWICSystem.Data;
using KWICSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWICSystem.Services
{
    public class DatabaseManager : IDatabaseManager
    {
        private SourceDbContext _context;
        public DatabaseManager(SourceDbContext context)
        {
            _context = context;
        }

        public bool Add(Source source)
        {
            _context.Sources.Add(source);
            _context.SaveChanges();
            return true;
        }

        public bool AddKWIC(KWICSource kwicSource)
        {
            _context.KWICSources.Add(kwicSource);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Source> GetAllSource()
        {
            return _context.Sources.ToList();
        }

        public IEnumerable<KWICSource> GetAllKWICSource()
        {
            return _context.KWICSources.ToList();
        }

        public Source GetLastSource()
        {
            return _context.Sources.OrderByDescending(s => s.ID).Take(1).FirstOrDefault();
        }

        public KWICSource GetLastKWICSource()
        {
            return _context.KWICSources.OrderByDescending(s => s.ID).Take(1).FirstOrDefault();
        }

        public Source GetSource(int id)
        {
            return _context.Sources.SingleOrDefault(s => s.ID == id);
        }

        public KWICSource GetKWICSource(int id)
        {
            return _context.KWICSources.SingleOrDefault(s => s.ID == id);
        }


    }
}
