using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShops.API.Models.TableModel
{
    public class TableListViewModel
    {
        public List<TableViewModel> List { get; set; }
    }
    public class TableViewModel
    {
        public Guid Id { get; set; }
        public string TableNo { get; set; }
    }
}
