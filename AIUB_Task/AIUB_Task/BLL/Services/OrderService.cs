using AIUB_Task.Classes;
using AIUB_Task.DAL.EF;
using AIUB_Task.DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIUB_Task.BLL.Services
{
    public class OrderService
    {
        public static List<Order> FindOrder(int Userid)
        {

            return OrderRepo.FindOrder(Userid);
        }
    }
}