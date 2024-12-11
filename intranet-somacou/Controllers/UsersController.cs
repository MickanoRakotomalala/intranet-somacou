using intranet_somacou.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace intranet_somacou.Controllers
{
    public class UsersController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            CreateUser createuser = new CreateUser();
            createuser.Id = 1;
            createuser.Name = "MICKANO RAKOTOMALALA";
            createuser.Email = "rakotomalala@gmail.com";
            createuser.Phone = "0341029531";
            createuser.Address = "Lot 63 AK";
            createuser.Password = "1234";
            createuser.Role = "Chef";
            createuser.CreatedAt = DateTime.Now;

            @ViewBag.Message = "Création compte avec succés";
            return View(createuser);
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}