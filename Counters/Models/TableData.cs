using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Counters.Models
{
    public class TableData
    {
        private int elementCount;
        public int ElementCount 
        { 
            get 
            { 
                return ++elementCount; 
            } 
            set 
            { 
                if(elementCount==0)
                    elementCount = value; 
            } 
        }
    }
}
