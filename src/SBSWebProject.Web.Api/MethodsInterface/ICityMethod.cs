using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityModel = SBSWebProject.Web.Api.Models.City;
using CityEntity = SBSWebProject.Data.Entities.City;

namespace SBSWebProject.Web.Api.MethodsInterface
{
    public interface ICityMethod
    {
        CityModel GetCityById(long id);
        CityModel GetCityByName(long languageId, string cityName);
    }
}
