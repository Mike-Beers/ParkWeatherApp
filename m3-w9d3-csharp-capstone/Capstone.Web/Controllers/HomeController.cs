using Capstone.Web.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;
using System.Configuration;

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
            this.parkDal = new ParkSqlDal(ConfigurationManager.ConnectionStrings["ParkWeatherDb"].ConnectionString);
        }

        // GET: Home
        public ActionResult Index()
        {
            List<Park> parks = parkDal.GetAllParks();
            return View(parks);
        }
        public ActionResult Detail(string id)
        {
            return View();
        }

        // GET: Home/Survey
        public ActionResult Survey()
        {
            return View();
        }

        // POST: Home/Survey
        [HttpPost]
        public ActionResult Survey(Survey survey)
        {
            return RedirectToAction("SurveyConfirmation");
        }
        public ActionResult SurveyConfirmation()
        {
            return View();
        }
    }
}