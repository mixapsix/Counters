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
        public HomeController(IDataBase dataBaseService)
        {
            baseService = dataBaseService;
        }
        public IActionResult Index()
        {
            return View(baseService.GetCounters().ToList());
        }
    }
}