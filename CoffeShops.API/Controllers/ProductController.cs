using CoffeeShops.API.Attributes;
using CoffeeShops.API.Models;
using CoffeeShops.Service.Abstracts;
using CoffeeShops.Service.Models;
using CoffeShops.Data.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShops.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
       
        private readonly IProductService _productService;
        private readonly UserContext _userContext;

        public ProductController(IProductService productService,UserContext userContext)
        {
            
            _productService = productService;
            _userContext = userContext;
         
        }
       
        [HttpPost("Save")]
        [Authorize]
        public SaveProductViewModel Save(SaveProductInputModel saveProductInput)
        {
            var model = saveProductInput.Adapt<ProductDto>();
            model.CompanyId = _userContext.CompanyId;
            var productId = _productService.Save(model);
            return new SaveProductViewModel() { ProductId=productId};
        }
        [HttpPost("Get")]
        [Authorize]
        public GetProductViewModel Get(Guid id)
        {
            var product = _productService.Get(_userContext.CompanyId,id);
            return product.Adapt<GetProductViewModel>();
        }

        [HttpPost("List")]
        [Authorize]
        public ProductListViewModel List()
        {
            var productResponseModel =_productService.List(_userContext.CompanyId);

            return new ProductListViewModel()
            {
                List =productResponseModel.Select(m=>m.Adapt<ProductViewModel>()).ToList()
            };
     
        }
        [HttpPost("Delete")]
        [Authorize]
        public void Delete(Guid id)
        {           
            _productService.Delete(_userContext.CompanyId,id);
        }
    }
}
