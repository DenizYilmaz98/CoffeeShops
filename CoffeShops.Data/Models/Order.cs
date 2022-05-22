
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShops.Data.Models
{
    [Table("Order")]
    public class Order:BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid CompanyId { get; set; }
        public Guid TableId { get; set; }
        public Table Table { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public int StatusId { get; set; }
        public int PaymentTypeId { get; set; }

    }
}
