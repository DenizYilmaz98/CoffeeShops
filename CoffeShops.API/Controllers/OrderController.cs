using CoffeeShops.API.Attributes;
using CoffeeShops.API.Models;
using CoffeeShops.API.Models.OrderModel;
using CoffeeShops.Service.Abstracts;
using CoffeeShops.Service.Models.OrderModel;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShops.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly UserContext _userContext;

        public OrderController(IOrderService orderService,UserContext userContext)
        {
            _orderService = orderService;
            _userContext = userContext;
        }
        [HttpPost("Add")]
        [Authorize]
        public AddOrderViewModel CreateOrder(AddOrderInputModel addOrderInputModel)
        {

            var model = addOrderInputModel.Adapt<CreateOrderDto>();
            model.CompanyId = _userContext.CompanyId;
            var orderId = _orderService.CreateOrder(model);
            return new AddOrderViewModel() { OrderId = orderId };
        }
        [HttpPost("Payment")]
        [Authorize]
        public void Payment([FromBody] PaymentInputModel model) 
        {
            _orderService.Payment(model.OrderIds, model.PaymentTypeId);
        }
        [HttpPost("KitchenStatus")]
        [Authorize]
        public void KitchenStatus([FromBody] KitchenStatusInputModel model)
        {
            _orderService.KitchenStatus(model.OrderId);
        }

        [HttpPost("ListByTableId")]
        [Authorize]
        public OrderListByTableIdViewModel GetOrderListByTableId(Guid TableId)
        {
            var orders = _orderService.GetOrderListByTableId(TableId);
            return new OrderListByTableIdViewModel()
            {
                List = orders.Select(r => r.Adapt<OrderListByTableIdRowViewModel>()).ToList()
            };

        }

        [HttpPost("ListForKitchen")]
        [Authorize]
        public OrderListByKitchenIdViewModel GetOrderListForKitchen()
        {
            var orders = _orderService.GetOrderListForKitchen(_userContext.CompanyId);
            return new OrderListByKitchenIdViewModel()
            {
                List = orders.Select(r => r.Adapt<OrderListByKitchenIdRowViewModel>()).ToList()
            };

        }


        //[HttpPost("Add")]
        //[Authorize]
        //public AddOrderViewModel Add(AddOrderInputModel addOrderInputModel)
        //{
        //    var model = addOrderInputModel.Adapt<AddOrderDto>();
        //    model.CompanyId = _userContext.CompanyId;
        //    var orderId = _orderService.Add(model);
        //    return new AddOrderViewModel { OrderId=orderId};

        //}


        //[HttpPost("List")]
        //[Authorize]
        //public OrderListViewModel List()
        //{
        //    var orderResponseModel = _orderService.List(_userContext.CompanyId);

        //    return new OrderListViewModel()
        //    {
        //        List = orderResponseModel.Select(m => m.Adapt<OrderListViewModel>()).ToList()
        //    };
        //}

        //[HttpPost("Delete")]
        //[Authorize]
        //public void Delete(Guid companyId)
        //{
        //    _orderService.Delete(companyId);
        //}
    }
}
