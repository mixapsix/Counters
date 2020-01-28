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

        public void WriteData()
        {
            List<Counter> counters = new List<Counter>();
            counters.Add(new Counter() { ID = 1, Value = 1, Number = 1 });
            counters.Add(new Counter() { ID = 1, Value = 2, Number = 2 });
            counters.Add(new Counter() { ID = 1, Value = 3, Number = 3 });
            counters.Add(new Counter() { ID = 2, Value = 1, Number = 4 });
            counters.Add(new Counter() { ID = 2, Value = 1, Number = 5 });
            counters.Add(new Counter() { ID = 2, Value = 3, Number = 6 });
            counters.Add(new Counter() { ID = 2, Value = 1, Number = 7 });

            counters.ForEach(x => countersContext.Counters.Add(x));

            countersContext.SaveChanges();
        }
        public IQueryable<Counter> GetCounters()
        {
            var selectedCounters = from counter in countersContext.Counters
                                   select counter;
            return selectedCounters;    
        }
        public void DropTable()
        {
            countersContext.Counters.RemoveRange(countersContext.Counters.ToList());
            countersContext.SaveChanges();
        }
    }
}
