using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShops.Service.Models
{
   public class RegisterDto
    {
        [Required(ErrorMessage = "Dükkan İsim Alani boş olamaz")]
        [MaxLength(50)]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Kullanici Alani boş olamaz")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Kullanici Alani boş olamaz")]
        [MaxLength(50)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Kullanici Alani boş olamaz")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alani Zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
