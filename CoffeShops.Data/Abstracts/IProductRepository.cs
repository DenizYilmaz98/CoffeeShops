using CoffeShops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShops.Data.Abstracts
{
   public interface IProductRepository:ICoffeeShopsDbRepository<Product>
    {
        void Add(Product product);
        List<Product> List(Guid companyId);
        void Delete(Guid companyId,Guid productId);
        Product Get(Guid companyId, Guid id);
    }
}
