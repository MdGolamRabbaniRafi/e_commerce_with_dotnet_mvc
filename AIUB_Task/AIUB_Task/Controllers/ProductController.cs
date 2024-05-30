using AIUB_Task.BLL.DTOs;
using AIUB_Task.BLL.Services;
using AIUB_Task.Classes;
using AIUB_Task.DAL.EF;
using AIUB_Task.DAL.Repos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Activities;

namespace AIUB_Task.Controllers
{
    public class ProductController : Controller
    {
        [Logged]
        [AdminCheck]
        public ActionResult Index()
        {
            return View();
        }
        [Logged]
        [AdminCheck]
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [Logged]
        [AdminCheck]
        [HttpPost]
        public ActionResult AddCategory(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                var category = ProductService.AddCategory(categoryDTO);

                if (category)
                {
                    return RedirectToAction("AdminDashboard","Home");
                }

                return View();
            }
            return View(categoryDTO);
        }
        [Logged]
        [AdminCheck]
        [HttpGet]
        public ActionResult AddProduct()
        {
            var db = new AIUB_TaskEntities1();
            ViewBag.categories = db.Categories.ToList();
            ViewBag.Colors = db.Colors.ToList();
            ViewBag.Sizes = db.Sizes.ToList();

            return View();
        }
        [Logged]
        [AdminCheck]
        [HttpPost]
        public ActionResult AddProduct(ProductDTO productDTO, int[] Colors, int[] Sizes)
        {
            if (ModelState.IsValid)
            {
                var product = ProductService.AddProduct(productDTO);

                if (product!=null)
                {
                    var color = ProductService.AddProductColors(Colors,product.Id);
                    var Size = ProductService.AddProductSize(Sizes, product.Id);
                    return RedirectToAction("AdminDashboard", "Home");
                }

                return View();
            }
            return View(productDTO);
        }
        [Logged]
        [AdminCheck]
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var product = ProductService.SearchProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var productDTO = new ProductDTO
            {
                Id = id,
                Name = product.Name,
                price = (int)product.price, 
                Description = product.Description,
                Quantity = (int)product.Quantity,
            };

            var db = new AIUB_TaskEntities1();

            ViewBag.categories = db.Categories.ToList();
            ViewBag.Colors = db.Colors.ToList();
            ViewBag.Sizes = db.Sizes.ToList();
            ViewBag.ProductColor = db.ProductColors.Where(pc => pc.ProductId == id).ToList();
            ViewBag.ProductSize = db.ProductSizes.Where(ps => ps.ProductId == id).ToList();

            ViewBag.id = id;

            return View(productDTO);
        }
        [Logged]
        [AdminCheck]


        [HttpPost]
        public ActionResult UpdateProduct(ProductDTO updatedProduct, int[] Colors, int[] Sizes)
        {
            if (ModelState.IsValid)
            {
                var color = ProductService.UpdateProductColors(Colors, updatedProduct.Id);
                var Size = ProductService.UpdateProductSize(Sizes, updatedProduct.Id);
                ProductService.UpdateProduct(updatedProduct);
                return RedirectToAction("Search", "Product");
            }
            var db = new AIUB_TaskEntities1();

            ViewBag.categories = db.Categories.ToList();
            ViewBag.Colors = db.Colors.ToList();
            ViewBag.Sizes = db.Sizes.ToList();
            ViewBag.ProductColor = db.ProductColors.Where(pc => pc.ProductId == updatedProduct.Id).ToList();
            ViewBag.ProductSize = db.ProductSizes.Where(ps => ps.ProductId == updatedProduct.Id).ToList();

            ViewBag.id = updatedProduct.Id;
            return View(updatedProduct);
        }

        [HttpGet]
        public ActionResult SearchProduct(int id)
        {
            var db = new AIUB_TaskEntities1();

            var product = ProductService.SearchProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.categories = db.Categories.ToList();
            ViewBag.Colors = db.Colors.ToList();
            ViewBag.Sizes = db.Sizes.ToList();
            ViewBag.ProductColor = db.ProductColors.Where(pc => pc.ProductId == id).ToList();
            ViewBag.ProductSize = db.ProductSizes.Where(ps => ps.ProductId == id).ToList();


            return View(product);
        }
        [Logged]
        [AdminCheck]
        [HttpGet]

        public ActionResult Search()
        {
            var db = new AIUB_TaskEntities1();
            var p = db.Products.ToList();
            ViewBag.Products = p;

            var products = ProductService.GetAllProducts();
            if (products == null)
            {
                return HttpNotFound();
            }

            ViewBag.categories = db.Categories.ToList();
            ViewBag.Colors = db.Colors.ToList();
            ViewBag.Sizes = db.Sizes.ToList();
            ViewBag.ProductColor = db.ProductColors.ToList();
            ViewBag.ProductSize = db.ProductSizes.ToList();


            return View(products);
        }
        [Logged]
        [AdminCheck]
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            ViewBag.id = id;

            return View();
        }
        [Logged]
        [AdminCheck]
        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            var deleteProduct = ProductService.ConfirmDelete(id);
            if (deleteProduct)
            {
                return RedirectToAction("Search", "Product");
            }

            ViewBag.ErrorMessage = "Unable to delete the product. Please try again.";
            return View();
        }
        [Logged]
        [UserCheck]
        [HttpGet]
        public ActionResult SearchAllProduct()
        {
            var db = new AIUB_TaskEntities1();
            var p = db.Products.ToList();
            ViewBag.Products = p;

            var products = ProductService.GetAllProducts();
            if (products == null)
            {
                return HttpNotFound();
            }

            ViewBag.categories = db.Categories.ToList();
            ViewBag.Colors = db.Colors.ToList();
            ViewBag.Sizes = db.Sizes.ToList();
            ViewBag.ProductColor = db.ProductColors.ToList();
            ViewBag.ProductSize = db.ProductSizes.ToList();


            return View(products);
        }
        [Logged]
        [UserCheck]
        [HttpGet]
        public ActionResult Details(int id)
        {
            var db = new AIUB_TaskEntities1();

            var product = ProductService.SearchProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.categories = db.Categories.ToList();
            ViewBag.Colors = db.Colors.ToList();
            ViewBag.Sizes = db.Sizes.ToList();

            ViewBag.ProductColor = db.ProductColors.Where(pc => pc.ProductId == id).ToList();
            ViewBag.ProductSize = db.ProductSizes.Where(ps => ps.ProductId == id).ToList();

            return View(product);
        }
        [Logged]
        [UserCheck]
        [HttpPost]
        public ActionResult AddToCart(int productId, int colorId, int sizeId, int Quantity)
        {
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new List<CartItem>();
            }

            var cart = (List<CartItem>)Session["Cart"];

            cart.Add(new CartItem
            {
                ProductId = productId,
                SelectedColor = colorId,
                SelectedSize = sizeId,
                Quantity = Quantity
            });

            Session["Cart"] = cart;

            return Json(new { success = true });
        }

        [Logged]
        [UserCheck]
        [HttpGet]
        public ActionResult ViewCart()
        {
            List<CartItem> cartItems = Session["Cart"] as List<CartItem>;
            if (cartItems == null)
            {
                return View(new List<CartProductDTO>());
            }

            List<CartProductDTO> productsInCart = GetProductsFromCart(cartItems);
            var db = new AIUB_TaskEntities1();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Colors = db.Colors.ToList();
            ViewBag.Sizes = db.Sizes.ToList();

            return View(productsInCart);
        }
        [Logged]
        [UserCheck]
        [HttpPost]
        public ActionResult OrderPlaceForMultipleProduct(string PhoneNumber, string CouponCode)
        {
            List<CartItem> cartItems = Session["Cart"] as List<CartItem>;
            if (cartItems == null)
            {
                return View(new List<CartProductDTO>());
            }

            List<CartProductDTO> productsInCart = GetProductsFromCart(cartItems);
            var db = new AIUB_TaskEntities1();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Colors = db.Colors.ToList();
            ViewBag.Sizes = db.Sizes.ToList();

            int userId = 0;
            if (Session["UserId"] != null && int.TryParse(Session["UserId"].ToString(), out int parsedUserId))
            {
                userId = parsedUserId;
            }
            var taka = 0M;
            foreach( var c in productsInCart)
            {
                taka=taka+c.Quantity*c.Price;
            }
            if (!string.IsNullOrEmpty(CouponCode))
            {

                var coupon = db.Cupons.FirstOrDefault(c => c.Name == CouponCode);

                if (coupon != null)
                {
                    decimal discountPercentage = coupon.Perchentage ?? 0;
                    taka -= (taka * discountPercentage) / 100;
                }
            }

            var OrderDto = new OrderDTO
            {
                TotalOrderPrice = taka,
                Number = PhoneNumber,
                Date = DateTime.Now,
                Status = "Placed",
                UserId = userId,
                Quantity = productsInCart.Sum(p => p.Quantity)
            };

            var mapper = MapperClass.MappedOrder(OrderDto);
            var order = mapper.Map<Order>(OrderDto);
            db.Orders.Add(order);
            db.SaveChanges();
            int orderId = order.Id;

            foreach (var p in productsInCart)
            {
                var product = db.Products.Find(p.ProductId);

                if (product != null && product.Quantity >= p.Quantity)
                {
                    product.Quantity -= p.Quantity;
                    db.SaveChanges();

                    var productOrderMapper = new ProductOrderMapper
                    {
                        ProductId = p.ProductId,
                        OrderId = orderId
                    };
                    db.ProductOrderMappers.Add(productOrderMapper);
                    db.SaveChanges();

                    var colorId = GetColorIdByName(p.SelectedColor);
                    var pcomMapper = new ProductColorOrderMapper
                    {
                        ProductId = p.ProductId,
                        OrderId = orderId,
                        ColorId = colorId
                    };
                    db.ProductColorOrderMappers.Add(pcomMapper);
                    db.SaveChanges();

                    var sizeId = GetSizeIdByName(Convert.ToInt32(p.SelectedSize));
                    var posm = new ProductOrderSizeMapper
                    {
                        ProductId = p.ProductId,
                        OrderId = orderId,
                        SizeId = sizeId
                    };
                    db.ProductOrderSizeMappers.Add(posm);
                    db.SaveChanges();
                }
                RemoveACart(p.ProductId);
            }

            return RedirectToAction("UserDashboard", "Home");
        }

        private int? GetColorIdByName(string colorName)
        {
            var db = new AIUB_TaskEntities1();
            var color = db.Colors.FirstOrDefault(c => c.Name == colorName);
            return color?.Id;
        }
        private int? GetSizeIdByName(int sizeName)
        {
            var db = new AIUB_TaskEntities1();
            var size = db.Sizes.FirstOrDefault(c => c.sizeOfProduct == sizeName);
            return size?.id;
        }




        private List<CartProductDTO> GetProductsFromCart(List<CartItem> cartItems)
        {
            var db = new AIUB_TaskEntities1();
            List<CartProductDTO> products = new List<CartProductDTO>();

            foreach (var item in cartItems)
            {
                ProductDTO product = ProductService.SearchProduct(item.ProductId);
                if (product != null)
                {
                    var color = db.Colors.FirstOrDefault(c => c.Id == item.SelectedColor);
                    var size = db.Sizes.FirstOrDefault(s => s.id == item.SelectedSize);

                    products.Add(new CartProductDTO
                    {
                        ProductId = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Quantity = item.Quantity,
                        Price = product.price,
                        ImageData = product.ImageData,
                        SelectedColor = color != null ? color.Name : "N/A",
                        SelectedSize = size != null ? size.sizeOfProduct.ToString() : "N/A"
                    });
                }
            }

            return products;
        }
        public class CartItem
        {
            public int ProductId { get; set; }
            public int SelectedColor { get; set; }
            public int SelectedSize { get; set; }
            public int Quantity { get; set; }

        }
        public void RemoveACart(int productId)
        {
            List<CartItem> cartItems = Session["Cart"] as List<CartItem>;
            if (cartItems != null)
            {
                var itemToRemove = cartItems.FirstOrDefault(item => item.ProductId == productId);
                if (itemToRemove != null)
                {
                    cartItems.Remove(itemToRemove);
                    Session["Cart"] = cartItems;
                }
            }

        }

        [HttpPost]
        [Logged]
        [UserCheck]
        public ActionResult RemoveFromCart(int productId)
        {
            List<CartItem> cartItems = Session["Cart"] as List<CartItem>;
            if (cartItems != null)
            {
                var itemToRemove = cartItems.FirstOrDefault(item => item.ProductId == productId);
                if (itemToRemove != null)
                {
                    cartItems.Remove(itemToRemove);
                    Session["Cart"] = cartItems;
                }
            }

            return Json(new { success = true });
        }


        [HttpGet]
        [Logged]
        [UserCheck]
        public ActionResult OrderPlaced(int productId, int price, int colorId, int sizeId, int quantity)
        {

            var db = new AIUB_TaskEntities1();

            ViewBag.Product = ProductService.SearchProduct(productId);
            ViewBag.Price = price;
            ViewBag.Quantity = quantity;
            ViewBag.Color = db.Colors.Find(colorId);
            ViewBag.Size = db.Sizes.Find(sizeId);

            return View(); 
        }
        [HttpPost]
        [Logged]
        [UserCheck]
        public ActionResult PlaceOrder(int productId, decimal Price, int colorId, int sizeId, int Quantity, string PhoneNumber)
        {
            int userId = 0;
            if (Session["UserId"] != null && int.TryParse(Session["UserId"].ToString(), out int parsedUserId))
            {
                userId = parsedUserId;
            }

            var db = new AIUB_TaskEntities1();
            var product = db.Products.Find(productId);

            if (product != null && product.Quantity >= Quantity)
            {
                decimal totalOrderPrice = Price * Quantity;

                var OrderDto = new OrderDTO
                {
                    TotalOrderPrice = totalOrderPrice,
                    Number = PhoneNumber,
                    Date = DateTime.Now,
                    Status = "Placed",
                    UserId = userId,
                    Quantity = Quantity
                };

                var mapper = MapperClass.MappedOrder(OrderDto);
                var order = mapper.Map<Order>(OrderDto);

                db.Orders.Add(order);
                var a = db.SaveChanges();

                if (a > 0)
                {
                    product.Quantity -= Quantity;
                    db.SaveChanges();

                    int orderId = order.Id;

                    var productOrderMapper = new ProductOrderMapper
                    {
                        ProductId = productId,
                        OrderId = orderId
                    };
                    db.ProductOrderMappers.Add(productOrderMapper);
                    db.SaveChanges();

                    var pcomMapper = new ProductColorOrderMapper
                    {
                        ProductId = productId,
                        OrderId = orderId,
                        ColorId = colorId
                    };
                    db.ProductColorOrderMappers.Add(pcomMapper);
                    db.SaveChanges();

                    var posm = new ProductOrderSizeMapper
                    {
                        ProductId = productId,
                        OrderId = orderId,
                        SizeId = sizeId
                    };
                    db.ProductOrderSizeMappers.Add(posm);
                    db.SaveChanges();
                }

                return RedirectToAction("UserDashboard", "Home");
            }
            else
            {
                ViewBag.Error = "Product Stock out";
                return View("Error");
            }
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

        [HttpGet]
        public ActionResult GetProductsByCategory(int categoryId)
        {


            return View();
        }

    }

}
