using ExpeditionHackathon.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ExpeditionHackathon.Controllers
{
    //[RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [Route("Index/{userName}/{latitude}/{longitude}/")]
        public ActionResult Index(string userName, string latitude, string longitude)
        {

            ItemViewModel<string, string, string> model = new ItemViewModel<string, string, string>();
            model.Item1 = userName;
            model.Item2 = latitude;
            model.Item3 = longitude;
            return View(model);


        }

        public ActionResult Landing()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }        

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Maps()
        {
            return View();
        }

    }
}