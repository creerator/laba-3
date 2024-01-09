using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class StringDbContext : DbContext
    {
        public DbSet<DataEntry> entries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=localdb.db");
    }
}