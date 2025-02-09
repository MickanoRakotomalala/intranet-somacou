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
                    if (incidentDto.UserName != null && incidentDto.Type != null && incidentDto.Etat != null && incidentDto.Details != null && incidentDto.CreatedDate != null && incidentDto.Action != null)
                    {
                        incidentDto.UserId = (int)Session["UserId"];
                        incidentDto.Etat = "Nouveau";
                        incidentDto.Action = "Attente";
                        incidentDto.Responsible = "Aucun";
                        context.Incidents.Add(incidentDto);
                        context.SaveChanges();
                    }
                }

                TempData["SuccessMessage"] = "Incident enregistré avec succès";
                return Json(new { success = true });
            }
            else if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                TempData["ErrorMessage"] = "Vous devez remplir les informations avant de soumettre";
                return Json(new { success = false, errors = errors });
            }
            return Json(new { success = false });
        }

        private AppDbContext db = new AppDbContext();

        [HttpGet]
        public ActionResult ListDsi()
        {
;            // Récupérez tous les incidents associés à l'utilisateur
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Aucun incident trouvé";
                return Json(new { success = false, message = "Aucun incident trouvé" }, JsonRequestBehavior.AllowGet);
            }

            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int userId = (int)Session["UserId"];
            var user = db.Users.Find(userId);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            

            if ((Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "Chef") 
                && (Session["Poste"].ToString() == "Developer" || Session["Poste"].ToString() == "HelpDesk"))
            {
                var userIncidents = db.Incidents
                                        .ToList();
                var incidentDtos = userIncidents.Select(incident => new IncidentDto
                {
                    Id = incident.Id,
                    UserName = incident.UserName,
                    Type = incident.Type,
                    Details = incident.Details,
                    Etat = incident.Etat,
                    CreatedDate = incident.CreatedDate,
                    Action = incident.Action,
                    UpdateDate = incident.UpdateDate,
                    Responsible = incident.Responsible,
                    UserId = incident.UserId
                }).ToList();
                return Json(new { success = true, data = incidentDtos }, JsonRequestBehavior.AllowGet);
            } 
            else
            {
                var userIncidents = db.Incidents
                        .Where(i => i.UserId == userId)
                        .ToList();

                var incidentDtos = userIncidents.Select(incident => new IncidentDto
                {
                    Id = incident.Id,
                    UserName = incident.UserName,
                    Type = incident.Type,
                    Details = incident.Details,
                    Etat = incident.Etat,
                    CreatedDate = incident.CreatedDate,
                    Action = incident.Action,
                    UpdateDate = incident.UpdateDate,
                    Responsible = incident.Responsible,
                    UserId = incident.UserId
                }).ToList();
                //return View(incidentDtos);
                return Json(new { success = true, data = incidentDtos }, JsonRequestBehavior.AllowGet);
            }      
            
        }

        // Action pour mettre à jour un incident
        [HttpPost]
        public ActionResult UpdateIncident(IncidentDto incidentDto)
        {
            if (ModelState.IsValid)
            {
                using (var context = new AppDbContext())
                {
                    var incident = context.Incidents.Find(incidentDto.Id);
                    if (incident != null)
                    {
                        incident.Etat = incidentDto.Etat;
                        incident.Action = incidentDto.Action;
                        incident.Responsible = Session["FullName"].ToString();
                        incident.UpdateDate = DateTime.Now; // Mettre à jour la date de modification
                        context.SaveChanges();
                    }
                }

                return Json(new { success = true });
            }
            else
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return Json(new { success = false, message = "Erreur de validation", errors = errors });
            }
        }

    }
}