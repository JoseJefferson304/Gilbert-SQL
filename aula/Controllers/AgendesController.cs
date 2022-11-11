using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aula.Controllers
{
    public class AgendesController : Controller
    {
        // GET: Agendes
        public ActionResult Index()
        {
            return View();
        }
    }
}