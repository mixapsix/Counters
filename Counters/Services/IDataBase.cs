using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Counters.Services
{
    public interface IDataBase
    {
        Task InsertDataAsync (Counter data);
        void Initialize();
        IQueryable<Counter> GetCounters();
        IQueryable<IGrouping<int, Counter>> GetIDs();
        void DropTable();
    }
}
