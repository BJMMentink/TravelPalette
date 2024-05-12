using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelPalette.BL;
using TravelPalette.BL.Models;
using TravelPalette.UI.ViewModels;

namespace TravelPalette.UI.Controllers
{
    public class UserListController : Controller
    {
        // GET: UserListController
        public IActionResult Index()
        {
            int userId; 
            try
            {

                userId = int.Parse(HttpContext.Session.GetString("UserId"));

                if (userId == null)
                {
                    return View();
                }
                else
                {
                    return View(UserListManager.LoadByUserId(userId));
                }
            }
            catch (Exception)
            {

                return View();
            }
        }

        // GET: UserListController/Details/5
        public IActionResult Details(int id)
        {
            return View(UserListManager.LoadById(id));
        }

        // GET: UserListController/Create
        public IActionResult Create(UserList model)
        {
            int userId;

            userId = int.Parse(HttpContext.Session.GetString("UserId"));

            model.UserId = userId;


            ViewBag.Title = "Create a List";
            return View(model);
        }

        // POST: UserListController/Create
        [HttpPost]
        public IActionResult Create(UserList userList, bool rollback = false)
        {
            try
            {
                int result = UserListManager.Insert(userList, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserListController/Edit/5
        public IActionResult Edit(int id)
        {
            ViewBag.Title = "Edit " + UserListManager.LoadById(id).ListName;
            return View();
        }

        // POST: UserListController/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, UserList list, bool rollback = false)
        {
            try
            {
                int result = UserListManager.Update(list, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(list);
            }
        }

        // GET: UserListController/Delete/5
        public IActionResult Delete(int id)
        {
            var item = UserListManager.LoadById(id);
            ViewBag.Title = "Delete " + item.ListName + "?";
            return View(item);
        }

        // POST: UserListController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, UserList list, bool rollback = false)
        {
            try
            {
                int result = UserListManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(list);
            }
        }

        public IActionResult AddToList(double id, string businessName, string amenity, double latitude, double longitude)
        {
            int userId;
            userId = int.Parse(HttpContext.Session.GetString("UserId"));

            try
            {
                ListItem listItem = new ListItem() { Id = userId, LocationId = (int)id };
                var listItemResult = ListItemManager.Insert(listItem);
                
                Location location = new Location()
                { 
                    Id = -1,
                    AddressId = (int)id,
                    Description = amenity,
                    BusinessName = businessName,
                    Coordinates = latitude + ", " + longitude,
                    PhoneNumber = "N/A"
                };
                
                var locationResult = LocationManager.Insert(location);
            }
            catch (Exception)
            {

                throw;
            }
            


            return Json(new { success = true, message = "Data received successfully!" });
        }
    }
}
