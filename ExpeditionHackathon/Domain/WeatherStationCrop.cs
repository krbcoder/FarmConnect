using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpeditionHackathon.Domain
{
    public class WeatherStationCrop
    {
        public int Id { get; set; }

        public int CropId { get; set; }

        public int WeatherStationId { get; set; }

        public decimal Yield { get; set; }

        public string LocationName { get; set; }
    }
}