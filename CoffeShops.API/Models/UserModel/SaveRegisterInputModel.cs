using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShops.API.Models.UserModel
{
    public class SaveRegisterInputModel
    {
        public Guid Id { get; set; }

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
