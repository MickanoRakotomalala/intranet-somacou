using intranet_somacou.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace intranet_somacou.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateUser createUser)
        {
            if (ModelState.IsValid)
            {
                using (var context = new AppDbContext())
                {
                    createUser.CreatedAt = DateTime.Now;
                    context.Users.Add(createUser);
                    context.SaveChanges();
                }

                TempData["SuccessMessage"] = "Inscription avec succés";
                return RedirectToAction("Index", "Users");
            }
            TempData["ErrorMessage"] = "Model invalid";
            return View(createUser); //si le modèle est invalide
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}