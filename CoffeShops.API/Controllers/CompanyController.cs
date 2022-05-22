using CoffeeShops.API.Attributes;
using CoffeeShops.Service.Abstracts;
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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        
        [HttpPost("Update")]
        [Authorize]
        public void Update(Guid companyId)
        {
            _companyService.Update(companyId);
        }
        [HttpPost("Delete")]
        [Authorize]
        public void Delete(Guid companyId)
        {
            _companyService.Delete(companyId);
        }
    }
}
