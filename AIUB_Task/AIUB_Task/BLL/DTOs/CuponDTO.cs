using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIUB_Task.DTO
{
    public class CuponDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Perchentage { get; set; }
        public DateTime? Expire_date { get; set; }
        public string Status { get; set; }
    }
}
