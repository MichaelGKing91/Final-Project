using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;

namespace kalendarium.Models
{

    public class DAL
    {
        static public IDbConnection db;

        // Department methods
        // C - Add Event 
        // R: Read All, Read one by ID 
        // U -- Update Location / Event ID? 
        // D -- Delete


        public static Event AddEvent(int user_id, string name, bool privateEvent, DateTime dt_id)
        {
            Event newevent = new Event() { id = user_id, name = name, privateEvent = privateEvent, dt_id = dt_id };
            db.Insert(newevent);
            return newevent;
        }

        public static User AddUser( string firstName, string lastName, string emailAddress,)
        {
            Event newevent = new Event() { id = user_id, name = firstname, privateEvent = privateEvent, dt_id = dt_id };
            db.Insert(newevent);
            return newevent;
        }


        public static string UpdateEvent(Event updatedevent)
        {
            db.Update(updatedevent);
            return "Update Worked!";
        }

        public static List<Event> ReadAllEvents()
        {

            return db.GetAll<Event>().ToList();
        }

    
        public static Event ReadOneEvent(int id)
        {
            return db.Get<Event>(id);
        }

        public static void DeleteDepartment(int id)
        {
            Event tempobj = new Event();
            tempobj.id = id;
            db.Delete(tempobj);
        }


    }
}

