using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Counters.Services
{
    public interface IDataBase
    {
        void WriteData();
        IQueryable<Counter> GetCounters();
        void DropTable();
    }
}
