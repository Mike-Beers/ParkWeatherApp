using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Models;

namespace Capstone.Web.Tests
{
    [TestClass]
    public class WeatherTests
    {
        [TestMethod]
        public void ToCelsiusTest()
        {
            Weather weatherTestObj = new Weather();
            Assert.AreEqual(0, weatherTestObj.ToCelsius(32));
            Assert.AreEqual(10, weatherTestObj.ToCelsius(50));
            Assert.AreEqual(-17, weatherTestObj.ToCelsius(2));
        }
    }
}
