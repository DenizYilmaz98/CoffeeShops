using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShops.Data.Models
{
    [Table("Product")]
    public class Product:BaseEntity
    {
        public Guid CompanyId { get; set; }
        public string ProductName { get; set; }
        public decimal Unitprice { get; set; }
    }
}
