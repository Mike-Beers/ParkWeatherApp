using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Dal;
using System.Data.SqlClient;
using System.Transactions;
using System.Configuration;
using Capstone.Web.Models;
using System.Collections.Generic;

namespace Capstone.Web.Tests.DALTests
{
    [TestClass]
    public class ParkWeatherSqlDalTests
    {
        private string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=ParkWeatherDb;Integrated Security=True";
        //private ParkWeatherSqlDal weatherDalTestObj = new ParkWeatherSqlDal(connectionString);
        Weather weatherAssertObj = new Weather
        {
            ParkCode = "CVNP",
            FiveDayForcastValue = 3,
            Low = 32,
            High = 40,
            Forecast = "cloudy"
        };
        private TransactionScope tran;

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command;
                    conn.Open();
                    command = new SqlCommand("DELETE FROM weather", conn);
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO weather VALUES('CVNP', 1, 25, 65, 'sunny')";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO weather VALUES('CVNP', 2, 10, 105, 'snow')";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO weather VALUES('CVNP', 3, 32, 40, 'cloudy')";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO weather VALUES('CVNP', 4, 50, 65, 'thunderstorms')";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO weather VALUES('CVNP', 5, -10, 22, 'rain')";
                    command.ExecuteNonQuery();
                }
            }
            catch(SqlException)
            {
                throw;
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void GetWeatherByCodeTest()
        {
            ParkWeatherSqlDal weatherDalTestObj = new ParkWeatherSqlDal(connectionString);
            List<Weather> weatherTestList = weatherDalTestObj.GetWeatherByCode("CVNP");

            Assert.AreEqual(5, weatherTestList.Count);
            Assert.AreEqual(weatherAssertObj.Forecast, weatherTestList[2].Forecast);
            Assert.AreEqual(weatherAssertObj.High, weatherTestList[2].High);
            Assert.AreEqual(weatherAssertObj.Low, weatherTestList[2].Low);
            Assert.AreEqual(weatherAssertObj.FiveDayForcastValue, weatherTestList[2].FiveDayForcastValue);
            Assert.AreEqual(weatherAssertObj.ParkCode, weatherTestList[2].ParkCode);
        }
    }
}
