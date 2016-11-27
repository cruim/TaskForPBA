using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        IUserRepository repository;

        public AdminController(IUserRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Users);
        }

        public ViewResult Edit(int bookId)
        {
            User user = repository.Users.FirstOrDefault(b => b.ID == bookId);

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                repository.SaveBook(user);
                TempData["message"] = string.Format("Изменение информации о пользователе \"{0}\" сохранены", user.UserName);
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }

        [HttpPost]
        public ActionResult Delete(int userId)
        {
            User deletedUser = repository.DeleteUser(userId);
            if (deletedUser != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedUser.UserName);
            }
            return RedirectToAction("Index");
        }

        public ViewResult Create()
        {
            return View("Edit", new User());
        }
    }
}