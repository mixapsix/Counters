using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Counters.Models
{
    public class SortViewModel
    {
        public  SortState IDSort{ get; set; }
        public  SortState NumberSort{ get; set; }
        public  SortState ValueSort{ get; set; }
        public  SortState Current{ get; set; }
        public bool Up { get; set; }


        public SortViewModel(SortState sortOrder)
        {
            IDSort = sortOrder == SortState.IDAsc ? SortState.IDDesc : SortState.IDAsc;
            NumberSort = sortOrder == SortState.NumberAsc ? SortState.NumberDesc : SortState.NumberAsc;
            ValueSort = sortOrder == SortState.ValueAsc ? SortState.ValueDesc : SortState.ValueAsc;
            Current = sortOrder;
        }
    }
}
