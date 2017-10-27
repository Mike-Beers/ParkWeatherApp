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
using Capstone.UITests;
using Capstone.Web.Tests.PageObjects;

namespace Capstone.Web.Controllers.Tests
{
    [TestClass]
    public class HomeControllerTests { 

        private static IWebDriver driver;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:55601/");
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }


        [TestMethod]
        public void HomeController_IndexAction_ReturnIndexView()
        {
            IndexPage entryPage = new IndexPage(driver);
            string result = entryPage.Url;
            Assert.AreEqual("/Home/Index", result);

        }
        [TestMethod]
        public void HomeController_DetailAction_ReturnSpecificPark()
        {
            DetailPage detailPage = new DetailPage(driver);
            string result = detailPage.Url;
            Assert.AreEqual("/Home/Detail", result);
        }
        [TestMethod]
        public void HomeController_SurveyAction_ReturnSurveyView()
        {
            SurveyPage surveyPage = new SurveyPage(driver);
            string result = surveyPage.Url;
            Assert.AreEqual("/Home/Survey", result);
        }
        [TestMethod]
        public void Survey_SaveAndRedirect()
        {
            SurveyPage surveyPage = new SurveyPage(driver);
            surveyPage.Navigate();
            string result = surveyPage.FillOutForm("Glacier National Park", "rob@rob.com", "PA", "Active").Url;
            Assert.AreEqual("/Home/SurveyConfirmation", result);
        }
        [TestMethod]
        public void SurveyConfirmation_Redirect()
        {
            SurveyConfirmationPage surveyPage = new SurveyConfirmationPage(driver);
            surveyPage.Navigate();
            DetailPage tacoSalad = surveyPage.SurveyRedirect();
            
            string result = tacoSalad.Url;
            Assert.AreEqual("/Home/Detail", result);
        }
    }
}          

