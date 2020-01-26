using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Counters
{
    public class Counter
    {
        [Key]
        public int Number { get; set; }
        public int ID { get; set; }
        public int Value { get; set; }
    }
}
