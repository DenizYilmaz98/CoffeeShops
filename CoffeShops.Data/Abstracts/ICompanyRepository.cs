using CoffeShops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShops.Data.Abstracts
{
    public interface ICompanyRepository:ICoffeeShopsDbRepository<Company>
    {
        void Update(Guid companyId);
        void Delete(Guid companyId);
    }
}
