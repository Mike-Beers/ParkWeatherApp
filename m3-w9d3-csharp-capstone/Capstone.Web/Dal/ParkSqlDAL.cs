using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.Dal
{
    public class ParkSqlDal : IParkDal
    {
        private const string SqlGetAllParks = "SELECT * FROM park;";
        private const string SqlGetParkByCode = "SELECT * FROM park WHERE parkCode = @parkCode;";

        private readonly string connectionString;

        public ParkSqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Park> GetAllParks()
        {
            List<Park> parks = new List<Park>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SqlGetAllParks, conn);
                    SqlDataReader results = cmd.ExecuteReader();

                    while (results.Read())
                    {
                        Park p = new Park();
                        p.ParkCode = Convert.ToString(results["parkCode"]);
                        p.ParkName = Convert.ToString(results["parkName"]);
                        p.State = Convert.ToString(results["state"]);
                        p.Acreage = Convert.ToInt32(results["acreage"]);
                        p.ElevationInFeet = Convert.ToInt32(results["elevationInFeet"]);
                        p.MilesOfTrail = Convert.ToInt32(results["milesOfTrails"]);
                        p.NumberOfCampsites = Convert.ToInt32(results["numberOfCampsites"]);
                        p.Climate = Convert.ToString(results["climate"]);
                        p.YearFounded = Convert.ToInt32(results["yearFounded"]);
                        p.AnnualVisitorCount = Convert.ToInt32(results["annualVisitorCount"]);
                        p.InspirationalQuote = Convert.ToString(results["inspirationalQuote"]);
                        p.InspirationalQuoteSource = Convert.ToString(results["inspirationQuoteSource"]);
                        p.ParkDescription = Convert.ToString(results["parkDescription"]);
                        p.EntryFee = Convert.ToInt32(results["entryFee"]);
                        p.NumberOfAnimalSpecies = Convert.ToInt32(results["numberOfAnimalSpecies"]);
                        parks.Add(p);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return parks;
        }
        public Park GetParkByCode(string code)
        {
            Park p = new Park();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SqlGetParkByCode, conn);
                    cmd.Parameters.AddWithValue("@parkCode", code);
                    SqlDataReader results = cmd.ExecuteReader();

                    while (results.Read())
                    {
                        p.ParkCode = Convert.ToString(results["parkCode"]);
                        p.ParkName = Convert.ToString(results["parkName"]);
                        p.State = Convert.ToString(results["state"]);
                        p.Acreage = Convert.ToInt32(results["acreage"]);
                        p.ElevationInFeet = Convert.ToInt32(results["elevationInFeet"]);
                        p.MilesOfTrail = Convert.ToInt32(results["milesOfTrails"]);
                        p.NumberOfCampsites = Convert.ToInt32(results["numberOfCampsites"]);
                        p.Climate = Convert.ToString(results["climate"]);
                        p.YearFounded = Convert.ToInt32(results["yearFounded"]);
                        p.AnnualVisitorCount = Convert.ToInt32(results["annualVisitorCount"]);
                        p.InspirationalQuote = Convert.ToString(results["inspirationalQuote"]);
                        p.InspirationalQuoteSource = Convert.ToString(results["inspirationQuoteSource"]);
                        p.ParkDescription = Convert.ToString(results["parkDescription"]);
                        p.EntryFee = Convert.ToInt32(results["entryFee"]);
                        p.NumberOfAnimalSpecies = Convert.ToInt32(results["numberOfAnimalSpecies"]);
                        
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return p;
        }
    }
}
