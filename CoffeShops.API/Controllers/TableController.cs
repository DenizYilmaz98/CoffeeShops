using CoffeeShops.API.Attributes;
using CoffeeShops.API.Models;
using CoffeeShops.API.Models.TableModel;
using CoffeeShops.Service.Abstracts;
using CoffeeShops.Service.Models;
using CoffeeShops.Service.Models.TableModel;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoffeeShops.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;
        private readonly UserContext _userContext;
        

       
        public TableController(ITableService tableService,UserContext userContext)
        {
            _tableService = tableService;
            _userContext = userContext;
        }
      
        [HttpPost("Save")]
        [Authorize]
        public SaveTableViewModel Save(SaveTableInputModel saveTableInput)
        {

            var model = saveTableInput.Adapt<TableDto>();
            model.CompanyId = _userContext.CompanyId;
            var tableId =_tableService.Save(model);
            return new SaveTableViewModel() { TableId= tableId};
        }       

        [HttpPost("Get")]
        [Authorize]
        public GetTableViewModel Get(Guid id)
        {
            var table = _tableService.Get(_userContext.CompanyId, id);
            return table.Adapt<GetTableViewModel>();
        }


        [HttpPost("List")]
        [Authorize]
        public TableListViewModel List()
        {
            var tableResponseModel = _tableService.List(_userContext.CompanyId);

            return new TableListViewModel()
            {
                List = tableResponseModel.Select(m => m.Adapt<TableViewModel>())
                .OrderBy(r=>r.TableNo)
                .ToList()
            };
        }
        [HttpPost("Delete")]
        [Authorize]
        public void Delete(Guid id)
        {
            _tableService.Delete(_userContext.CompanyId,id);
        }

    }
}