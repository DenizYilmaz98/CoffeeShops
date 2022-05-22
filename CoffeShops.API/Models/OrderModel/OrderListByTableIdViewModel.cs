using System;
using System.Collections.Generic;

namespace CoffeeShops.API.Models.OrderModel
{
    public class OrderListByTableIdViewModel 
    {
        public List<OrderListByTableIdRowViewModel> List { get; set; }
    }
    public class OrderListByTableIdRowViewModel
    {
        public Guid OrderId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int StatusId { get; set; }

    }
}
