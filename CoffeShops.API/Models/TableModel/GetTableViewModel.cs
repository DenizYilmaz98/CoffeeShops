using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShops.API.Models.TableModel
{
    public class GetTableViewModel
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string TableNo { get; set; }
    }
}
