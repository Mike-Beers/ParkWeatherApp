using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Dal;
using Capstone.Web.Models;

namespace Capstone.Web.Tests.DALTests
{
    [TestClass]
    public class SurveySqlDalTest
    {
        private TransactionScope tran;
        private string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=ParkWeatherDb;Integrated Security=True";

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void SubmitSurveyTest()
        {
            Survey p = new Survey
            {
                ParkCode = "CVNP",
                EmailAddress = "techelevator@gmail.com",
                State = "Ohio",
                ActivityLevel = "active"
            };

            SurveySqlDal surveyDal = new SurveySqlDal(connectionString);
            surveyDal.InsertSurvey(p);
            Assert.AreEqual(surveyDal.InsertSurvey(p), true);
        }
    }
}
