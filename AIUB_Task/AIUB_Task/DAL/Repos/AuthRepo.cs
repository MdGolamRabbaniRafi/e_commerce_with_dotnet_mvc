using AIUB_Task.BLL.DTOs;
using AIUB_Task.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIUB_Task.DAL.Repos
{
    public class AuthRepo
    {
        public static bool Signup(User signupDTO)
        {
            var db = new AIUB_TaskEntities1();
            signupDTO.User_Type = "user";
             db.Users.Add(signupDTO);
            var a= db.SaveChanges();
            if(a>0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}