using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Server_CRM_Framework.Filters
{
    /// <summary>
    /// This class handles the verification of tokens for users that are already logged in to the system
    /// since users can only acess Values and the entity list from a logged perspective, every user that has
    /// a invalid token or is not logged gets redirected to the login screen
    /// /// </summary>
    public class LoginActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var response = new Microsoft.AspNetCore.Mvc.StatusCodeResult(451);
            filterContext.HttpContext.Response.Headers.Add("location", filterContext.HttpContext.Request.Headers["Referer"] + "login");
            if (!String.IsNullOrEmpty(filterContext.HttpContext.Request.Headers["token"]))
            {
                if (!Models.UserModel.userLogued(filterContext.HttpContext.Request.Headers["token"]))
                {
                    filterContext.Result = response;
                }
            }
            else
            {
                filterContext.Result = response;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
