using AIUB_Task.BLL.DTOs;
using AIUB_Task.BLL.Services;
using AIUB_Task.Classes;
using AIUB_Task.DAL.EF;
using AIUB_Task.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIUB_Task.Controllers
{
    public class CuponController : Controller
    {
        // GET: Cupon
        [Logged]
        [AdminCheck]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Logged]
        [AdminCheck]
        public ActionResult AddCupon()
        {
            return View();
        }
        [HttpGet]
        [Logged]
        [AdminCheck]
        public ActionResult AvailableCupon()
        {
            using (var db = new AIUB_TaskEntities1())
            {
                var cupons = db.Cupons.ToList();
                foreach (var cupon in cupons)
                {
                    if (cupon.Expire_date < DateTime.Today)
                    {
                        cupon.Status = "Expired";
                        db.Entry(cupon).State = EntityState.Modified;
                    }
                }
                db.SaveChanges();
                return View(cupons);
            }
        }


        [HttpPost]
        [Logged]
        [AdminCheck]
        public ActionResult AddCupon(CuponDTO cuponDTO)
        {
            if (ModelState.IsValid)
            {
                var cupon = CuponService.AddCupon(cuponDTO);

                if (cupon)
                {
                    return RedirectToAction("Index", "Cupon");
                }

                return View();
            }
            return View(cuponDTO);
        }
        [Logged]
        [HttpPost]
        public JsonResult CheckCoupon(string Name)
        {
            bool isAvailable = false;
            decimal discount = 0;

            if (!string.IsNullOrEmpty(Name))
            {
                var db = new AIUB_TaskEntities1();


                var coupon = db.Cupons.SingleOrDefault(c => c.Name.ToLower() == Name.ToLower() && c.Status == "Active");
                if (coupon != null)
                    {
                        isAvailable = true;
                        discount = (int)coupon.Perchentage; 
                    }
                
            }

            return Json(new { isAvailable = isAvailable, discount = discount });
        }
        [Logged]
        [AdminCheck]
        [HttpGet]
        public ActionResult UpdateCupon(int id)
        {
            var db = new AIUB_TaskEntities1();
            var cupon = CuponService.SearchCupon(id);

            if (cupon == null)
            {
                return HttpNotFound();
            }

            var cuponDTO = new CuponDTO
            {
                Id = cupon.Id,
                Name = cupon.Name,
                Perchentage = cupon.Perchentage,
                Expire_date = cupon.Expire_date,
                Status = cupon.Status?.Trim()
            };

            return View(cuponDTO);
        }

        [Logged]
        [AdminCheck]
        [HttpPost]
        public ActionResult UpdateCupon(CuponDTO model)
        {
            if (ModelState.IsValid)
            {
                var db = new AIUB_TaskEntities1();
                var coupon = db.Cupons.Find(model.Id);
                if (coupon == null)
                {
                    return HttpNotFound();
                }

                coupon.Name = model.Name;
                coupon.Perchentage = model.Perchentage;
                coupon.Status = model.Status.Trim(); 

                coupon.Expire_date=model.Expire_date;
                db.SaveChanges();

                return RedirectToAction("AvailableCupon");
            }
            return View(model);
        }

        [Logged]
        [AdminCheck]
        [HttpGet]
        public ActionResult DeleteCupon(int id)
        {
            ViewBag.id = id;

            return View();
        }
        [Logged]
        [AdminCheck]
        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            var delete = CuponService.ConfirmDelete(id);
            if (delete)
            {
                return RedirectToAction("AvailableCupon", "Cupon");
            }

            ViewBag.ErrorMessage = "Unable to delete the cupon. Please try again.";
            return View();
        }

    }
}