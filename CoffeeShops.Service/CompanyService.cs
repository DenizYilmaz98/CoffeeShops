using CoffeeShops.Service.Abstracts;
using CoffeShops.Data.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShops.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public void Delete(Guid companyId)
        {
            _companyRepository.Delete(companyId);
        }

        public void Update(Guid companyId)
        {
            _companyRepository.Update(companyId);
        }
    }
}
