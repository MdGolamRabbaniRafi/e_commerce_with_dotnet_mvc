using AIUB_Task.BLL.Services;
using AIUB_Task.Classes;
using AIUB_Task.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIUB_Task.Controllers
{
    public class InventoryController : Controller
    {
        [Logged]
        [AdminCheck]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [Logged]
        [AdminCheck]
        [HttpGet]
        public ActionResult LowStockCheck()
        {
            var db = new AIUB_TaskEntities1();
            var lowStock = ProductService.LowStockCheck();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.categories = db.Categories.ToList();
            ViewBag.Colors = db.Colors.ToList();
            ViewBag.Sizes = db.Sizes.ToList();
            ViewBag.ProductColor = db.ProductColors.ToList();
            ViewBag.ProductSize = db.ProductSizes.ToList();
            return View(lowStock);
        }
        [Logged]
        [AdminCheck]
        [HttpPost]
        public JsonResult UpdateProductQuantity(int productId, int quantity)
        {
            var db = new AIUB_TaskEntities1();
            var product = db.Products.Find(productId);
            if (product == null)
            {
                return Json(new { success = false, message = "Product not found." });
            }

            product.Quantity += quantity;
            db.SaveChanges();

            return Json(new { success = true, message = "Quantity updated successfully." });
        }
        [Logged]
        [AdminCheck]
        [HttpGet]
        public ActionResult SearchOrders()
        {
            return View();
        }
        [Logged]
        [AdminCheck]
        [HttpPost]
        public JsonResult SearchOrders(DateTime startDate, DateTime endDate)
        {
            var db = new AIUB_TaskEntities1();
            var orders = db.Orders
                .Where(o => o.Date >= startDate && o.Date <= endDate)
                .Select(o => new
                {
                    o.Status,
                    o.Id,
                    o.Date,
                    o.TotalOrderPrice
                })
                .ToList();

            return Json(new { success = true, data = orders });
        }


    }
}