using AIUB_Task.BLL.DTOs;
using AIUB_Task.BLL.Services;
using AIUB_Task.Classes;
using AIUB_Task.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AIUB_Task.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AIUB_TaskEntities1())
                {
                    var user = db.Users.FirstOrDefault(u => u.Email == loginDTO.Email && u.Password == loginDTO.Password);
                    if (user != null)
                    {
                        Session["UserId"] = user.Id;
                        Session["UserType"] = user.User_Type;

                        if (user.User_Type == "Admin")
                        {
                            return RedirectToAction("AdminDashboard");
                        }
                        else if (user.User_Type == "user")
                        {
                            return RedirectToAction("UserDashboard");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid login attempt.");
                    }
                }
            }

            return View(loginDTO);
        }


        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignupDTO signupDTO)
        {
            if (ModelState.IsValid)
            {
                var signup= AuthServices.Signup(signupDTO);

                if(signup)
                {
                 return   RedirectToAction("Login");
                }

                return View();
            }
            return View(signupDTO);
        }
        [HttpGet]
        public ActionResult Auth( )
        {
            Session["UserType"] = "user";
            Session["UserId"] = 1;
            return RedirectToAction("UserDashboard");
        }
        [HttpGet]
        [Logged]
        [AdminCheck]

        public ActionResult AdminDashboard()
        {
            return View();
        }
        [HttpGet]
        [Logged]
        [UserCheck]

        public ActionResult UserDashboard()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}