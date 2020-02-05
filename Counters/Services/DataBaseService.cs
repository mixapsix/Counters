using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Counters;

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
                    new Counter() { ID = 1, Value = 1, Number = -7 },
                    new Counter() { ID = 1, Value = 2, Number = -6 },
                    new Counter() { ID = 1, Value = 3, Number = -5 },
                    new Counter() { ID = 2, Value = 1, Number = -4 },
                    new Counter() { ID = 2, Value = 1, Number = -3 },
                    new Counter() { ID = 2, Value = 3, Number = -2 },
                    new Counter() { ID = 2, Value = 1, Number = -1 }
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

        public IQueryable<IGrouping<int, Counter>> GetIDs()
        {
            var selectedCounters = from counter in CountersContext.Counters
                                   group counter by counter.ID;
            return selectedCounters;
        }
        public void DropTable()
        {
            CountersContext.Counters.RemoveRange(CountersContext.Counters.ToList());
            CountersContext.SaveChanges();
        }


    }
}
