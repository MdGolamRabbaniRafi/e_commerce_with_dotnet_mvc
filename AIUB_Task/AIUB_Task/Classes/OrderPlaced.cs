using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIUB_Task.Classes
{
    public class OrderPlaced
    {
            public int ProductId { get; set; }
            public int Price { get; set; }
            public int ColorId { get; set; }
            public int SizeId { get; set; }
    }
}