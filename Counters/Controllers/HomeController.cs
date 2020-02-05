using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Counters.Services;
using Counters.Models;

namespace Counters.Controllers
{
    public class HomeController : Controller
    {
        IDataBase baseService;
        TableData tableData;
        public HomeController(IDataBase dataBaseService, TableData tableData)
        {
            baseService = dataBaseService;
            this.tableData = tableData;
        }
        public IActionResult Index()
        {
            return View(baseService.GetCounters().ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Number = tableData.ElementCount;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Counter counter)
        {            
            baseService.InsertDataAsync(counter);
            baseService.CountersContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}