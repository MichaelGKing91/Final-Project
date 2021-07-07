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



    }
}

