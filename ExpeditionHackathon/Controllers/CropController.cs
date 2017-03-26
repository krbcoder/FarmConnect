using ExpeditionHackathon.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpeditionHackathon.Controllers
{
    [RoutePrefix("crop")]
    public class CropController : Controller
    {
        // GET: Crop
        [Route("{cropId:int}/zone/{zoneId:int}/weatherstation/{stationId:int}")]
        public ActionResult Index(int cropId, int zoneId, int stationId)
        {
            ItemViewModel<int, int, int> model = new ItemViewModel<int, int, int>();
            model.Item1 = cropId;
            model.Item2 = zoneId;
            model.Item3 = stationId;
            return View(model);
        }
    }
}