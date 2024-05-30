using AIUB_Task.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIUB_Task.DAL.Repos
{
    public class OrderRepo
    {
        public static List<Order> FindOrder(int Userid)
        {
            var db = new AIUB_TaskEntities1();
            return db.Orders.Where(o => o.UserId == Userid).ToList();
        }

    }
}