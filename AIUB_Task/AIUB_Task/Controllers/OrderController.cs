using AIUB_Task.BLL.DTOs;
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
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        [Logged]
        [UserCheck]
        public ActionResult CustomerPendingOrder()
        {
            int userId = 0;
            if (Session["UserId"] != null && int.TryParse(Session["UserId"].ToString(), out int parsedUserId))
            {
                userId = parsedUserId;
            }

            var orders = OrderService.FindOrder(userId);
            List<Product> products = new List<Product>();
            var db = new AIUB_TaskEntities1();

            if (orders != null && orders.Any())
            {
                foreach (var order in orders)
                {
                    var productOrderMappers = db.ProductOrderMappers.Where(pom => pom.OrderId == order.Id).ToList();
                    foreach (var productOrderMapper in productOrderMappers)
                    {
                        var product = db.Products.Find(productOrderMapper.ProductId);
                        if (product != null)
                        {
                            products.Add(product);
                        }
                    }
                }
                ViewBag.Products = products;
                return View(orders);

            }
            else
            {
                ViewBag.ErrorMessage = "No orders found for the current user.";
                return View("Error");
            }
        }
        [Logged]
        [UserCheck]
        public ActionResult OrderDetailsForCustomer(int id)
        {
            int userId = 0;
            if (Session["UserId"] != null && int.TryParse(Session["UserId"].ToString(), out int parsedUserId))
            {
                userId = parsedUserId;
            }

            using (var db = new AIUB_TaskEntities1())
            {
                var productOrderMappers = db.ProductOrderMappers
                                            .Where(pom => pom.OrderId == id)
                                            .ToList();

                var order = db.Orders.Find(id);

                if (order != null && order.UserId == userId)
                {
                    var products = new List<ProductDTO>();

                    foreach (var pom in productOrderMappers)
                    {
                        var product = ProductService.SearchProduct((int)pom.ProductId);
                        if (product != null)
                        {
                            products.Add(product);
                        }
                    }

                    var orderDetailsViewModel = new OrderDetailsViewModel
                    {
                        Order = order,
                        Products = products
                    };
                    ViewBag.category = db.Categories.ToList();
                    ViewBag.color = db.Colors.ToList();
                    ViewBag.size = db.Sizes.ToList();
                    ViewBag.ProductColor = db.ProductColorOrderMappers.ToList();
                    ViewBag.ProductSize = db.ProductOrderSizeMappers.ToList();

                    return View(orderDetailsViewModel);
                }
                else
                {
                    ViewBag.ErrorMessage = "Order not found or you do not have access to this order.";
                    return View("Error");
                }
            }
        }
        public class OrderDetailsViewModel
        {
            public Order Order { get; set; }
            public List<ProductDTO> Products { get; set; }
        }
        [HttpGet]
        [Logged]
        [AdminCheck]
        public ActionResult AllOrder( )
        {
            var db = new AIUB_TaskEntities1();
            var orders = db.Orders.ToList();


            return View(orders);
        }
        [HttpPost]
        [Logged]
        [AdminCheck]
        public ActionResult UpdateOrderStatus(int orderId, string newStatus)
        {
            using (var db = new AIUB_TaskEntities1())
            {
                var order = db.Orders.Find(orderId);
                if (order != null)
                {
                    order.Status = newStatus;
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, errorMessage = "Order not found" });
                }
            }
        }

        [Logged]
        [AdminCheck]
        public ActionResult OrderDetailsForAdmin(int id)
        {
            int userId = 0;


            using (var db = new AIUB_TaskEntities1())
            {
                var productOrderMappers = db.ProductOrderMappers
                                            .Where(pom => pom.OrderId == id)
                                            .ToList();

                var order = db.Orders.Find(id);
                userId = (int)order.UserId;
                var user = db.Users.Find(userId);
                ViewBag.user=user;


                    var products = new List<ProductDTO>();

                    foreach (var pom in productOrderMappers)
                    {
                        var product = ProductService.SearchProduct((int)pom.ProductId);
                        if (product != null)
                        {
                            products.Add(product);
                        }
                    }

                    var orderDetailsViewModel = new OrderDetailsViewModel
                    {
                        Order = order,
                        Products = products
                    };
                    ViewBag.category = db.Categories.ToList();
                    ViewBag.color = db.Colors.ToList();
                    ViewBag.size = db.Sizes.ToList();
                    ViewBag.ProductColor = db.ProductColorOrderMappers.ToList();
                    ViewBag.ProductSize = db.ProductOrderSizeMappers.ToList();

                    return View(orderDetailsViewModel);
                
              
            }
        }




    }
}