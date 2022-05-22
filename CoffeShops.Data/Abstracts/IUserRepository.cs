using CoffeShops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShops.Data.Abstracts
{
   public interface IUserRepository:ICoffeeShopsDbRepository<User>
    {
        List<User> ListUsers(Guid companyId);
        User Get(Guid companyId, Guid id);
        void Delete(Guid companyId, Guid userId);

    }
}
