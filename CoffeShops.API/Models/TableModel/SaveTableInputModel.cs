
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShops.API.Models
{
    public class SaveTableInputModel
    {
        public Guid Id { get; set; }
        public string TableNo { get; set; }
    }
}
