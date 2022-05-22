using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShops.Data.Models
{
    [Table("Company")]
    public class Company:BaseEntity
    {
        public string Name { get; set; }
    }
}
