using KWICSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace KWICSystem.Data
{
    public class SourceDbContext : DbContext
    {
        public SourceDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Source> Sources { get; set; }
        public DbSet<KWICSource> KWICSources { get; set; }
    }
}
