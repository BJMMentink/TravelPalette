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
        
        // GET: UserListController/Delete/5
        public IActionResult Delete(int id)
        {
            var item = LocationManager.LoadById(id);
            return View(item);
        }

        // POST: UserListController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Location location, bool rollback = false)
        {
            try
            {
                int result = LocationManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(location);
            }
        }
    }
}
