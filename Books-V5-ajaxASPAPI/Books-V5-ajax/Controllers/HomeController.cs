using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books_V5_ajax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return File("~/index.html", "text/html");
            //ViewBag.Title = "Home Page";

            //return View();
        }
    }
}
