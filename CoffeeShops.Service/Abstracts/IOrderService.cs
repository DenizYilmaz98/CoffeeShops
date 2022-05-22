using CoffeeShops.Service.Models;
using CoffeeShops.Service.Models.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShops.Service.Abstracts
{
    public interface IOrderService
    {
        //public Guid Add(AddOrderDto orderDto);
        //List<OrderListResponseDto> List(Guid orderId);
        //void Delete(Guid orderId);
        public Guid CreateOrder(CreateOrderDto createOrderDto);
        public List<OrderListByTableIdViewDto> GetOrderListByTableId(Guid TableId);
        public List<OrderListByKitchenIdViewDto> GetOrderListForKitchen(Guid companyId);
        public void Payment(List<Guid> orderIds, int paymentTypeId);
        public void KitchenStatus(Guid orderId);

    }
}
