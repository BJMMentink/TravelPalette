using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelPalette.BL;
using TravelPalette.BL.Models;
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
        public ActionResult AddToTrip(string id, User user, bool rollback = false)
        {
            // Split the id string at the '/' sign and grab the integer on the right side
            string[] idParts = id.Split('/');
            if (idParts.Length != 2 || !int.TryParse(idParts[1], out int tripId))
            {
                // Handle invalid id format
                ViewBag.Error = "Invalid id format";
                return View(user);
            }

            UserList userList = new UserList
            {
                Id = tripId,
                // send through the id and user information
            };
            try
            {
                int result = UserListManager.Insert(userList, rollback);
                return RedirectToAction("Home"); // Redirect back to the map
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(user);
            }
        }


    }
}
