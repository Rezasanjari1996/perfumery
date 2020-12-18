using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Perfumery.Models;

namespace Perfumery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["massage1"] = "hello world";
            ViewBag.massage2 = "salammm";
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
   

        public IActionResult Register()
        {
           
            return Redirect("/people/create");
        }
    }
}
