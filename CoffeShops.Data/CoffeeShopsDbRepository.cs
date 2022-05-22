using CoffeShops.Data.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShops.Data
{
    public class CoffeeShopsDbRepository<TEntity>:ICoffeeShopsDbRepository<TEntity> where TEntity: class, new()
    {
        private readonly CoffeeShopsDbContext _coffeeShopsDbContext;

        public CoffeeShopsDbRepository(CoffeeShopsDbContext coffeeShopsDbContext)
        {
            _coffeeShopsDbContext = coffeeShopsDbContext;
        }
        public TEntity GetById(Guid id)
        {

            return _coffeeShopsDbContext.Set<TEntity>().Find(id);
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return _coffeeShopsDbContext.Set<TEntity>().ToList();
            }
            else
            {
                return _coffeeShopsDbContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Insert(TEntity entity)
        {
            _coffeeShopsDbContext.Set<TEntity>().Add(entity);
            _coffeeShopsDbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _coffeeShopsDbContext.Set<TEntity>().Update(entity);
            _coffeeShopsDbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _coffeeShopsDbContext.Set<TEntity>().Remove(entity);
            _coffeeShopsDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = _coffeeShopsDbContext.Set<TEntity>().Find(id);
            _coffeeShopsDbContext.Set<TEntity>().Remove(entity);
            _coffeeShopsDbContext.SaveChanges();
        }
        public IQueryable<TEntity> GetAllInclude(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] include)
        {

            var query = _coffeeShopsDbContext.Set<TEntity>().Where(filter);
            return include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        }

        public bool Any(Expression<Func<TEntity, bool>> exp)
        {
            throw new NotImplementedException();
        }
    }
}


