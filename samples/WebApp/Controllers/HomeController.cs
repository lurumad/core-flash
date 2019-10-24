using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Core.Flash;

using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFlasher _flasher;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IFlasher flasher, ILogger<HomeController> logger)
        {
            _flasher = flasher;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            _flasher.Primary("A minimalistic flash system message for ASP.NET Core MVC", dismissable: true);
            _flasher.Secondary("A minimalistic flash system message for ASP.NET Core MVC", dismissable: true);
            _flasher.Success("A minimalistic flash system message for ASP.NET Core MVC", dismissable: true);
            _flasher.Danger("A minimalistic flash system message for ASP.NET Core MVC", dismissable: true);
            _flasher.Flash(Types.Warning, "A minimalistic flash system message for ASP.NET Core MVC", dismissable: true);
            _flasher.Flash(Types.Info, "A minimalistic flash system message for ASP.NET Core MVC", dismissable: true);
            _flasher.Flash(Types.Light, "A minimalistic flash system message for ASP.NET Core MVC", dismissable: true);
            _flasher.Flash(Types.Dark, "A minimalistic flash system message for ASP.NET Core MVC", dismissable: true);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
