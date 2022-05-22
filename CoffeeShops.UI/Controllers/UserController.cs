using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShops.UI.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

    }
}
