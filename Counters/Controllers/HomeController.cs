﻿using System;
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