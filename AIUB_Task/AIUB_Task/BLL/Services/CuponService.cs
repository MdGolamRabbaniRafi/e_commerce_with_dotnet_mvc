using AIUB_Task.BLL.DTOs;
using AIUB_Task.Classes;
using AIUB_Task.DAL.EF;
using AIUB_Task.DAL.Repos;
using AIUB_Task.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIUB_Task.BLL.Services
{
    public class CuponService
    {
        public static bool AddCupon(CuponDTO cupon)
        {
            var mapper = MapperClass.MappedCupon(cupon);
            var Cupon1 = mapper.Map<Cupon>(cupon);
            return CuponRepo.AddCupon(Cupon1);
        }
        public static CuponDTO SearchCupon(int id)
        {
            var cupon = CuponRepo.SearchCupon(id);
            var mapper = MapperClass.MappedaCupon(cupon);
            var Cupon1 = mapper.Map<CuponDTO>(cupon);
            return Cupon1;
        }
        public static bool ConfirmDelete(int id)
        {

            return CuponRepo.ConfirmDelete(id);
        }
    }
}