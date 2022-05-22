using CoffeShops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShops.API.Models.UserModel
{
    public class UserListIdViewModel
    {
      
        public List<UserListByTableIdRowViewModel> List { get; set; }
        
        public class UserListByTableIdRowViewModel
        {
            public Guid Id { get; set; }
            public Guid CompanyId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }


        }
    }
}
