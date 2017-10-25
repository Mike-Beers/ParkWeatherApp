using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int FiveDayForcastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        public string Recommendation { get; set; }

        public int ToCelsius(int temp)
        {
            int tempCelsius;
            tempCelsius = (int)Math.Round((temp - 32) / 1.8);
            return tempCelsius;
        }
    }
}