using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Counters;

namespace Counters.Services
{
    public class DataBaseService : IDataBase
    {
        CountersContext countersContext;

        public DataBaseService(CountersContext countersContext)
        {
            this.countersContext = countersContext;
        }

        public void Initialize()
        {
            if (!countersContext.Counters.Any())
            {
                List<Counter> counters = new List<Counter>()
                {
                    new Counter() { ID = 1, Value = 1, Number = 1 },
                    new Counter() { ID = 1, Value = 2, Number = 2 },
                    new Counter() { ID = 1, Value = 3, Number = 3 },
                    new Counter() { ID = 2, Value = 1, Number = 4 },
                    new Counter() { ID = 2, Value = 1, Number = 5 },
                    new Counter() { ID = 2, Value = 3, Number = 6 },
                    new Counter() { ID = 2, Value = 1, Number = 7 }
                };
                counters.ForEach(async x => await InsertDataAsync(x));
                countersContext.SaveChanges();
            }
        }

        public async Task InsertDataAsync(Counter data)
        {
            await countersContext.AddAsync<Counter>(data);
        }

        public IQueryable<Counter> GetCounters()
        {
            var selectedCounters = from counter in countersContext.Counters
                                   select counter;
            return selectedCounters;    
        }

        public IQueryable<IGrouping<int, Counter>> GetIDs()
        {
            var selectedCounters = from counter in countersContext.Counters
                                   group counter by counter.ID;
            return selectedCounters;
        }
        public void DropTable()
        {
            countersContext.Counters.RemoveRange(countersContext.Counters.ToList());
            countersContext.SaveChanges();
        }


    }
}
