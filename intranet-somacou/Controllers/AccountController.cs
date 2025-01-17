using intranet_somacou.Migrations;
using intranet_somacou.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;
using PasswordDto = intranet_somacou.Models.PasswordDto;
using RegisterDto = intranet_somacou.Models.RegisterDto;

namespace intranet_somacou.Controllers
{
    public class AccountController : Controller
    {
        private AppDbContext db = new AppDbContext();

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
                    if(registerDto.Name != null && registerDto.Email != null && registerDto.Phone != null && registerDto.Poste != null && registerDto.Password != null)
                    {
                        registerDto.Role = "User";
                        registerDto.CreatedAt = DateTime.Now;
                        context.Users.Add(registerDto);
                        context.SaveChanges();
                    }
                }

                TempData["SuccessMessage"] = "Inscription avec succès";
                Session["UserId"] = registerDto.Id;
                Session["FullName"] = registerDto.Name;
                Session["Role"] = registerDto.Role;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach(var key in ModelState.Keys)
                {
                    var errors = ModelState[key].Errors;
                    if(errors.Count > 0)
                    {
                        ViewData[$"{key}Error"] = errors[0].ErrorMessage;
                    }
                }
                TempData["ErrorMessage"] = "Formulaire invalide";
                return View(registerDto); //si le modèle est invalide
            }
        }


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
            }
            else
            {
                    ViewBag.ErrorMessage = "Connexion invalide";
                    return View(loginDto);
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

        [HttpGet]
        public ActionResult Profile()
        {
            if (Session["UserId"] != null) 
            { 
                int userId = (int)Session["UserId"];
                var user = db.Users.Find(userId);

                if(user != null)
                {
                    ViewBag.Poste = new List<string> { "DRH", "RH", "Developer", "Commercial", "Comptable", "Gérant Magasin", "Transit" };
                    return View(user);
                }
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Profile(RegisterDto registerDto)
        {
            if (Session["UserId"] != null)
            {
                int userId = (int)Session["UserId"];
                var user = db.Users.Find(userId);

                if (user != null)
                {
                        user.Name = registerDto.Name;
                        user.Matricule = registerDto.Matricule;
                        user.Email = registerDto.Email;
                        user.Address = registerDto.Address;
                        user.Poste = registerDto.Poste;
                        user.Phone = registerDto.Phone;
                        db.SaveChanges();
                }
                TempData["SuccessMessage"] = "La modification s'est réalisé avec succès";
                return RedirectToAction("Profile", "Account");
            }
            TempData["ErrorMessage"] = "Erreur de modification";
            return RedirectToAction("Profile", "Account");
        }

        [HttpGet]
        public ActionResult Password()
        {
            if (Session["UserId"] != null)
            {
                int userId = (int)Session["UserId"];
                var user = db.Users.Find(userId);

                if (user != null)
                {
                    return View();
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Password(PasswordDto passwordDto)
        {

            if (Session["UserId"] != null)
            { 
                int userId = (int)Session["UserId"];
                var user = db.Users.Find(userId);

                if (user != null)
                {
                    if (user.Password == passwordDto.CurrentPassword && passwordDto.NewPassword == passwordDto.ConfirmPassword)
                    { 
                         user.Password = passwordDto.NewPassword;
                         db.SaveChanges();
                         TempData["SuccessMessage"] = "La modification du mot de passe s'est réalisé avec succès";
                         return RedirectToAction("Profile", "Account");
                    }
                    else if (!ModelState.IsValid) 
                    {
                        TempData["ErrorMessage"] = "Erreur de modification";
                        return View(passwordDto);    
                    }
                }
            }
            return RedirectToAction("Profile", "Account");
        }
    }
}