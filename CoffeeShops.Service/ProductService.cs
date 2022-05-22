using CoffeeShops.Service.Abstracts;
using CoffeeShops.Service.Models;
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
    public class ProductService : IProductService
    {
    
        private readonly IProductRepository _productRepository;
        private readonly ICompanyRepository _companyRepository;

        public ProductService(IProductRepository productRepository, ICompanyRepository companyRepository)
        {
            
            _productRepository = productRepository;
            _companyRepository = companyRepository;
        }
        public Guid Save(ProductDto productDto)
        {

            var product = new Product();

           
            product.ProductName = productDto.ProductName;
            product.Unitprice = productDto.Unitprice;
            product.CompanyId = productDto.CompanyId;

            if (productDto.Id == Guid.Empty)
            {
                product.Id = Guid.NewGuid();
                _productRepository.Insert(product);
            }
            else
            {
                product.Id = productDto.Id;
                _productRepository.Update(product);
            }

            return product.Id;

        }

        public void Delete(Guid companyId, Guid productId)
        {
            _productRepository.Delete(companyId,productId);
        }

        public List<ProductListResponseDto> List(Guid companyId)
        {

            List< Product> products = _productRepository.List(companyId);
            return products.Select(m => m.Adapt<ProductListResponseDto>()).ToList();
        }

        public ProductGetResponseDto Get(Guid companyId, Guid productId)
        {
            var product = _productRepository.Get(companyId, productId);
            return product.Adapt<ProductGetResponseDto>();
        }
    }
  
}
