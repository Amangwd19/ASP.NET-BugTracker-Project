﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Controllers
{
    public class TicketsController : Controller
    {
        // GET: Tickets
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

    }
}