using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.Tests.PageObjects
{
    public class SurveyConfirmationPage : BasePage
    {
        public SurveyConfirmationPage(IWebDriver driver)
            : base(driver, "/Home/SurveyConfirmationPage")
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "button")]
        public IWebElement CalculateButton { get; set; }
    }
}
