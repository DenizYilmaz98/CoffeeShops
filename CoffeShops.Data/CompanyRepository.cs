using CoffeShops.Data.Abstracts;
using CoffeShops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShops.Data
{
    public class CompanyRepository : CoffeeShopsDbRepository<Company>,ICompanyRepository
    {
        private readonly CoffeeShopsDbContext _coffeeShopsDbContext;

        public CompanyRepository(CoffeeShopsDbContext coffeeShopsDbContext) : base(coffeeShopsDbContext)
        {
            _coffeeShopsDbContext = coffeeShopsDbContext;
        }

        public void Delete(Guid companyId)
        {
            _coffeeShopsDbContext.Companies.Where(m=>m.Id==companyId);
            _coffeeShopsDbContext.Remove(companyId);
        }

        public void Update(Guid companyId)
        {
            _coffeeShopsDbContext.Companies.Select(m=>m.Id==companyId);
            _coffeeShopsDbContext.Update(companyId);
            _coffeeShopsDbContext.SaveChanges();
        }
    }
}
