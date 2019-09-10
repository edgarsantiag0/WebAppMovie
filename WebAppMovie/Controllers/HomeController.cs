using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMovie.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Console.WriteLine("hola");

            return View();
        }

        public ActionResult Perfil()
        {
            //return Content("Hola, soy un content");
            //return View();
            //return HttpNotFound();
            //return Content("hola")
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });




            return RedirectToAction("Index");

        }

        [Route("PorFecha/{year}/{month}")]
        public ActionResult PorFecha(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Cliente()
        {
            ViewBag.Nombre = "Cordero";
            ViewBag.Edad = 27;
            return View();
        }
    }
}