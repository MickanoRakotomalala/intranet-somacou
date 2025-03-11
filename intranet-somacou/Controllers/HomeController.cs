using intranet_somacou.Migrations;
using intranet_somacou.Models;
using Microsoft.Ajax.Utilities;
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
                    if (incidentDto.UserName != null && incidentDto.Type != null && incidentDto.Etat != null && incidentDto.Details != null && incidentDto.CreatedDate != null)
                    {
                        incidentDto.UserId = (int)Session["UserId"];
                        incidentDto.Phone = Session["Phone"].ToString();
                        incidentDto.CreatedDate = DateTime.Now;
                        incidentDto.Responsible = "";
                        incidentDto.UpdateDate = DateTime.Now;
                        context.Incidents.Add(incidentDto);
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
                return Json(new { success = false, errors = errors });
            }
        }

        private AppDbContext db = new AppDbContext();

        [HttpGet]
        public ActionResult ListDsi(int page = 1, int pageSize = 8)
        {
            if (!ModelState.IsValid)
            {
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

            IQueryable<IncidentDto> query;

            if ((Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "Chef") &&
                (Session["Poste"].ToString() == "Developer" || Session["Poste"].ToString() == "HelpDesk"))
            {
                query = db.Incidents.OrderByDescending(x => x.CreatedDate);
            }
            else
            {
                query = db.Incidents.Where(i => i.UserId == userId).OrderByDescending(x => x.CreatedDate);
            }

            int totalIncidents = query.Count(); // Nombre total avant pagination
            var incidents = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var incidentDtos = incidents.Select(incident => new IncidentDto
            {
                Id = incident.Id,
                UserName = incident.UserName,
                Phone = incident.Phone,
                Type = incident.Type,
                Details = incident.Details,
                Etat = incident.Etat,
                CreatedDate = incident.CreatedDate,
                UpdateDate = incident.UpdateDate,
                Responsible = incident.Responsible,
                Observation = incident.Observation,
                UserId = incident.UserId
            }).ToList();

            return Json(new
            {
                success = true,
                data = incidentDtos,
                pagination = new
                {
                    currentPage = page,
                    totalPages = (int)Math.Ceiling((double)totalIncidents / pageSize)
                }
            }, JsonRequestBehavior.AllowGet);
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
                        incident.Type = incidentDto.Type;
                        incident.Details = incidentDto.Details;
                        incident.Etat = incidentDto.Etat;
                        incident.Responsible = Session["FullName"].ToString();
                        incident.Observation = incidentDto.Observation;
                        incident.UpdateDate = DateTime.Now; // Mettre à jour la date de modification
                        context.SaveChanges();
                    }
                }

                return Json(new { success = true, data = incidentDto }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return Json(new { success = false, message = "Erreur de validation UpdateIncident", errors = errors });
            }
        }

        public ActionResult DeleteIncident(IncidentDto incidentDto)
        {
            if (ModelState.IsValid)
            {
                var incident = db.Incidents.Find(incidentDto.Id);
                if (incident != null)
                {
                    db.Incidents.Remove(incident);
                    db.SaveChanges();
                }
                return Json(new { success = true, data = incidentDto }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var erros = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return Json(new {success = false, message = "Erreur de validation Delete", errors = erros});
            }
        }

    }
}