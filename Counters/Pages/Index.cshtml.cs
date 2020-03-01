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
        public IDataBase DataBase { get; set; }
        public IndexModel(IDataBase dataBase)
        {
            DataBase = dataBase;
        }
        public async Task OnGetAsync()
        {
            Counters = await DataBase.GetCounters().ToListAsync();
        }
    }
}