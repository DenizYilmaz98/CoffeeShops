using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShops.API.Models
{
    public class UserContext
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
