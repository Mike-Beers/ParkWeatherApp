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
    public class DetailPage : BasePage
    {
        public DetailPage(IWebDriver driver)
            : base(driver, "/Home/Detail")
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "temp button")]
        public IWebElement CalculateButton { get; set; }

        
    }

}
