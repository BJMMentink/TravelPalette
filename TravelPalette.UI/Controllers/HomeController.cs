using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelPalette.UI.Models;

namespace TravelPalette.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View("MapAndList");
        }

        public IActionResult Eat()
        {
            return View("MapAndList");
        }

        public IActionResult Stay()
        {
            return View("MapAndList");
        }

        public IActionResult Fun()
        {
            return View("MapAndList");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
