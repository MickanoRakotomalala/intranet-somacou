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
            return View();
        }

        public ActionResult Magasin()
        {
            return View();
        }

        public ActionResult Usine() 
        {
            return View();
        }
    }
}