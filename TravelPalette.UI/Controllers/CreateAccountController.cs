using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using TravelPalette.BL;
using TravelPalette.BL.Models;
using TravelPalette.UI.Models;

namespace TravelPalette.UI.Controllers
{
    public class CreateAccountController : Controller
    {
      
        public IActionResult Index()
        {
            ViewBag.Title = "Welcome, Make An Account";
            return View(UserManager.Load());
        }

        public IActionResult CreateAccount()
        {
            ViewBag.Title = "Welcome, Make Your Account";
            return View();
        }

        
        public ActionResult Details(int id)
        {
            var item = UserManager.LoadById(id);
            ViewBag.Title = "Details for your Account";
            return View(item);
        }

    
        public ActionResult Create()
        {
            ViewBag.Title = "Create a new Account";
            if (Authenticate.IsAuthenticated(HttpContext))
                return View();
            else
                return RedirectToAction("Index", "Home", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                int result = UserManager.Insert(user);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit Account";
            if (Authenticate.IsAuthenticated(HttpContext))
                return View();
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        }

        [HttpPost]
        public ActionResult Edit(int id, User user, bool rollback = false)
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

        public ActionResult Delete(int id)
        {
            var item = UserManager.LoadById(id);
            ViewBag.Title = "Delete Account";
            return View(item);
        }

        [HttpPost]
        public ActionResult Delete(int id, User user, bool rollback = false)
        {
            try
            {
                int result = UserManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(user);
            }
        }
    }
}
