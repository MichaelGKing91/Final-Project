using kalendarium.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kalendarium.Controllers
{
    [Route("calendar")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        [HttpGet("{start}/{end}")]
        public List<Calendar> GetTheCalendar (DateTime start, DateTime end)
        {
            return DAL.GetMFCalendar(start, end);
        }
    }
}
