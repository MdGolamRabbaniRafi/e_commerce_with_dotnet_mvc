using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIUB_Task.Classes
{
    public class UserCheck : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string userType = httpContext.Session["UserType"] as string;

            if (userType == "user")
            {
                return true;
            }

            return false;
        }
    }
}