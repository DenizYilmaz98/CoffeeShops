using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShops.Service.Models.OrderModel
{
    public class CreateOrderDto
    {
        public Guid ProductId { get; set; }
        public Guid TableId { get; set; }
        public Guid CompanyId { get; set; }

    }
}
