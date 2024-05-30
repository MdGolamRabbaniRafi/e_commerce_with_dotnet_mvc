using AIUB_Task.DAL.EF;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AIUB_Task
{
    public class CheckUser : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var emailOrPassword = value.ToString();

                using (var db = new AIUB_TaskEntities1())
                {
                    var user = db.Users.FirstOrDefault(item => item.Email == emailOrPassword || item.Password == emailOrPassword);

                    if (user != null)
                    {
                        if (user.Password == emailOrPassword)
                        {
                            HttpContext.Current.Session["UserType"] = user.User_Type;
                            return true;
                        }
                    }
                }
            }

            HttpContext.Current.Session["UserType"] = "";
            return false;
        }
    }
}
