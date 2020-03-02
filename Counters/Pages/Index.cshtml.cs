using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Counters.Services;
using Microsoft.EntityFrameworkCore;

namespace Counters
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Counter> Counters { get; set; }
        private IDataBase dataBase;
        public IndexModel(IDataBase dataBase)
        {
            this.dataBase = dataBase;
        }
        public async Task OnGetAsync()
        {
            Counters = await dataBase.GetCounters().ToListAsync();
        }
    }
}