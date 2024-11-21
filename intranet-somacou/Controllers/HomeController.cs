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
            return View();
        }

        public ActionResult Rh()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Dsi()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}