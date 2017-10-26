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
            this.parkDal = parkDal;
        }

        // GET: Home
        public ActionResult Index()
        {
            List<Park> parks = parkDal.GetAllParks();
            return View(parks);
        }
        public ActionResult Detail(string id)
        {
            if (Session["Fahrenheit"] == null)
            {
                Session["Fahrenheit"] = true;
            }
            Park model = parkDal.GetParkByCode(id);
            model.Weather = weatherDal.GetWeatherByCode(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Detail(Park park)
        {
            if (Convert.ToBoolean(Session["Fahrenheit"]))
            {
                Session["Fahrenheit"] = false;
            }
            else
            {
                Session["Fahrenheit"] = true;
            }
            Park model = parkDal.GetParkByCode(park.ParkCode);
            model.Weather = weatherDal.GetWeatherByCode(park.ParkCode);
            string id = park.ParkCode;
            return RedirectToAction("Detail", "Home", id);
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
            ViewBag.ParkCode = parks;

            return View();
        }

        // POST: Home/Survey
        [HttpPost]
        public ActionResult Survey(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> parks = new List<SelectListItem>();

                foreach (Park p in parkDal.GetAllParks())
                {
                    SelectListItem s = new SelectListItem() { Text = p.ParkName, Value = p.ParkCode };
                    parks.Add(s);
                }

                ViewBag.ParkCode = parks;

                return View("Survey", survey);
            }
            else
            {
                surveyDal.InsertSurvey(survey);
            }

            return RedirectToAction("SurveyConfirmation");
        }

        public ActionResult SurveyConfirmation()
        {
            Park model = parkDal.GetParkByCode(surveyDal.ReturnMostPopularPark());
            return View(model);
        }
    }
}