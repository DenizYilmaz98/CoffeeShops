using CoffeeShops.Service;
using CoffeShops.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShops.Data
{
    public class OrderRepository : CoffeeShopsDbRepository<Order>,IOrderRepository
    {
        private readonly CoffeeShopsDbContext _coffeeShopsDbContext;

        public OrderRepository(CoffeeShopsDbContext coffeeShopsDbContext) : base(coffeeShopsDbContext)
        {
            _coffeeShopsDbContext = coffeeShopsDbContext;
        }
        public void Add(Order order)
        {
            _coffeeShopsDbContext.Add(order);
            _coffeeShopsDbContext.SaveChanges();

        }
       
        public void Delete(Guid companyId)
        {
            _coffeeShopsDbContext.Remove(companyId);
            _coffeeShopsDbContext.SaveChanges();
        }

        public void KitchenStatus(Guid orderId)
        {
            var order = new Order();
                order.Id = orderId;
                order.StatusId = 2;
              
                _coffeeShopsDbContext.Orders.Attach(order);
                _coffeeShopsDbContext.Entry(order).Property(x => x.StatusId).IsModified = true;
            
            _coffeeShopsDbContext.SaveChanges();
        }
    

        public List<Order> List(Guid companyId)
        {
            return _coffeeShopsDbContext.Orders.ToList();
        }

        public void SetPayment(List<Guid> orderIds, int paymentTypeId)
        {
            foreach (var orderId in orderIds)
            {
                var order = new Order();
                order.Id = orderId;
                order.StatusId = 1;
                order.PaymentTypeId = paymentTypeId;
                _coffeeShopsDbContext.Orders.Attach(order);
                _coffeeShopsDbContext.Entry(order).Property(x => x.StatusId).IsModified = true;
                _coffeeShopsDbContext.Entry(order).Property(x => x.PaymentTypeId).IsModified = true;
            }
            _coffeeShopsDbContext.SaveChanges();
        }
    }
}
