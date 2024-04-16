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

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult AddToTrip(string id)
        {
            // Here you can write code to add the id to your database
            // For demonstration, let's just return a simple response
            return Content($"Added feature with ID {id} to trip!");
        }
    }
}
