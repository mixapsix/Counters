using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Counters.Models
{
    public class FilterViewModel
    {
        public int? SelectedID { get; set; }
        public int? SelectedValue { get; set; }
        public int? SelectedNumber { get; set; }
        public IQueryable<Counter> selectListItems { get; set; }

        public FilterViewModel(int? selectID, int? selectNumber, int? selectValue)
        {
            SelectedID = selectID;
            SelectedNumber = selectNumber;
            SelectedValue = selectValue;
        }
    }
}
