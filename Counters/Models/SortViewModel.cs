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
            Up = true;

            if(sortOrder == SortState.ValueDesc || sortOrder == SortState.IDDesc || sortOrder == SortState.NumberDesc)
            {
                Up = false;
            }
            switch(sortOrder)
            {
                case SortState.IDDesc:
                    Current = IDSort = SortState.IDAsc;
                    break;
                case SortState.NumberAsc:
                    Current = NumberSort = SortState.NumberDesc;
                    break;
                case SortState.NumberDesc:
                    Current = NumberSort = SortState.NumberAsc;
                    break;
                case SortState.ValueAsc:
                    Current = ValueSort = SortState.ValueDesc;
                    break;
                case SortState.ValueDesc:
                    Current = ValueSort = SortState.ValueAsc;
                    break;
                default:
                    Current = IDSort = SortState.IDDesc;
                    break;
            }
        }
    }
}
