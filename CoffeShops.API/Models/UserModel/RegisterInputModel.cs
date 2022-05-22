using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShops.API.Models
{
    public class RegisterInputModel
    {
     
        [MaxLength(50)]
        public string CompanyName { get; set; }

     
        [MaxLength(50)]
        public string FirstName { get; set; }

      
        [MaxLength(50)]
        public string LastName { get; set; }


        [MaxLength(50)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

