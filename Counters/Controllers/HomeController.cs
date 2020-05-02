﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Counters.Services;
using Counters.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace Counters.Controllers
{
    public class HomeController : Controller
    {
        IDataBase _baseService;
        ILogger<HomeController> _logger;
        public HomeController(IDataBase dataBaseService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _baseService = dataBaseService;
        }
        public async Task<IActionResult> Index(int? selectID, int? selectNumber, int? selectValue, SortState sortOrder = SortState.IDAsc, int page = 1)
        {

            var data = _baseService.GetCounters();
            int pageSize = 5;

            if (selectID != null)
            {
                data = data.Where(k => k.ID + 8 == selectID).Select(k => k);
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
            _logger.LogInformation("RazorViewIndex page request");
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            _logger.LogInformation("RazorViewAdd page request");
            return View();
        }

        [HttpPost]
        public IActionResult Add(Counter counter)
        {
            _baseService.InsertDataAsync(counter);
            _logger.LogInformation("Record added");
            return RedirectToAction("Index");
        }
        public IActionResult Data()
        {
            _logger.LogInformation("Table page request");
            return View(_baseService.GetData().ToList());
        }

        [HttpGet]
        public async Task<JsonResult> IndexAJAXAsync(int page = 0, int recordCount = 10, string sortOrder = "idasc")
        {
            var data = _baseService.GetCounters();
            int count = await _baseService.GetCounters().CountAsync();
            switch (sortOrder)
            {
                case "iddesc":
                    {
                        data = data.OrderByDescending(x => x.ID);
                        break;
                    }
                case "numberasc":
                    {
                        data = data.OrderBy(x => x.Number);
                        break;
                    }
                case "numberdesc":
                    {
                        data = data.OrderByDescending(x => x.Number);
                        break;
                    }
                case "valueasc":
                    {
                        data = data.OrderBy(x => x.Value);
                        break;
                    }
                case "valuedesc":
                    {
                        data = data.OrderByDescending(x => x.Value);
                        break;
                    }
                default:
                    {
                        data = data.OrderBy(x => x.ID);
                        break;
                    }
            }
            var result = await data.Skip(page * recordCount).Take(recordCount).ToListAsync();
            _logger.LogInformation("Ajax page request");
            return Json(new AjaxPageNavigation(count, recordCount, page)
            {
                Data = result
            });
        }   
        [HttpGet("/Home/IndexDevExtreme")]
        public IActionResult IndexDevExtreme(DataSourceLoadOptions loadOptions)
        {
            var data = _baseService.GetCounters();
            var result = DataSourceLoader.Load(data,loadOptions);
            _logger.LogInformation("DevExpress page request");
            return Ok(result);
        }
    }
}