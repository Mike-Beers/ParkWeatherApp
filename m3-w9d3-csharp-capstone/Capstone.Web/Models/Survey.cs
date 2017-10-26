using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public string ParkCode { get; set; }
        public string EmailAddress { get; set; }
        public string State { get; set; }
        public string ActivityLevel { get; set; }

        public static List<SelectListItem> activityLevelList { get; } = new List<SelectListItem>
        {
            new SelectListItem() { Value = "inactive", Text = "Inactive" },
            new SelectListItem() { Value = "sedentary", Text = "Sedentary" },
            new SelectListItem() { Value = "active", Text = "Active" },
            new SelectListItem() { Value = "extremely active", Text = "Extremely active" }
        };

        public static List<SelectListItem> states = new List<SelectListItem>()
        {
            new SelectListItem() {Value = "Alabama", Text = "AL"},
            new SelectListItem() {Value = "Alaska", Text = "AK"},
            new SelectListItem() {Value = "Arizona", Text = "AZ"},
            new SelectListItem() {Value = "Arkansas", Text = "AR"},
            new SelectListItem() {Value = "California", Text = "CA"},
            new SelectListItem() {Value = "Colorado", Text = "CO"},
            new SelectListItem() {Value = "Connecticut", Text = "CT"},
            new SelectListItem() {Value = "District of Columbia", Text = "DC"},
            new SelectListItem() {Value = "Delaware", Text = "DE"},
            new SelectListItem() {Value = "Florida", Text = "FL"},
            new SelectListItem() {Value = "Georgia", Text = "GA"},
            new SelectListItem() {Value = "Hawaii", Text = "HI"},
            new SelectListItem() {Value = "Idaho", Text = "ID"},
            new SelectListItem() {Value = "Illinois", Text = "IL"},
            new SelectListItem() {Value = "Indiana", Text = "IN"},
            new SelectListItem() {Value = "Iowa", Text = "IA"},
            new SelectListItem() {Value = "Kansas", Text = "KS"},
            new SelectListItem() {Value = "Kentucky", Text = "KY"},
            new SelectListItem() {Value = "Louisiana", Text = "LA"},
            new SelectListItem() {Value = "Maine", Text = "ME"},
            new SelectListItem() {Value = "Maryland", Text = "MD"},
            new SelectListItem() {Value = "Massachusetts", Text = "MA"},
            new SelectListItem() {Value = "Michigan", Text = "MI"},
            new SelectListItem() {Value = "Minnesota", Text = "MN"},
            new SelectListItem() {Value = "Mississippi", Text = "MS"},
            new SelectListItem() {Value = "Missouri", Text = "MO"},
            new SelectListItem() {Value = "Montana", Text = "MT"},
            new SelectListItem() {Value = "Nebraska", Text = "NE"},
            new SelectListItem() {Value = "Nevada", Text = "NV"},
            new SelectListItem() {Value = "New Hampshire", Text = "NH"},
            new SelectListItem() {Value = "New Jersey", Text = "NJ"},
            new SelectListItem() {Value = "New Mexico", Text = "NM"},
            new SelectListItem() {Value = "New York", Text = "NY"},
            new SelectListItem() {Value = "North Carolina", Text = "NC"},
            new SelectListItem() {Value = "North Dakota", Text = "ND"},
            new SelectListItem() {Value = "Ohio", Text = "OH"},
            new SelectListItem() {Value = "Oklahoma", Text = "OK"},
            new SelectListItem() {Value = "Oregon", Text = "OR"},
            new SelectListItem() {Value = "Pennsylvania", Text = "PA"},
            new SelectListItem() {Value = "Rhode Island", Text = "RI"},
            new SelectListItem() {Value = "South Carolina", Text = "SC"},
            new SelectListItem() {Value = "South Dakota", Text = "SD"},
            new SelectListItem() {Value = "Tennessee", Text = "TN"},
            new SelectListItem() {Value = "Texas", Text = "TX"},
            new SelectListItem() {Value = "Utah", Text = "UT"},
            new SelectListItem() {Value = "Vermont", Text = "VT"},
            new SelectListItem() {Value = "Virginia", Text = "VA"},
            new SelectListItem() {Value = "Washington", Text = "WA"},
            new SelectListItem() {Value = "West Virginia", Text = "WV"},
            new SelectListItem() {Value = "Wisconsin", Text = "WI"},
            new SelectListItem() {Value = "Wyoming", Text = "WY"}
        };

    }
}