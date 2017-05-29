using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Core.Flash.Web.Controllers
{
    public class HomeController : Controller
    {
        private IFlasher f;

        public HomeController(IFlasher f)
        {
            this.f = f;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            f.Flash("success", "Flash message system for ASP.NET MVC Core");

            return RedirectToAction("Contact");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
