using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShops.API.Models
{
    public class SaveProductInputModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal Unitprice { get; set; }
    }
}
