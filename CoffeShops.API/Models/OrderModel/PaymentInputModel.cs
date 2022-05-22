using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShops.API.Models.OrderModel
{
    public class PaymentInputModel
    {
        public List<Guid> OrderIds { get; set; }
        public int PaymentTypeId { get; set; }
    }
}
