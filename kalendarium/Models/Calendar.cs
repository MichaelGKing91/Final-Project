using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace kalendarium.Models
{
    [Table("Calendar")]
    public class Calendar
    {
        [Key]
        public DateTime dt { get; set; }
        public int y { get; set; }
        public int q { get; set; }
        public int m { get; set; }
        public int d { get; set; }
        public int dw { get; set; }
        public string monthName { get; set; }
        public string dayName { get; set; }
        public int w { get; set; }
        public bool isWeekday { get; set; }
        public bool isHoliday { get; set; }
        public bool isPayday { get; set; }
        public string holidayDescr { get; set; }

    }
}
