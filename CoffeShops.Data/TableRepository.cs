using CoffeShops.Data.Abstracts;
using CoffeShops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShops.Data
{
    public class TableRepository : CoffeeShopsDbRepository<Table>,ITableRepository
    {
        private readonly CoffeeShopsDbContext _coffeeShopsDbContext;

        public TableRepository(CoffeeShopsDbContext coffeeShopsDbContext) : base(coffeeShopsDbContext)
        {
            _coffeeShopsDbContext = coffeeShopsDbContext;
        }
        public void Save(Table table)
        {
            _coffeeShopsDbContext.Add(table);
            _coffeeShopsDbContext.SaveChanges();
        }

        public List<Table> List(Guid companyId)
        {

            return _coffeeShopsDbContext.Tables.Where(m => m.CompanyId == companyId).ToList();
        }
        public void Delete(Guid companyId, Guid tableId)
        {
            var table = _coffeeShopsDbContext.Tables.Where(m => m.CompanyId == companyId && m.Id == tableId).FirstOrDefault();
            _coffeeShopsDbContext.Tables.Remove(table);
            _coffeeShopsDbContext.SaveChanges();

        }

        public Table Get(Guid companyId, Guid id)
        {
            return _coffeeShopsDbContext.Tables.Where(m => m.CompanyId == companyId && m.Id==id).FirstOrDefault();
        }

    }
}
