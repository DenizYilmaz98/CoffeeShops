using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShops.API.Models.OrderModel
{
    public class AddOrderInputModel
    {
        public Guid  TableId { get; set; }
        public Guid ProductId { get; set; }
    }
}
