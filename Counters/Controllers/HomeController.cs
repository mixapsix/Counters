using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Counters.Services;
using Counters.Models;

namespace Counters.Controllers
{
    public class HomeController : Controller
    {
        IDataBase baseService;
        public HomeController(IDataBase dataBaseService)
        {
            baseService = dataBaseService;
        }
        public async Task<IActionResult> Index(SortState sortOrder = SortState.IDAsc)
        {
            var data = baseService.GetCounters();
            data = sortOrder switch
            {
                SortState.IDDesc => data.OrderByDescending(x => x.ID),
                SortState.NumberAsc => data.OrderBy(x => x.Number),
                SortState.NumberDesc => data.OrderByDescending(x => x.Number),
                SortState.ValueAsc => data.OrderBy(x => x.Value),
                SortState.ValueDesc => data.OrderByDescending(x => x.Value),
                _ => data.OrderBy(x => x.ID),
            };
            IndexViewModel viewModel = new IndexViewModel
            {
                Counters = await data.AsNoTracking().ToListAsync(),
                SortViewModel = new SortViewModel(sortOrder)
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Counter counter)
        {            
            baseService.InsertDataAsync(counter);
            baseService.CountersContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Data()
        {
            return View(baseService.GetData().ToList());
        }
    }
}