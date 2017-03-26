using ExpeditionHackathon.Models;
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
    public class UsersService
    {
        public static List<User> GetUsersByWeatherStation(int WeatherStation)
        {
            List<User> list = null;
            DataProvider.ExecuteCmd(GetConnection, "dbo.Users_GetByWeatherStationId"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@weatherStationId", WeatherStation);
                }
                , map: delegate (IDataReader reader, short set)
                 {
                     User u = new User();
                     int startingIndex = 0;
                     u.Id = reader.GetSafeInt32(startingIndex++);
                     u.Name = reader.GetSafeString(startingIndex++);
                     u.LocationName = reader.GetSafeString(startingIndex++);
                     u.Description = reader.GetSafeString(startingIndex++);
                     u.Latitude = reader.GetSafeDecimal(startingIndex++);
                     u.Longitude = reader.GetSafeDecimal(startingIndex++);
                     u.WeatherStationId = reader.GetSafeInt32(startingIndex++);
                     u.CropId = reader.GetSafeInt32(startingIndex++);

                     if (list == null)
                     {
                         list = new List<User>();
                     }
                     list.Add(u);
                 });
                return list;
        }

        public static List<User> GetUsersByCropAndZone(int Crop, int Zone)
        {
            List<User> list = null;
            //DataProvider.ExecuteCmd(GetConnection, "dbo.Users_GetUsersByCropIdAndZoneId"
            DataProvider.ExecuteCmd(GetConnection, "dbo.Users_SelectByCropIdZoneId"
    , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@cropId", Crop);
                    paramCollection.AddWithValue("@zoneId", Zone);
                }, map: delegate (IDataReader reader, short set)
                {
                    User u = new User();
                    int startingIndex = 0;
                    u.Id = reader.GetSafeInt32(startingIndex++);
                    u.Name = reader.GetSafeString(startingIndex++);
                    u.LocationName = reader.GetSafeString(startingIndex++);
                    u.Description = reader.GetSafeString(startingIndex++);
                    u.Latitude = reader.GetSafeDecimal(startingIndex++);
                    u.Longitude = reader.GetSafeDecimal(startingIndex++);
                    u.WeatherStationId = reader.GetSafeInt32(startingIndex++);
                    u.CropId = reader.GetSafeInt32(startingIndex++);

                    if (list == null)
                    {
                        list = new List<User>();
                    }
                    list.Add(u);
                });
            return list;
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