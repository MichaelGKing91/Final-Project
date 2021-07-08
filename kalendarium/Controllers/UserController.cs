using kalendarium.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kalendarium.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("add")]
        public bool AddUser (string fName, string lName, string eAddress, string dPart, string pWord)
        {
            DAL.AddUser(fName, lName, eAddress, dPart, pWord);
            return true;
        }

        [HttpGet("isuser")]
        public bool isUser(string fName, string lName, string eAddress, string dPart, string pWord)
        {
            User usr = new User() { firstName = fName, lastName = lName, emailAddress = eAddress, department = dPart, password = pWord };
            return DAL.isUser(usr);
        }

        [HttpGet("getuser/{eAddress}")]
        public List<User> getUserByEmail(string eAddress)
        {
            return DAL.GetOneUser(eAddress);
        }


    }
}
