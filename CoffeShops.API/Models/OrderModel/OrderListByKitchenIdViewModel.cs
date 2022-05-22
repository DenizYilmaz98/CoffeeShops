using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShops.API.Models.OrderModel
{

    public class OrderListByKitchenIdViewModel
    {
        public List<OrderListByKitchenIdRowViewModel> List { get; set; }
    }
    public class OrderListByKitchenIdRowViewModel
    {
        public Guid OrderId { get; set; }
        public string ProductName { get; set; }
        public string TableName { get; set; }
    }
}
