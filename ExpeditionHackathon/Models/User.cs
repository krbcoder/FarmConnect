using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpeditionHackathon.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LocationName { get; set; }

        public string Description { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public int WeatherStationId { get; set; }

        public int CropId { get; set; }
    }
}