using SBSWebProject.Web.Api.MethodsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SBSWebProject.Web.Api.Models;

namespace SBSWebProject.Web.Api.OperatingMethods
{
    public class CityMethod : ICityMethod
    {
        public City GetCityById(long id)
        {
            throw new NotImplementedException();
        }

        public City GetCityByName(long languageId, string cityName)
        {
            throw new NotImplementedException();
        }
    }
}