using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShops.API.Models
{
    public class GetProductViewModel
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string ProductName { get; set; }
        public decimal Unitprice { get; set; }
    }
}
