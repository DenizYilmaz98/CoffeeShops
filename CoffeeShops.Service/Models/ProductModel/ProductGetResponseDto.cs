using System;

namespace CoffeeShops.Service.Models
{
    public class ProductGetResponseDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string ProductName { get; set; }
        public decimal Unitprice { get; set; }
    }
}
