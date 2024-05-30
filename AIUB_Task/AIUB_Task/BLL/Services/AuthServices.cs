using AIUB_Task.BLL.DTOs;
using AIUB_Task.Classes;
using AIUB_Task.DAL.EF;
using AIUB_Task.DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIUB_Task.BLL.Services
{
    public class AuthServices
    {
        public static bool Signup(SignupDTO signupDTO)
        {
            var mapper = MapperClass.MappedUser(signupDTO);
            var user = mapper.Map<User>(signupDTO);
            return AuthRepo.Signup(user);
        }
    }

}