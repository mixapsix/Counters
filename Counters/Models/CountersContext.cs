using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Counters
{
    public class CountersContext : DbContext
    {
        public DbSet<Counter> Counters { get; set; }
        public CountersContext(DbContextOptions<CountersContext> options):base(options)
        {
                
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=postgres; Username=postgres; Password=Mixa4343");
        }
    }
}
