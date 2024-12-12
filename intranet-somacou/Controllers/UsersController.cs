using intranet_somacou.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }
    }
}