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
                new Counter() { ID = 1, Value = 1, Number = -7 },
                new Counter() { ID = 1, Value = 2, Number = -6 },
                new Counter() { ID = 1, Value = 3, Number = -5 },
                new Counter() { ID = 2, Value = 1, Number = -4 },
                new Counter() { ID = 2, Value = 1, Number = -3 },
                new Counter() { ID = 2, Value = 3, Number = -2 },
                new Counter() { ID = 2, Value = 1, Number = -1 }
            };

            modelBuilder.Entity<Counter>().HasData(counters);
        }

    }
}
