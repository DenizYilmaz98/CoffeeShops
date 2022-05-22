using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShops.Service.Models.TableModel
{
    public class TableListViewDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string TableNo { get; set; }
    }
}
