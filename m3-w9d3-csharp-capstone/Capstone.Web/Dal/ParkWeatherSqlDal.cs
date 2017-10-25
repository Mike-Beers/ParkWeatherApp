
namespace Capstone.Web.Dal
{
    public class ParkWeatherSqlDal : IParkWeatherDal
    {
        

        private readonly string connectionString;

        public ParkWeatherSqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public int TestMethod()
        {
            return 0;
        }
    }
}

