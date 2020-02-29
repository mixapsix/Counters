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
            IDSort = SortState.IDAsc;
            NumberSort = SortState.NumberAsc;
            ValueSort = SortState.ValueAsc;
            Up = false;

            if(sortOrder == SortState.ValueDesc || sortOrder == SortState.IDDesc || sortOrder == SortState.NumberDesc)
            {
                Up = true;
            }

            Current = sortOrder switch
            {
                SortState.IDDesc => IDSort = SortState.IDAsc,
                SortState.NumberAsc => NumberSort = SortState.NumberDesc,
                SortState.NumberDesc => NumberSort = SortState.NumberAsc,
                SortState.ValueAsc => ValueSort = SortState.ValueDesc,
                SortState.ValueDesc => ValueSort = SortState.ValueAsc,
                _ => IDSort = SortState.IDDesc,
            };
        }
    }
}
