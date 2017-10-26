using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.Dal
{
    public class ParkWeatherSqlDal : IParkWeatherDal
    {

        private readonly string connectionString;
        private const string getWeatherByCodeSql = "SELECT * FROM weather WHERE parkCode = @parkCode";


        public ParkWeatherSqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Weather> GetWeatherByCode(string parkCode)
        {
            List<Weather> weatherList = new List<Weather>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(getWeatherByCodeSql, conn);
                    command.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader results = command.ExecuteReader();
                    while (results.Read())
                    {
                        weatherList.Add(CreateFromRow(results));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return weatherList;
        }

        private Weather CreateFromRow(SqlDataReader results)
        {
            Weather weather = new Weather();

            weather.ParkCode = Convert.ToString(results["parkCode"]);
            weather.FiveDayForcastValue = Convert.ToInt32(results["fiveDayForecastValue"]);
            weather.Low = Convert.ToInt32(results["low"]);
            weather.High = Convert.ToInt32(results["high"]);
            if (results["forecast"].ToString().Contains(' '))
            {
                weather.Forecast = "partlycloudy";
            }
            else
            {
                weather.Forecast = Convert.ToString(results["forecast"]);
            }
            weather.Recommendation = CreateRecommendation(weather.Low, weather.High, weather.Forecast);
            return weather;
        }

        private string CreateRecommendation(int low, int high, string forecast)
        {
            string recommendation = "";

            switch (forecast)
            {
                case "snow":
                    recommendation += "Pack your snowshoes! ";
                    break;
                case "rain":
                    recommendation += "Pack rain gear and wear waterprof shoes. ";
                    break;
                case "thunderstorms":
                    recommendation += "Seek shelter and avoid hiking on exposed ridges. ";
                    break;
                case "sun":
                    recommendation += "Pack sunblock! ";
                    break;
            }
            if (high > 75)
            {
                recommendation += "Bring an extra gallon of water. ";
            }
            if (low < 20)
            {
                recommendation += "Avoid long exposure to frigid temperatures. ";
            }
            if (high - low >= 20)
            {
                recommendation += "Due to the temperature changes, wear breathable layers";
            }

            return recommendation;
        }


        //public int TestMethod()
        //{
        //    return 0;
        //}
    }
}

