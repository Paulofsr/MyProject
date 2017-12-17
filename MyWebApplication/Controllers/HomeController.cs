using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Nossa Página.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Fale conosco.";

            return View();
        }
    }
}