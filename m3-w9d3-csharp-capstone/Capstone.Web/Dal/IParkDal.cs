using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.Dal
{
    public interface IParkDal
    {
        List<Park> GetAllParks();
        Park GetParkByCode(string code);
    }
}