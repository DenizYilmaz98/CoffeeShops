using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShops.UI.Controllers
{
    [Route("Dashboard")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Table/{id}")]
        public IActionResult Table(Guid id)
        {
            return View("~/Views/Dashboard/Table/Index.cshtml",id);
        }
        [HttpGet("Table/KitchenOrder")]
        public IActionResult KitchenOrder()
        {
            return View("~/Views/Dashboard/Table/KitchenOrder.cshtml");
        }

      
    }
}
