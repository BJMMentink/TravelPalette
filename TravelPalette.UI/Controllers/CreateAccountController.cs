﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelPalette.BL.Models;

namespace TravelPalette.UI.Controllers
{
    public class CreateAccountController : Controller
    {
        // GET: CreateAccount
        public IActionResult Index()
        {
            ViewBag.Title = "Welcome, Make An Account";
            return View();
        }

        public IActionResult CreateAccount()
        {
            ViewBag.Title = "Welcome, Make Your Account";
            return View();
        }

        // GET: CreateAccount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CreateAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreateAccount/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CreateAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CreateAccount/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CreateAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CreateAccount/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
