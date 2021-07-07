using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace kalendarium.Models
{
    [Table("Event")]
    public class Event
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public bool privateEvent { get; set; }
        public DateTime dt_id { get; set; }
        public int location_id { get; set; }
    }
}


//Make SQL cod for location_id In events field 