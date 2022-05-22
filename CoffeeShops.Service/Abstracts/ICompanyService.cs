using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShops.Service.Abstracts
{
   public interface ICompanyService
    {
        void Update(Guid companyId);
        void Delete(Guid companyId);
    }
}
