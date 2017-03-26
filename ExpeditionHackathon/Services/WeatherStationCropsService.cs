using ExpeditionHackathon.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WikiDataProvider.Data.Extensions;
using WikiDataProvider.Data.Interfaces;

namespace ExpeditionHackathon.Services
{
    public class WeatherStationCropsService
    {
        public static WeatherStationCrop GetYield(int WeatherStation, int Crop)
        {
            WeatherStationCrop yield = null;
            DataProvider.ExecuteCmd(GetConnection, "dbo.WeatherStationCrops_GetYield"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@weatherStationId", WeatherStation);
                    paramCollection.AddWithValue("@cropId", Crop);
                }, map: delegate (IDataReader reader, short set)
                {
                    if(yield == null)
                    {
                        yield = new WeatherStationCrop();
                    }

                    int startingIndex = 0;
                    yield.Yield = reader.GetSafeDecimal(startingIndex++);
                    yield.WeatherStationId = reader.GetSafeInt32(startingIndex++);
                    yield.LocationName = reader.GetSafeString(startingIndex++);

                });
            return yield;
        }

        public static List<WeatherStationCrop> GetYields(int zoneId, int CropId)
        {
            List<WeatherStationCrop> yields = null;
            
            DataProvider.ExecuteCmd(GetConnection, "dbo.WeatherStationCrops_GetYieldByZoneandCropId"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@zoneId", zoneId);
                    paramCollection.AddWithValue("@cropId", CropId);
                }, map: delegate (IDataReader reader, short set)
                {
                    if(yields == null)
                    {
                        yields = new List<WeatherStationCrop>();
                    }
                    int startingIndex = 0;
                    WeatherStationCrop y = new WeatherStationCrop();
                    y.Yield = reader.GetSafeDecimal(startingIndex++);
                    y.WeatherStationId = reader.GetSafeInt32(startingIndex++);
                    y.CropId = reader.GetSafeInt32(startingIndex++);
                    y.LocationName = reader.GetSafeString(startingIndex++);
                    

                    yields.Add(y);
                });

            return yields;
        }

        protected static IDao DataProvider
        {
            get { return WikiDataProvider.Data.DataProvider.Instance; }
        }

        protected static SqlConnection GetConnection()
        {
            return new System.Data.SqlClient.SqlConnection(
                System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
    }
}