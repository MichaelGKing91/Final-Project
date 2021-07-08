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

        //-----------------------------------------------------------------------------
        //--------------------USER CRUD-----------------------------------------------
        //-----------------------------------------------------------------------------

        public static User AddUser (string fName, string lName, string eAddress, string dPArt, string pWord)
        {
            User newuser = new User() { firstName = fName, lastName = lName, emailAddress = eAddress, department = dPArt, password = pWord };
            db.Insert(newuser);
            return newuser;
        }

        public static bool  isUser(User usr)
        {
            List<User> userlist = new List<User>();

            userlist = db.GetAll<User>().ToList();

            foreach (User currentuser in userlist)
            {
                if (currentuser.emailAddress == usr.emailAddress)
                {
                    return true;
                }
            }
            return false;
        }
        public static List<User> GetOneUser (string eAddress)
        {
            return db.Query<User>("select * from user where emailAddress = @uEAddress", new { uEAddress = eAddress}).ToList();
        }
        //-----------------------------------------------------------------------------
        //--------------------COWORKER CRUD-----------------------------------------------
        //-----------------------------------------------------------------------------
        public static Coworker AddCoworker(bool toHide, int thisUser, int coworkerID)
        {
            Coworker newCW = new Coworker() { hide = toHide, user_id = thisUser, coworker_id = coworkerID};
            db.Insert(newCW);
            return newCW;
        }

        public static List<Coworker> GetCoworkerByUser (int thisUser)
        {
            return db.Query<Coworker>("select * from coworker where user_id = @uTheUser", new { uTheUser = thisUser }).ToList();
        }

        public static bool ToggleHide (Coworker toUpdate)
        {
            if (toUpdate.hide)
            {
                toUpdate.hide = false;
            }
            else
            {
                toUpdate.hide = true;
            }
            db.Update(toUpdate);
            return true;
        }

        //-----------------------------------------------------------------------------
        //--------------------EVENT CRUD-----------------------------------------------
        //-----------------------------------------------------------------------------
        public static Event MakeNewEvent (int thisUser, string userName, bool privateParty, DateTime dateID)
        {
            Event newEvent = new Event() { user_id = thisUser, name = userName, privateEvent = privateParty, dt_id = dateID };
            db.Insert(newEvent);
            return newEvent;
        }
        public static Event ReadOneEventByID (int eventID)
        {
            return db.Get<Event>(eventID);
        }
        public static List<Event> ReadAllPublicEvents()
        {
            return db.Query<Event>("select * from Events where privateEvent = false").ToList();
        }
        public static List<Event> ReadAllCoworkerPublicEvents(int coworkerID)
        {
            return db.Query<Event>("select * from Events where privateEvent = false and user_id = @uCWID", new { uCWID = coworkerID }).ToList();
        }
        public static List<Event> ReadAllEventsByUser (int userID)
        {
            return db.Query<Event>("select * from Events where user_id = @user", new { user = userID }).ToList();
        }
        
        public static bool UpdateEvent (Event toUpdate)
        {
            db.Update<Event>(toUpdate);
            return true;
        }

        public static bool DeleteEvent (int eventID)
        {
            Event toDelete = new Event() { id = eventID };
            db.Delete<Event>(toDelete);
            return true;
        }

        //-----------------------------------------------------------------------------
        //--------------------CALENDAR CRUD-----------------------------------------------
        //-----------------------------------------------------------------------------
        //make a join to read the calender with events

        public static List<Calendar> GetMFCalendar(DateTime start, DateTime end)
        {
            return db.Query<Calendar>("select * from calendar where dt >= @uStart and dt <= @uEnd", new { uStart = start, uEnd = end }).ToList();
        }
    }
}

