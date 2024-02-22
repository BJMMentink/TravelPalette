using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelPalette.BL;
using TravelPalette.BL.Models;


namespace TravelPalette.UI.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        public IActionResult Index()
        {
            ViewBag.Title = "Login";
            return View(UserManager.Load());
        }

      //  public IActionResult Seed()
       // {
        //    UserManager.Seed();
        //    return View();
       // }

       // private void SetUser(User user)
       // {
          //  HttpContext.Session.SetObject("user", user);

          //  if (user != null)
          //  {
          //      HttpContext.Session.SetObject("FullName", "Welcome " + user.FullName);
          //  }
          //  else
           // {
           //     HttpContext.Session.SetObject("FullName", string.Empty);
          //  }
      //  }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Title = "Details";
            return View(UserManager.LoadById(id));
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
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

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
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
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(user);
            }
        }

        public IActionResult Login()
        {
            //TempData["returnUrl"] = returnUrl;
            ViewBag.Title = "Login To Your Account!";
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)   //same idea as a create
        {
            try
            {
               // bool result = UserManager.Login(user);
              //  SetUser(user);

                if (TempData["returnUrl"] != null)
                    return Redirect(TempData["returnUrl"]?.ToString());  // this is going directly to a view

                return RedirectToAction(nameof(Index), "Movie");
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Login";
                ViewBag.Error = ex.Message;
                return View(user);
            }
        }

        public IActionResult Logout()
        {
            ViewBag.Title = "You're Logged Out!";
           // SetUser(null);
            return View();
        }
    }
}
