using intranet_somacou.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace intranet_somacou.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;
        public UsersController()
        {
            _context = new AppDbContext();
        }
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index","Home");
            }

            if (Session["UserId"] != null)
            {
                int userId = (int)Session["UserId"];
                var user = _context.Users.Find(userId);
                if (user != null)
                {
                    if(user.Role == "Admin")
                    {
                        var users = _context.Users.OrderBy(u => u.Id)
                                                  .Skip((page - 1) * pageSize)
                                                  .Take(pageSize)
                                                  .ToList();

                        var totalUsers = _context.Users.Count();
                        ViewBag.CurrentPage = page;
                        ViewBag.TotalPages = (int)Math.Ceiling((double)totalUsers / pageSize);
                        return View(users);
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "ID utilisateur manquant");
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == id.Value);
            if (user == null)
            {
                TempData["ErrorUser"] = "L'utilisateur demandé n'existe pas.";
                return RedirectToAction("Index");
            }

            ViewBag.Roles = new List<string> { "Admin", "Chef", "User" };
            return View(user);  
        }


        [HttpPost]
        public ActionResult UpdateRole(int? id, string newRole)
        {
            if (!id.HasValue || string.IsNullOrWhiteSpace(newRole))
            {
                TempData["ErrorMessage"] = "ID utilisateur ou rôle manquant.";
                return RedirectToAction("Index");
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == id.Value);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Utilisateur introuvable.";
                return RedirectToAction("Index");
            }

            user.Role = newRole;
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Le rôle a été mis à jour avec succès.";
            return RedirectToAction("Details", new {id = user.Id});
        }

        [HttpPost]
        public ActionResult DeleteAccount(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "ID utilisateur manquant");
            }
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

            TempData["SuccessMessage"] = "Utilisateur supprimé avec succès";
            return RedirectToAction("Index","Users");
        }
    }
}