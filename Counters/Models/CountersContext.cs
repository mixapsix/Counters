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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Counter> counters = new List<Counter>() 
            {
                new Counter() { Value = 1, Number = 1, ID = -7 },
                new Counter() { Value = 2, Number = 1, ID = -6 },
                new Counter() { Value = 3, Number = 1, ID = -5 },
                new Counter() { Value = 1, Number = 2, ID = -4 },
                new Counter() { Value = 1, Number = 2, ID = -3 },
                new Counter() { Value = 3, Number = 2, ID = -2 },
                new Counter() { Value = 1, Number = 2, ID = -1 }
            };

            modelBuilder.Entity<Counter>().HasData(counters);
        }

    }
}
