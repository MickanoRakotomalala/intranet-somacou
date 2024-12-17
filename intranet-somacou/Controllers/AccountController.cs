using intranet_somacou.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace intranet_somacou.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                using (var context = new AppDbContext())
                {
                    registerDto.CreatedAt = DateTime.Now;
                    context.Users.Add(registerDto);
                    context.SaveChanges();
                }

                TempData["SuccessMessage"] = "Inscription avec succés";
                return RedirectToAction("Register", "Account");
            }
            TempData["ErrorMessage"] = "Model invalid";
            return View(registerDto); //si le modèle est invalide
        }

        private AppDbContext db = new AppDbContext();

        [HttpGet]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password);

                if(user != null)
                {
                    Session["UserId"] = user.Id;
                    Session["FullName"] = user.Name;
                    Session["Role"] = user.Role;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Mot de passe  ou Email invalide.";
                    ModelState.AddModelError("", "Mot de passe ou Email invalide.");
                }

            }
            else
            {
                    ViewBag.ErrorMessage = "Les formulaires ne doivent pas être vide.";
            }
                return View(loginDto);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();

            // 2. Supprimer le cookie ASP.NET_SessionId
            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                var sessionCookie = new HttpCookie("ASP.NET_SessionId")
                {
                    Expires = DateTime.Now.AddDays(-1), // Expire immédiatement
                    HttpOnly = true
                };
                Response.Cookies.Add(sessionCookie);
            }

            return RedirectToAction("Login", "Account");
        }
    }
}