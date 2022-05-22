using CoffeShops.Data.Abstracts;
using CoffeShops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShops.Data
{
    public class ProductRepository : CoffeeShopsDbRepository<Product>, IProductRepository
    {
        private readonly CoffeeShopsDbContext _coffeeShopsDbContext;

        public ProductRepository(CoffeeShopsDbContext coffeeShopsDbContext) : base(coffeeShopsDbContext)
        {
            _coffeeShopsDbContext = coffeeShopsDbContext;
        }
        
        public void Add(Product product)
        {
            _coffeeShopsDbContext.Products.Add(product);
            _coffeeShopsDbContext.SaveChanges();
        }

        public List<Product> List(Guid companyId)
        {
            return _coffeeShopsDbContext.Products.Where(m=>m.CompanyId==companyId).ToList();
        }
        public void Delete(Guid companyId,Guid productId)
        {
            var productEntity = _coffeeShopsDbContext.Products.Where(m=>m.CompanyId==companyId &&m.Id==productId).FirstOrDefault();
            _coffeeShopsDbContext.Remove(productEntity);
            _coffeeShopsDbContext.SaveChanges();
        }
        public Product Get(Guid companyId,Guid id)
        {
            return _coffeeShopsDbContext.Products.Where(m => m.CompanyId == companyId && m.Id == id).FirstOrDefault();
        }
    }
}
