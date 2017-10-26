using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Capstone.Web.Models;

namespace Capstone.Web.Dal
{
    public class SurveySqlDal : ISurveyDal
    {
        private readonly string connectionString;
        private string InsertSurvey_SQL = "INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @emailAddress, @state, @activityLevel);";
        private string ReturnMostPopularPark_SQL = "SELECT TOP 1 parkCode, COUNT(parkCode) FROM survey_result GROUP BY parkCode ORDER BY COUNT(parkCode) DESC;";
        // private string SelectAllByEmail_SQL = "";

        public SurveySqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        // Inserts a completed survey into the survey_results table.
        public bool InsertSurvey(Survey submittedSurvey)
        {
            bool successfulInsert;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(InsertSurvey_SQL, conn);

                    cmd.Parameters.AddWithValue("@parkCode", submittedSurvey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", submittedSurvey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", submittedSurvey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", submittedSurvey.ActivityLevel);

                    successfulInsert = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException e)
            {
                throw e;
            }

            return successfulInsert;
        }

        // Returns the park code of the national park that has the most survey entries in the survey table.
        public string ReturnMostPopularPark()
        {
            string topParkCode = "";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(ReturnMostPopularPark_SQL, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        topParkCode = reader["parkCode"].ToString();
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            return topParkCode;
        }
    }
}