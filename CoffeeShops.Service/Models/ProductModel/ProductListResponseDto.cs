using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShops.Service.Models
{
    public class ProductListResponseDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string ProductName { get; set; }
        public decimal Unitprice { get; set; }
    }
}
