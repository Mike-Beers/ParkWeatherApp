using Capstone.Web.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IParkWeatherDal weatherDal;
        private readonly ISurveyDal surveyDal;
        private readonly IParkDal parkDal;

        public HomeController(IParkWeatherDal weatherDal, ISurveyDal surveyDal, IParkDal parkDal)
        {
            this.weatherDal = weatherDal;
            this.surveyDal = surveyDal;
            this.parkDal = parkDal;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}