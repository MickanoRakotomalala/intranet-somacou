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
using System.Web.WebPages.Html;
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

                Session["UserId"] = registerDto.Id;
                Session["FullName"] = registerDto.Name;
                Session["Role"] = registerDto.Role;
                Session["Poste"] = registerDto.Poste;
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
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Connexion invalide";
                return View(loginDto);
            }

            // Recherche de l'utilisateur avec l'email spécifié
            var user = db.Users.FirstOrDefault(u => u.Email == loginDto.Email);

            if (user == null)
            {
                ViewBag.ErrorMessage = "Adresse email introuvable";
                return View(loginDto);
            }

            // Vérification du mot de passe
            if (user.Password != loginDto.Password)
            {
                ViewBag.ErrorMessage = "Mot de passe incorrect";
                return View(loginDto);
            }

            // Si l'email et le mot de passe correspondent
            Session["UserId"] = user.Id;
            Session["FullName"] = user.Name;
            Session["Role"] = user.Role;
            Session["Poste"] = user.Poste;
            return RedirectToAction("Index", "Home");
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

                if (user != null)
                {
                    var registerDto = new RegisterDto
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Matricule = user.Matricule,
                        Email = user.Email,
                        Address = user.Address,
                        Poste = user.Poste,
                        Phone = user.Phone,
                        Role = user.Role,
                        CreatedAt = user.CreatedAt,
                        Password = user.Password
                    };

                    ViewBag.Poste = new List<string> { "DRH", "RH", "Developer", "HelpDesk","Commercial", "Comptable", "Gérant Magasin", "Transit" };
                    return View(registerDto);
                }
            }
            return RedirectToAction("Profile", "Account");
        }

        [HttpPost]
        public ActionResult Profile(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors)
                                                   .Select(e => e.ErrorMessage)
                                                   .ToList();
                ViewBag.HasErrors = true;
                ViewBag.Poste = new List<string> { "DRH", "RH", "Developer","HelpDesk", "Commercial", "Comptable", "Gérant Magasin", "Transit" };
                TempData["ErrorMessage"] = "Veuillez corriger les erreurs avant de soumettre.";
                return View(registerDto); // Renvoie à la vue pour afficher les erreurs
            }

            if (Session["UserId"] != null)
            {
                int userId = (int)Session["UserId"];
                var user = db.Users.Find(userId);

                if (user != null && ModelState.IsValid)
                {
                    user.Name = registerDto.Name;
                    user.Matricule = registerDto.Matricule;
                    user.Email = registerDto.Email;
                    user.Address = registerDto.Address;
                    user.Poste = registerDto.Poste;
                    user.Phone = registerDto.Phone;
                    db.SaveChanges();

                    TempData["SuccessMessage"] = "La modification a été enregistrée avec succès.";
                    return RedirectToAction("Profile");
                }
 
            }

            TempData["ErrorMessage"] = "Erreur lors de la mise à jour du profil.";
            return RedirectToAction("Profile");
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
                    return RedirectToAction("Login", "Account");
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
                    if (passwordDto.CurrentPassword == null || passwordDto.NewPassword == null || passwordDto.ConfirmPassword == null)
                    {
                        TempData["ErrorMessage"] = "Le champ ne doit pas être vide.";
                        return View(passwordDto);
                    }
                    else if(user.Password != passwordDto.CurrentPassword)
                    {
                        TempData["ErrorMessage"] = "Erreur de modification";
                        ViewBag.ErrorMessage = "L'Ancien mot de passe est incorrect.";
                        return View(passwordDto);
                    }
                    else if(passwordDto.NewPassword != passwordDto.ConfirmPassword)
                    {
                        TempData["ErrorMessage"] = "Erreur de modification";
                        return View(passwordDto);
                    }
                    else
                    {
                         user.Password = passwordDto.NewPassword;
                         db.SaveChanges();
                         TempData["SuccessMessage"] = "La modification du mot de passe s'est réalisée avec succès.";
                         return RedirectToAction("Profile", "Account");
                    }
                }
            }

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Erreur de modification";
                return View(passwordDto);
            }
                TempData["ErrorMessage"] = "Erreur de modification";
                return View(passwordDto);
        }
    }
}