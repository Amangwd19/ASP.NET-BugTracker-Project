using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManageRole()
        {
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Tickets()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }
    }
}