using System;

namespace CoffeeShops.Service.Models.OrderModel
{
    public class OrderListByTableIdViewDto
    {
        public Guid OrderId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int StatusId { get; set; }
    }
}
