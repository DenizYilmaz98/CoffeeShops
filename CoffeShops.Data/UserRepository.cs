using CoffeShops.Data.Abstracts;
using CoffeShops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeShops.Data
{
    public class UserRepository : CoffeeShopsDbRepository<User>,IUserRepository
    {
        private readonly CoffeeShopsDbContext _coffeeShopsDbContext;

        public UserRepository(CoffeeShopsDbContext coffeeShopsDbContext) : base(coffeeShopsDbContext)
        {
            _coffeeShopsDbContext = coffeeShopsDbContext;
        }

        public List<User> ListUsers(Guid companyId)
        {
            return _coffeeShopsDbContext.Users.Where(m => m.CompanyId == companyId).ToList();
            
        }
        public User Get(Guid companyId, Guid id)
        {
            return _coffeeShopsDbContext.Users.Where(m => m.CompanyId == companyId && m.Id==id).FirstOrDefault();
        }

        public void Delete(Guid companyId, Guid userId)
        {
            var user = _coffeeShopsDbContext.Users.Where(m => m.CompanyId == companyId && m.Id == userId).FirstOrDefault();
            _coffeeShopsDbContext.Users.Remove(user);
            _coffeeShopsDbContext.SaveChanges();
        

        }
    }
}
