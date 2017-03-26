using ExpeditionHackathon.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExpeditionHackathon.Models;
using ExpeditionHackathon.Models.Responses;

namespace ExpeditionHackathon.Controllers.Api
{
    [RoutePrefix("api/climatezones")]
    public class ClimateZonesApiController : ApiController
    {
        [Route("{id:int}")]
        [HttpGet]
        public HttpResponseMessage selectInfoByZoneId(int id)
        {
            ItemsResponse<ClimateZone> response = new ItemsResponse<ClimateZone>();
            response.Items = ClimateZonesService.SelectInfoByZoneId(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
