using kalendarium.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace kalendarium.Controllers
{
    [Route("event")] 
    [ApiController]
    public class EventController : ControllerBase
    {

        [HttpPost("addevent")]
        public bool MakeNewEvent(int thisUser, string userName, bool privateParty, DateTime dateID)
        {
            DAL.MakeNewEvent(thisUser, userName, privateParty, dateID);
            return true;
        }

        [HttpGet("getevent/{eventId}")]
        public Event ReadOneEventByID(int eventID)
        {
            return DAL.ReadOneEventByID(eventID);
        }

        [HttpGet("public")]
        public List<Event> ReadAllPublicEvents()
        {

            return DAL.ReadAllPublicEvents();
        }

        [HttpGet("readcoworker")]
        public  List<Event> ReadAllCoworkerPublicEvents(int coworkerID)
        {
            return DAL.ReadAllCoworkerPublicEvents(coworkerID).ToList();
        }


        [HttpGet("byuser")]
        public  List<Event> ReadAllEventsByUser(int userID)
        {
            return DAL.ReadAllEventsByUser(userID).ToList();
        }


        [HttpPut("update/")]
        public  bool UpdateEvent(Event toUpdate)
        {
            DAL.UpdateEvent(toUpdate);
            return true;
        
        }

        [HttpDelete("remove/{eventId}")]
        public bool RemoveUserFavorite(int id)
        {
            DAL.DeleteEvent(id);
            return true;
        }
     

    }
}



/* [HttpGet]
       public async Task<string> GetAll()
       {
           HttpClient client = new HttpClient();
           client.BaseAddress = new Uri("https://grandcircusco.github.io");
           var response = await client.GetAsync("/demo-apis/donuts.json");
           string json = await response.Content.ReadAsStringAsync();
           return json;
       }

       // Get Specific Donut
       // Our route: GET localhost:12345/donut/3
       //https://grandcircusco.github.io/demo-apis/donuts/2.json
       [HttpGet("{id}")]
       public async Task<string> GetOne(int id)
       {
           HttpClient client = new HttpClient();
           client.BaseAddress = new Uri("https://grandcircusco.github.io");
           var response = await client.GetAsync($"/demo-apis/donuts/{id}.json");
           string json = await response.Content.ReadAsStringAsync();
           return json;
       }

       */