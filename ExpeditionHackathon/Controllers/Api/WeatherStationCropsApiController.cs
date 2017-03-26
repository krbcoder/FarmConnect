using ExpeditionHackathon.Domain;
using ExpeditionHackathon.Models.Responses;
using ExpeditionHackathon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExpeditionHackathon.Controllers.Api
{
    [RoutePrefix("api/weatherstationcrops")]
    public class WeatherStationCropsApiController : ApiController
    {
        [Route("yield")]
        [HttpGet]
        public HttpResponseMessage GetYeild([FromUri]int WeatherStation, [FromUri]int Crop)
        {
            ItemResponse<WeatherStationCrop> response = new ItemResponse<WeatherStationCrop>();
            response.Item = WeatherStationCropsService.GetYield(WeatherStation, Crop);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("yields")]
        [HttpGet]
        public HttpResponseMessage GetYields([FromUri]int zoneId, [FromUri]int CropId)
        {
            ItemsResponse<WeatherStationCrop> response = new ItemsResponse<WeatherStationCrop>();
            response.Items = WeatherStationCropsService.GetYields(zoneId, CropId);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
