using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Counters.Services;

namespace Counters
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Counter Counter { get; set; }

        private readonly IDataBase _dataBase;
        public AddModel(IDataBase dataBase)
        {
            _dataBase = dataBase;
        }
        public async Task OnPostAsync()
        {           
            await _dataBase.InsertDataAsync(Counter);
            Response.Redirect("Index");
        }
    }
}