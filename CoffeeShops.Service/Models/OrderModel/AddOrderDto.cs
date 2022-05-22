using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShops.Service.Models.OrderModel
{
    public class AddOrderDto
    {
        public Guid CompanyId { get; set; }
        public string OrderName { get; set; }
    }
}
