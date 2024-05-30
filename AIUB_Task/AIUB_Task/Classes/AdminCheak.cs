using System;
using System.Web;
using System.Web.Mvc;

namespace AIUB_Task.Classes
{
    public class AdminCheck : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string userType = httpContext.Session["UserType"] as string;

            if (userType == "Admin")
            {
                return true; 
            }

            return false; 
        }
    }
}
