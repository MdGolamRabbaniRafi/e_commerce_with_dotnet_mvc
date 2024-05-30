using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AIUB_Task.BLL.DTOs
{
    public class CategoryDTO
    {
        [Required(ErrorMessage = "Name is required")]


        public string Name { get; set; }
    }
}