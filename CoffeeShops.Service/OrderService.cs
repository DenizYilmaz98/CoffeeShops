using CoffeeShops.Service.Abstracts;
using CoffeeShops.Service.Models;
using CoffeeShops.Service.Models.OrderModel;
using CoffeShops.Data.Abstracts;
using CoffeShops.Data.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShops.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

      
        public Guid CreateOrder(CreateOrderDto createOrderDto)
        {
            var product = _productRepository.Get(createOrderDto.CompanyId, createOrderDto.ProductId);

            var order = new Order();
            order.Id = Guid.NewGuid();
            order.CompanyId = createOrderDto.CompanyId;
            order.TableId = createOrderDto.TableId;
            order.ProductId = createOrderDto.ProductId;
            order.ProductPrice = product.Unitprice;
            order.OrderDate = DateTime.Now;

            _orderRepository.Insert(order);
            return order.Id;


        }

        public List<OrderListByKitchenIdViewDto> GetOrderListForKitchen(Guid companyId)
        {
            var orders = _orderRepository.GetAllInclude(r =>r.CompanyId == companyId &&  r.StatusId == 0, r => r.Product,t=>t.Table).OrderBy(r => r.OrderDate).ToList();
            return orders.Select(r => new OrderListByKitchenIdViewDto()
            {
                OrderId = r.Id,
                ProductName  = r.Product.ProductName,
                 TableName = r.Table.TableNo
            }).ToList();
        }

        public List<OrderListByTableIdViewDto> GetOrderListByTableId(Guid TableId)
        {
            var orders = _orderRepository.GetAllInclude(r => r.TableId == TableId && (r.StatusId == 0 || r.StatusId == 2) ,r=>r.Product)
                .OrderBy(r=>r.OrderDate).ToList();
            return orders.Select(r => new OrderListByTableIdViewDto() 
            {
                OrderId=r.Id,
                ProductName = r.Product.ProductName,
                ProductPrice = r.ProductPrice ,
                StatusId=r.StatusId
                
            }).ToList();
        }
      
        public void Payment(List<Guid> orderIds, int paymentTypeId)
        {
            _orderRepository.SetPayment(orderIds, paymentTypeId);
        }
        public void KitchenStatus(Guid orderId)
        {
            _orderRepository.KitchenStatus(orderId);
        }
    }
}
