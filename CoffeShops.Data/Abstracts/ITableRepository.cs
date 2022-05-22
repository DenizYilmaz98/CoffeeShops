using CoffeShops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShops.Data.Abstracts
{
   public interface ITableRepository:ICoffeeShopsDbRepository<Table>
    {
        List<Table> List(Guid companyId);
        void Delete(Guid companyId, Guid tableId);
        Table Get(Guid companyId, Guid id);



    }
}
