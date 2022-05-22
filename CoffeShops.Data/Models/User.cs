using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShops.Data.Models
{
    [Table("User")]
    public class User:BaseEntity
    {
        public Guid CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordEncrypted { get; set; }
        public string PasswordSalt { get; set; }
        public Company Company { get; set; }

    }
}
