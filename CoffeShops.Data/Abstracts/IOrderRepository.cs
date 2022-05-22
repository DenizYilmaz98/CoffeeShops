using CoffeShops.Data.Abstracts;
using CoffeShops.Data.Models;
using System;
using System.Collections.Generic;

namespace CoffeeShops.Service
{
    public interface IOrderRepository: ICoffeeShopsDbRepository<Order>
    {
        void Add(Order order);
        List<Order>List(Guid companyId);
        void Delete(Guid companyId);
        void SetPayment(List<Guid> orderIds, int paymentTypeId);
        void KitchenStatus(Guid orderId);
    }
}