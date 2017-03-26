using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WikiDataProvider.Data.Extensions;
using WikiDataProvider.Data.Interfaces;
using ExpeditionHackathon.Models;

namespace ExpeditionHackathon.Services
{
    public class ClimateZonesService
    {
        public static List<ClimateZone> SelectInfoByZoneId(int zoneId)
        {
            List<ClimateZone> list = new List<ClimateZone>();

            DataProvider.ExecuteCmd(GetConnection, "dbo.ClimateZones_SelectByZoneId"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", zoneId);
                }, map: delegate (IDataReader reader, short set)
                {
                    ClimateZone z = new ClimateZone();
                    int startingIndex = 0;
                    z.Id = reader.GetSafeInt32(startingIndex++);
                    z.Name = reader.GetSafeString(startingIndex++);
                    z.Description = reader.GetSafeString(startingIndex++);
                    z.ImageUrl = reader.GetSafeString(startingIndex++);
                    z.Color = reader.GetSafeString(startingIndex++);
                    list.Add(z);
                });
            return list;
        }

        protected static SqlConnection GetConnection()
        {
            return new System.Data.SqlClient.SqlConnection(
                System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
 
        protected static IDao DataProvider
        {
            get { return WikiDataProvider.Data.DataProvider.Instance; }
        }
    }
}
