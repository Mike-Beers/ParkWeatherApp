using Capstone.Web.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;

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
        public ActionResult Detail(string id)
        {
            Park model = parkDal.GetParkByCode(id);
            model.Weather = weatherDal.GetWeatherByCode(id);
            return View(model);
        }
        public ActionResult Survey()
        {
            return View();
        }
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