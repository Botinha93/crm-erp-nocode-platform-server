using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Server_CRM_Framework.Filters;
using Server_CRM_Framework.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server_CRM_Framework.Controllers
{
    /// <summary>
    /// this controller deals with users and also operations that are not directly related to business logic
    /// like configuration files 
    /// </summary>
    [Route("")]
    public class HomeController : Controller
    {
        // GET: /
        public IActionResult Index()
        {
            return View();
        }
        //loggin view 
        [Route("login")]
        public IActionResult login()
        {
            return View("Views/login.cshtml");
        }
        //processes the login request, returns acess token
        [HttpGet("loginProcess")]
        public string loginProcess([FromHeader] string user , [FromHeader] string pass)
        {
            string token = UserModel.logUserIn(user, pass);
            return JsonConvert.SerializeObject(token);
        }
        //registers a new user, needs to be logged in fist
        [HttpPost("register")]
        public void register([FromHeader] string user, [FromHeader] string pass, [FromHeader] string group)
        {
            UserModel.addUser(user, pass, group);
        }
        [HttpPost("group")]
        public void group([FromHeader] string group)
        {
            GroupModel.addGroup(group);
        }
        //return base entity list for this app
        [HttpGet("entitylist")]
        [LoginActionFilter]
        public string entityList()
        {
            string teste = JsonConvert.SerializeObject(loader.entities);
            return teste;
        }
        [HttpGet("userInfo")]
        [LoginActionFilter]
        public string userInfo([FromHeader] string token)
        {
            return JsonConvert.SerializeObject(Models.UserModel.getUserFromToken(token));
        }
    }
}
