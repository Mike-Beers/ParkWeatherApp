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
    public class ParkSqlDalTest
    {
        private TransactionScope tran;
        private string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=ParkWeatherDb;Integrated Security=True";
        string code = "";
        int parkCount = 0;

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                conn.Open();

                cmd = new SqlCommand("INSERT INTO park VALUES ('CONG', 'Congaree National Park', 'South Carolina', 23, 0, 2, 12, 'Woodland', 1999, 12321, 'It was awesome', 'Taco', 'its flat', 0, 218301)", conn);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("SELECT parkCode FROM park WHERE parkName = 'Congaree National Park'", conn);
                code = Convert.ToString(cmd.ExecuteScalar());

                cmd = new SqlCommand("select count( parkCode) from park", conn);
                parkCount = Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void GetCampgroundByCodeTest()
        {
            Park p = new Park();
            ParkSqlDal parkDal = new ParkSqlDal(connectionString);
            p = parkDal.GetParkByCode(code);
            Assert.AreEqual(code, p.ParkCode);
        }

        [TestMethod]
        public void GetAllParksTest()
        {
            List<Park> p = new List<Park>();
            ParkSqlDal parkDal = new ParkSqlDal(connectionString);
            p = parkDal.GetAllParks();
            Assert.AreEqual(parkCount, p.Count);
        }
    }
}
