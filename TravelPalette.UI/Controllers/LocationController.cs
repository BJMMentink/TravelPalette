using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelPalette.BL;
using TravelPalette.BL.Models;
using TravelPalette.UI.ViewModels;

namespace TravelPalette.UI.Controllers
{
    public class LocationController : Controller
    {
        // GET: LocationController
        public IActionResult Index()
        {
            return View(LocationManager.Load());
        }
    }
}
