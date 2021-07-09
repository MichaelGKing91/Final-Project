using kalendarium.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kalendarium.Controllers
{
    [Route("location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        [HttpPost("add")]
        public bool AddLocation (string ccity, string sstate, string sstreet, string zzip)
        {
            DAL.AddLocation(ccity, sstate, sstreet, zzip);
            return true;
        }

        [HttpGet("by/{id}")]
        public Location GetLocationByID(int id)
        {
            Location thisLocale = DAL.ReadOneLocByID(id);
            return thisLocale;
        }

        [HttpPut("update/{Lid}/{Lcity}/{Lstate}/{Lstreet}/{Lzip}")]
        public bool UpdateLocation (int Lid, string Lcity, string Lstate, string Lstreet, string Lzip)
        {
            Location toUpdate = new Location() { id = Lid, city = Lcity, state = Lstate, street = Lstate, zip = Lzip };
            DAL.EditLocation(toUpdate);
            return true;
        }

        [HttpDelete("remove/{id}")]
        public bool DeleteLocation (int id)
        {
            DAL.DeleteLocation(id);
            return true;
        }

        [HttpGet("withevent")]
        public  List<Join> GetAllEventsWithLocation()
        {
            return DAL.GetAllEventsWithLocation();
        }

    }
}
