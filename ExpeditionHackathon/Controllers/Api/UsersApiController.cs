using ExpeditionHackathon.Models;
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
    [RoutePrefix("api/users")]
    public class UsersApiController : ApiController
    {
        [Route("neighbors")]
        [HttpGet]
        public HttpResponseMessage GetUsersByWeatherStation([FromUri]int WeatherStation)
        {
            ItemsResponse<User> response = new ItemsResponse<User>();
            response.Items = UsersService.GetUsersByWeatherStation(WeatherStation);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("similarUsers")]
        [HttpGet]
        public HttpResponseMessage GetUsersByCropAndZone([FromUri]int Crop, [FromUri]int Zone)
        {
            ItemsResponse<User> response = new ItemsResponse<User>();
            response.Items = UsersService.GetUsersByCropAndZone(Crop, Zone);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
