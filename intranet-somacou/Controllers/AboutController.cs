using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace intranet_somacou.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Commercial()
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

        public ActionResult Magasin()
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

        public ActionResult Usine() 
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
    }
}