using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.Dal
{
    public interface ISurveyDal
    {
        bool InsertSurvey(Survey submittedSurvey);
        string ReturnMostPopularPark();
    }
}
