using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organizate.Controllers
{
    public class HomeController : Controller
    {
       

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(String cedula)
        {
            return RedirectToAction("ReporteEstudiante", "Reportes", new {cedula = cedula });
        }



        public ActionResult IndexAdmin()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "Account",new { returnUrl = "~/Home/IndexAdmin"});
        }

       /* public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }*/

    }
}