﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelPalette.BL;
using TravelPalette.BL.Models;

namespace TravelPalette.UI.Controllers
{
    public class UserListController : Controller
    {
        // GET: UserListController
        public IActionResult Index(int id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                 return View(UserListManager.LoadByUserId(id));
            }
        }

        // GET: UserListController/Details/5
        public IActionResult Details(int id)
        {
            return View(UserListManager.LoadById(id));
        }

        // GET: UserListController/Create
        public IActionResult Create()
        {
            ViewBag.Title = "Create a List";
            return View();
        }

        // POST: UserListController/Create
        [HttpPost]
        public IActionResult Create(UserList userList)
        {
            try
            {
                int result = UserListManager.Insert(userList);
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
    }
}
