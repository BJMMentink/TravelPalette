using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using TravelPalette.BL;
using TravelPalette.BL.Models;
using TravelPalette.UI.Extensions;
using TravelPalette.UI.Models;


namespace TravelPalette.UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Login To Your Travel Palette Account";
            return View(UserManager.Load());
        }

        public IActionResult Seed()
        {
            UserManager.Seed();
            return View();
        }

        private void SetUser(User user)
        {
            HttpContext.Session.SetObject("user", user);

            if (user != null)
            {
                HttpContext.Session.SetObject("UserId", user.Id);
                HttpContext.Session.SetObject("FullName", "Welcome, " + user.FullName);
            }
            else
            {
                HttpContext.Session.SetObject("UserId", string.Empty);
                HttpContext.Session.SetObject("FullName", string.Empty);
            }
        }
        public IActionResult Create()
        {
            ViewBag.Title = "Create Account";
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                int userResult = UserManager.Insert(user);

                UserList userList = new UserList();
                userList.Id = -1;
                userList.ListName = user.FirstName + "'s List";
                userList.UserId = user.Id;
                userList.ListId = userList.Id;

                int listResult = UserListManager.Insert(userList);
                SetUser(user);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, User user, bool rollback = false)
        {
            try
            {
                int result = UserManager.Update(user, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(user);
            }
        }

        public IActionResult Logout()
        {
            ViewBag.Title = "Logout";
            SetUser(null);
            return View();
        }


        public IActionResult Login(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            ViewBag.Title = "Login To Your Account!";
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)   //same idea as a create
        {
            try
            {
                bool result = UserManager.Login(user);
                SetUser(user);

                if (TempData["returnUrl"] != null)
                    return Redirect(TempData["returnUrl"]?.ToString());  // this is going directly to a view

                return RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Login";
                ViewBag.Error = ex.Message;
                return View(user);
            }
        }

        public IActionResult Delete(int id)
        {
            var item = UserManager.LoadById(id);
            ViewBag.Title = "Delete a User";
            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(int id, User user, bool rollback = false)
        {
            try
            {
                int result = UserManager.Delete(id, rollback);
                int listItemResult = ListItemManager.DeleteAll(id, rollback);
                int userListResutl = UserListManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(user);
            }
        }

        public IActionResult Details(int id)
        {
            ViewBag.Title = "Details for User";
            return View(UserManager.LoadById(id));
        }
    }
}
