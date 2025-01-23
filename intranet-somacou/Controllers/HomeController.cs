using intranet_somacou.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace intranet_somacou.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else if (Session["UserId"] != null)
            {
                return View();
            }
            return View();
        }

        public ActionResult Rh()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else if (Session["UserId"] != null)
            {
                return View();
            }
            return View();
        }

        public ActionResult Dsi()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else if (Session["UserId"] != null)
            {
                return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Dsi(IncidentDto incidentDto)
        {
            if (ModelState.IsValid)
            {
                using (var context = new AppDbContext())
                {
                    if (incidentDto.User != null && incidentDto.Type != null && incidentDto.Etat != null && incidentDto.Details != null && incidentDto.CreatedDate != null && incidentDto.Action != null)
                    {
                        incidentDto.Etat = "Nouveau";
                        incidentDto.Action = "Attente";
                        incidentDto.UpdateDate = DateTime.Now;
                        context.Incidents.Add(incidentDto);
                        context.SaveChanges();
                    }
                }

                TempData["SuccessMessage"] = "Incident envoyé avec succès";
                return View(incidentDto);
            }
            else if(!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors)
                                   .Select(e => e.ErrorMessage)
                                   .ToList();
                TempData["ErrorMessage"] = "Vous devez remplir les informations avant de soumettre";
                TempData["Anchor"] = "addinc"; // Ajout de l'ancre
                return View(incidentDto);
            }    
            return View(incidentDto);
        }
    }
}