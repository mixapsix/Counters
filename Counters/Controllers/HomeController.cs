using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Counters.Services;

namespace Counters.Controllers
{
    public class HomeController : Controller
    {
        IDataBase baseService;
        int elementCount;
        public HomeController(IDataBase dataBaseService)
        {
            baseService = dataBaseService;
            elementCount = dataBaseService.CountersContext.Counters.Count();
        }
        public IActionResult Index()
        {
            return View(baseService.GetCounters().ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Number = ++elementCount;
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