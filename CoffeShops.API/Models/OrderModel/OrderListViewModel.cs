using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShops.API.Models.OrderModel
{
    public class OrderListViewModel
    {
        public List<OrderListViewModel> List { get; set; }
    }
    public class OrderViewModel
    {
        public string OrderName { get; set; }
    }
}
