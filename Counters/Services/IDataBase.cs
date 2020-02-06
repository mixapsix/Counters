﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Counters.Services
{
    public interface IDataBase
    {
        CountersContext CountersContext { get; set; }
        Task InsertDataAsync (Counter data);
        void Initialize();
        IQueryable<Counter> GetCounters();
        void DropTable();
    }
}
