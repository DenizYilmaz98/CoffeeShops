using CoffeeShops.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShops.Service.Abstracts
{
   public interface IProductService
    {
        public Guid Save(ProductDto productDto);
        List<ProductListResponseDto> List(Guid companyId);
        void Delete(Guid companyId,Guid productId);
        ProductGetResponseDto Get(Guid companyId, Guid productId);
    }
}
