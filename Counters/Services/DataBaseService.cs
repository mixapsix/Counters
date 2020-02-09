using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Counters;
using Counters.Models;

namespace Counters.Services
{
    public class DataBaseService : IDataBase
    {
        public CountersContext CountersContext { get; set; }

        public DataBaseService(CountersContext countersContext)
        {
            this.CountersContext = countersContext;
        }

        public void Initialize()
        {
            if (!CountersContext.Counters.Any())
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
                counters.ForEach(async x => await InsertDataAsync(x));
                CountersContext.SaveChanges();
            }
        }

        public async Task InsertDataAsync(Counter data)
        {
            await CountersContext.AddAsync<Counter>(data);
        }

        public IQueryable<Counter> GetCounters()
        {
            var selectedCounters = from counter in CountersContext.Counters
                                   select counter;
            return selectedCounters;    
        }

        public IQueryable<Data> GetData()
        {
            var selectedCounters = from counter in CountersContext.Counters
                                   group counter by counter.Number into numbers
                                   orderby numbers.Key
                                   select new Data { ID = numbers.Key, 
                                       Count = numbers.Count(), 
                                       MoreThanOne = (from counters in CountersContext.Counters
                                                      where counters.Value > 1 && counters.Number == numbers.Key
                                                      select counters).Count()
                                   };

            return selectedCounters;
        }

        public void DropTable()
        {
            CountersContext.Counters.RemoveRange(CountersContext.Counters.ToList());
            CountersContext.SaveChanges();
        }


    }
}
