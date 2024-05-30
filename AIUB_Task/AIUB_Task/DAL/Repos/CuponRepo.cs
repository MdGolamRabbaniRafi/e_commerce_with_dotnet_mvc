using AIUB_Task.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIUB_Task.DAL.Repos
{
    public class CuponRepo
    {
        public static bool AddCupon(Cupon cupon)
        {
            var db = new AIUB_TaskEntities1();
            db.Cupons.Add(cupon);
            var a = db.SaveChanges();
            if (a > 0)
            {
                return true;
            }
            return false;
        }

        public static bool AddCAupon(Cupon cupon)
        {
            var db = new AIUB_TaskEntities1();
            db.Cupons.Add(cupon);
            var a = db.SaveChanges();
            if (a > 0)
            {
                return true;
            }
            return false;
        }
        public static Cupon SearchCupon(int Id)
        {
            var db = new AIUB_TaskEntities1();
            var cupon = db.Cupons.Find(Id);
            if (cupon != null)
            {
                db.SaveChanges();
                return cupon;
            }
            return null;
        }


        public static bool ConfirmDelete(int id)
        {
            var db = new AIUB_TaskEntities1();
            var cupon = db.Cupons.Find(id);
            db.Cupons.Remove(cupon);
            var a = db.SaveChanges();

            if (a>0)
            {
                return true;

            }
            return false;

        }
    }
}