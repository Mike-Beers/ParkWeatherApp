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
    public class SurveyPage : BasePage
    {
        public SurveyPage(IWebDriver driver)
            : base(driver, "/Home/Survey")
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "ParkCode")]
        public IWebElement ParkCode { get; set; }

        [FindsBy(How = How.Name, Using = "EmailAddress")]
        public IWebElement EmailAddress { get; set; }

        [FindsBy(How = How.Name, Using = "State")]
        public IWebElement State { get; set; }

        [FindsBy(How = How.Name, Using = "ActivityLevel")]
        public IWebElement ActivityLevel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button")]
        public IWebElement SubmitButton { get; set; }

        public SurveyConfirmationPage FillOutForm(string parkCode, string emailAddress, string state, string activityLevel)
        {
            SelectElement parkCodeDropDown = new SelectElement(ParkCode);
            parkCodeDropDown.SelectByValue(parkCode);

            EmailAddress.SendKeys(emailAddress);

            SelectElement stateDropDown = new SelectElement(State);
            stateDropDown.SelectByText(state);

            SelectElement activityLevelDropDown = new SelectElement(ActivityLevel);
            activityLevelDropDown.SelectByValue(activityLevel);

            SubmitButton.Click();

            return new SurveyConfirmationPage(driver);
        }
    }
}
