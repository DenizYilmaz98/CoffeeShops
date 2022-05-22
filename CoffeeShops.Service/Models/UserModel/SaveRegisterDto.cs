using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShops.Service.Models.UserModel
{
   public class SaveRegisterDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }



        
        public string FirstName { get; set; }

        public string LastName { get; set; }


       
        public string Email { get; set; }

       
        public string Password { get; set; }
    }
}