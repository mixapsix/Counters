﻿using System;
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
        public async Task<IActionResult> Index(int? selectID, int? selectNumber, int? selectValue, SortState sortOrder = SortState.IDAsc, int page = 1)
        {
            
            var data = baseService.GetCounters();
            int pageSize = 5;

            if(selectID!=null)
            {
                data = data.Where(k => k.ID + 8 == selectID).Select(k=>k);
            }
            if (selectNumber != null)
            {
                data = data.Where(k => k.Number == selectNumber).Select(k => k);
            }
            if (selectValue != null)
            {
                data = data.Where(k => k.Value == selectValue).Select(k => k);
            }
                data = sortOrder switch
                {
                    SortState.IDDesc => data.OrderByDescending(x => x.ID),
                    SortState.NumberAsc => data.OrderBy(x => x.Number),
                    SortState.NumberDesc => data.OrderByDescending(x => x.Number),
                    SortState.ValueAsc => data.OrderBy(x => x.Value),
                    SortState.ValueDesc => data.OrderByDescending(x => x.Value),
                    _ => data.OrderBy(x => x.ID),
                };
  
            var count = await data.CountAsync();
            var items = await data.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            IndexViewModel viewModel = new IndexViewModel
            {
                Counters = items,
                SortViewModel = new SortViewModel(sortOrder),
                PageViewModel = new PageViewModel(count, page, pageSize),
                FilterViewModel = new FilterViewModel(selectID, selectNumber, selectValue)
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
            return RedirectToAction("Index");
        }
        public IActionResult Data()
        {
            return View(baseService.GetData().ToList());
        }
        
        public async Task<ActionResult<IEnumerable<Counter>>> IndexAJAXAsync()
        {
            return await baseService.GetCounters().ToListAsync();
        }
    }
}