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
    public class IndexPage : BasePage
    {
        public IndexPage(IWebDriver driver)
            : base(driver, "/Home/Index")
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
