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
            Park model = parkDal.GetParkByCode(id);
            model.Weather = weatherDal.GetWeatherByCode(id);
            return View(model);
        }

        // GET: Home/Survey
        public ActionResult Survey()
        {
            List<SelectListItem> parks = new List<SelectListItem>();

            foreach(Park p in parkDal.GetAllParks())
            {
                SelectListItem s = new SelectListItem() { Text = p.ParkName, Value = p.ParkCode };
                parks.Add(s);
            }

            ViewBag.Parks = parks;

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
            Park model = parkDal.GetParkByCode(surveyDal.ReturnMostPopularPark());
            return View(model);
        }
    }
}