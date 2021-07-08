using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kalendarium.Models
{
    [Table("Location")]
    public class Location
    {
        [Key]
        public int id { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string street { get; set; }
        public string zip { get; set; }

    }
}
