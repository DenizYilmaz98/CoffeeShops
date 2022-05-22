using CoffeeShops.Service.Models;
using CoffeeShops.Service.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShops.Service.Abstracts
{
   public interface ITableService
    {
        public Guid Save(TableDto tableDto);
        public List<TableListViewDto> List(Guid tableId);
        void Delete(Guid companyId,Guid tableId);
        TableGetResponseDto Get(Guid companyId, Guid tableId);
    }
}
