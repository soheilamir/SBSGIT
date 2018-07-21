using System.Linq;
using Language = SBSWebProject.Data.Entities.Languages;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class LanguageMapper : IMappingObject<Web.Api.Models.Languages, Language>
    {
        public Language Map(Web.Api.Models.Languages objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineNameByLanguageMapper = new AirlineNameByLanguageMapper();
            var countryNameByLanguageMapper = new CountryNameByLanguageMapper();
            var cityNameByLanguageMapper = new CityNameByLanguageMapper();
            var airportNameByLanguageMapper = new AirportNameByLanguageMapper();
            var stateProvinceNameByLanguageMapper = new StateProvinceNameByLanguageMapper();
            var userLanguageMapper = new UserLanguageMapper();
            var outputModel = new Language
            {
                Id = objectToMap.Id,
                ISO6391 = objectToMap.ISO6391,
                ISO6392 = objectToMap.ISO6392,
                LanguageName = objectToMap.LanguageName,
                TextDirection = objectToMap.TextDirection,
                //AirlineNameByLanguageS = objectToMap.AirlineNameByLanguageS.Select(item => airlineNameByLanguageMapper.Map(item)).ToList(),
                //CountryNameByLanguageS = objectToMap.CountryNameByLanguageS.Select(item => countryNameByLanguageMapper.Map(item)).ToList(),
                //CityNameByLanguageS = objectToMap.CityNameByLanguageS.Select(item => cityNameByLanguageMapper.Map(item)).ToList(),
                //AirportNameByLanguageS = objectToMap.AirportNameByLanguageS.Select(item => airportNameByLanguageMapper.Map(item)).ToList(),
                //StateProvinceNameByLanguageS = objectToMap.StateProvinceNameByLanguageS.Select(item => stateProvinceNameByLanguageMapper.Map(item)).ToList(),
                //UserLanguagesS = objectToMap.UserLanguagesS.Select(item => userLanguageMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public Language Map(Web.Api.Models.Languages objectToMap, Language refObj)
        {
            if (objectToMap == null) return null;
            var airlineNameByLanguageMapper = new AirlineNameByLanguageMapper();
            var countryNameByLanguageMapper = new CountryNameByLanguageMapper();
            var cityNameByLanguageMapper = new CityNameByLanguageMapper();
            var airportNameByLanguageMapper = new AirportNameByLanguageMapper();
            var stateProvinceNameByLanguageMapper = new StateProvinceNameByLanguageMapper();
            var userLanguageMapper = new UserLanguageMapper();
            refObj.Id = objectToMap.Id;
            refObj.ISO6391 = objectToMap.ISO6391;
            refObj.ISO6392 = objectToMap.ISO6392;
            refObj.LanguageName = objectToMap.LanguageName;
            refObj.TextDirection = objectToMap.TextDirection;
            //AirlineNameByLanguageS = objectToMap.AirlineNameByLanguageS.Select(item => airlineNameByLanguageMapper.Map(item)).ToList(),
            //CountryNameByLanguageS = objectToMap.CountryNameByLanguageS.Select(item => countryNameByLanguageMapper.Map(item)).ToList(),
            //CityNameByLanguageS = objectToMap.CityNameByLanguageS.Select(item => cityNameByLanguageMapper.Map(item)).ToList(),
            //AirportNameByLanguageS = objectToMap.AirportNameByLanguageS.Select(item => airportNameByLanguageMapper.Map(item)).ToList(),
            //StateProvinceNameByLanguageS = objectToMap.StateProvinceNameByLanguageS.Select(item => stateProvinceNameByLanguageMapper.Map(item)).ToList(),
            //UserLanguagesS = objectToMap.UserLanguagesS.Select(item => userLanguageMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
