using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    public class IsAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}