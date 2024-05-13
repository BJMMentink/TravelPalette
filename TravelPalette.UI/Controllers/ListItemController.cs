using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelPalette.BL;
using TravelPalette.BL.Models;
using TravelPalette.UI.ViewModels;

namespace TravelPalette.UI.Controllers
{
    public class ListItemController : Controller
    {
        // GET: LocationController
        public IActionResult Index()
        {
            return View(ListItemManager.Load());
        }

        public IActionResult ClearList(int intId)
        {
            try
            {
                var item = ListItemManager.LoadById(intId);

                int result = ListItemManager.Delete(item.Id, item.LocationId, false);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        // GET: UserListController/Delete/5
        public IActionResult Delete(int id)
        {

            string userId = HttpContext.Session.GetString("UserId");
            if (!String.IsNullOrEmpty(userId))
            {
                int Id = int.Parse(userId);
                var item = ListItemManager.LoadById(Id);
                return View(item);
            }
            else 
            { 
                var item = ListItemManager.LoadById(id);
                return View(item);
            }

        }

        // POST: UserListController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, ListItem listItem, bool rollback = false)
        {
            try
            {
                var item = ListItemManager.LoadById(id);

                int result = ListItemManager.Delete(item.Id, item.LocationId, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(listItem);
            }
        }
    }
}
