﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class PortalController : Controller
    {
        // GET: Portal
        public ActionResult Acessar()
        {
            return View();
        }
    }
}