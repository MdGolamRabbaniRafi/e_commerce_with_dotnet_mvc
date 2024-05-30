using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AIUB_Task.BLL.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name cannot contain numbers or special characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Image is required")]

        public HttpPostedFileBase Image { get; set; }

        [Required(ErrorMessage = "Description is required")]

        public string Description { get; set; }


        [Required(ErrorMessage = "Quantity Password is required")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is required")]

        public int price { get; set; }
        [Required(ErrorMessage = "Category is required")]

        public int CategoryId { get; set; }
        public byte[] ImageData { get; set; }
    }
}