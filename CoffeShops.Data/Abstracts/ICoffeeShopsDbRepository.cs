using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShops.Data.Abstracts
{
   public interface ICoffeeShopsDbRepository<TEntity> where TEntity : class, new()
    {

        public void Insert(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public void Delete(Guid id);

        public TEntity GetById(Guid id);
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);

        public IQueryable<TEntity> GetAllInclude(Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] include);

    }
}

