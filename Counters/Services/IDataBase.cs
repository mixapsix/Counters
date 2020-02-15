using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Counters.Models;

namespace Counters.Services
{
    public interface IDataBase
    {
        CountersContext CountersContext { get; set; }
        Task InsertDataAsync (Counter data);
        IQueryable<Counter> GetCounters();
        IQueryable<Data> GetData();
    }
}
