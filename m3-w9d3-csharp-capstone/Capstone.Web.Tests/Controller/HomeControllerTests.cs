using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Capstone.Web.Dal;
using Capstone.Web.Models;
using System.Configuration;
using Moq;

namespace Capstone.Web.Tests.Controller
{
    class HomeControllerTests
    {
        //[TestMethod]
        //public void HomeController_DetailAction_ReturnSpecificPark()
        //{
        //    string input = "CVNP";
        //    HomeController controller = new HomeController(null, null, null);
        //    ViewResult result = controller.Detail(input) as ViewResult;
        //    Assert.AreEqual("Detail/CVNP", result.ViewName);
        //}
        //[TestMethod]
        //public void HomeController_SurveyAction_ReturnSurveyView()
        //{
        //    HomeController controller = new HomeController(null, null, null);
        //    ViewResult result = controller.Survey() as ViewResult;
        //    Assert.AreEqual("Survey", result.ViewName);
        //}
        //[TestMethod]
        //public void Survey_SaveAndRedirect()
        //{
        //    Mock<ISurveyDal> mockDal = new Mock<ISurveyDal>();
        //    Survey model = new Survey();
        //    HomeController controller = new HomeController(null, null, null);
        //    RedirectToRouteResult result = controller.Survey(model) as RedirectToRouteResult;
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual("SurveyConfirmation", result.RouteValues["action"]);
        //    mockDal.Verify(m => m.InsertSurvey(model));
        //}
        //[TestMethod]
        //public void SurveyConfirmation_ReturnCorrectView()
        //{
        //    HomeController controller = new HomeController(null, null, null);
        //    ViewResult result = controller.SurveyConfirmation() as ViewResult;
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual("SurveyConfirmation", result.ViewName);
        //}
    }
}
