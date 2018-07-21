using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelCountryModel = SBSWebProject.Web.Api.Models.ExcelReaderCountry;
using CountryModel = SBSWebProject.Web.Api.Models.Country;
using CountryNameByLanguageEntity = SBSWebProject.Data.Entities.CountryNameByLanguage;
using LanguagesModel = SBSWebProject.Web.Api.Models.Languages;
using StateProvinceModel = SBSWebProject.Web.Api.Models.StateProvince;
using CityModel = SBSWebProject.Web.Api.Models.City;

namespace SBSWebProject.Web.Api.MethodsInterface
{
    public interface ICountryMethod
    {
        CountryModel GetCountryById(long id);
        CountryModel GetCountryByName(long languageId, string name);
        IList<StateProvinceModel> GetInternationalStateByCountry(long countryId);
        void AddCountry(ExcelCountryModel newCountry, CountryNameByLanguageEntity newCountryName);
        IList<CountryModel> GetInternationalCountriesList();
        IList<CityModel> GetInternationalCityByState(long stateId);
    }
}
