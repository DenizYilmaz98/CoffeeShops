using CoffeeShops.Service.Abstracts;
using CoffeeShops.Service.Models;
using CoffeeShops.Service.Models.TableModel;
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
    public class TableService : ITableService
    {

        private readonly ITableRepository _tableRepository;
        private readonly IOrderRepository _orderRepository;

        public TableService(ITableRepository tableRepository,IOrderRepository orderRepository)

        {
            _tableRepository = tableRepository;
            _orderRepository = orderRepository;
        }



        public Guid Save(TableDto tableDto)
        {

            var table = new Table();

          
            table.TableNo = tableDto.TableNo;
            table.CompanyId = tableDto.CompanyId;
            if (tableDto.Id == Guid.Empty)
            {


                table.Id = Guid.NewGuid();
                _tableRepository.Insert(table);
            }
            else
            {
                table.Id = tableDto.Id;
                _tableRepository.Update(table);
            }
            return table.Id;


        }

      
        public List<TableListViewDto> List(Guid companyId)
        {


            List<Table> tables = _tableRepository.List(companyId);
            return tables.Select(m => m.Adapt<TableListViewDto>()).ToList();
        }

      
        public void Delete(Guid companyId, Guid tableId)
        {
            _tableRepository.Delete(companyId,tableId);
        }

      

        public TableGetResponseDto Get(Guid companyId, Guid tableId)
        {
            var table = _tableRepository.Get(companyId, tableId);
            return table.Adapt<TableGetResponseDto>();
        }
         
        
    }
}


