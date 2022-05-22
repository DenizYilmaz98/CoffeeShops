using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShops.API.Models
{
    public class UserDetailViewModel
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string CompanyName { get; set; }
    }
}
