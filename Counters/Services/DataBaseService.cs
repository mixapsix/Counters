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
       
        public async Task InsertDataAsync(Counter data)
        {
            await CountersContext.AddAsync<Counter>(data);
        }

        public IQueryable<Counter> GetCounters()
        {
            var selectedCounters = CountersContext.Counters.Select(p => p);
            return selectedCounters;    
        }

        public IQueryable<Data> GetData()
        {
            var selectedCounters = CountersContext.Counters.
                GroupBy(numbers => numbers.Number).
                OrderBy(numbers => numbers.Key).
                Select(numbers => new Data { ID = numbers.Key, Count = numbers.Count(), MoreThanOne = CountersContext.Counters.Select(p => p).Where(p => p.Value > 1 && p.Number == numbers.Key).Count() });
            return selectedCounters;
        }
    }
}
