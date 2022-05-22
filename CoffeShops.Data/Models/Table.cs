using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShops.Data.Models
{
    [Table("Table")]
    public class Table:BaseEntity
    {
        public Guid CompanyId { get; set; }
        public string TableNo { get; set; }
    }
}
