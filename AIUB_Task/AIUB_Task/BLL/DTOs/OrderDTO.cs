using System;

namespace AIUB_Task.BLL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public decimal TotalOrderPrice { get; set; }
        public string Number { get; set; }
        public int Quantity { get; set; }

    }
}
