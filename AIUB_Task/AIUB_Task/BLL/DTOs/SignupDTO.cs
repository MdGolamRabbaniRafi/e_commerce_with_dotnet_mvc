using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AIUB_Task.BLL.DTOs
{
    public class SignupDTO
    {

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name cannot contain numbers or special characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]

        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]

        public string Confirm_Password { get; set; }

        [Required(ErrorMessage = "Gender is required")]

        public string Gender { get; set; }

    }
}