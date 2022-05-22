using CoffeeShops.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShops.UI.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        public AdminController(IOptions<AppSettings> options)
        {              
           
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Table")]
        public IActionResult Table()
        {
            return View("~/Views/Admin/Table/List.cshtml");
        }
        [HttpGet("Table/Detail")]
        public IActionResult TableDetail(Guid id)
        {
            return View("~/Views/Admin/Table/Detail.cshtml", id);
        }
        [HttpGet("Table/Add")]
        public IActionResult TableAdd()
        {
            return View("~/Views/Admin/Table/Detail.cshtml");
        }
        [HttpGet("Product")]
        public IActionResult Product()
        {
            return View("~/Views/Admin/Product/List.cshtml");
        }
        [HttpGet("Product/Detail")]
        public IActionResult ProductDetail(Guid id)
        {
            return View("~/Views/Admin/Product/Detail.cshtml",id);
        }
        [HttpGet("Product/Add")]
        public IActionResult ProductAdd()
        {
            return View("~/Views/Admin/Product/Detail.cshtml");
        }
        [HttpGet("User")]
        public IActionResult User()
        {
            return View("~/Views/Admin/User/List.cshtml");
        }
        [HttpGet("User/Detail")]
        public IActionResult UserDetail(Guid id)
        {
            return View("~/Views/Admin/User/Detail.cshtml",id);
        }
        [HttpGet("User/Add")]
        public IActionResult UserAdd()
        {
            return View("~/Views/Admin/User/Detail.cshtml");
        }
    }
}
