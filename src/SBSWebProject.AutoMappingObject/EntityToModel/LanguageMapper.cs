using System.Linq;
using Language = SBSWebProject.Web.Api.Models.Languages;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class LanguageMapper : IMappingObject<Data.Entities.Languages, Language>
    {
        public Language Map(Data.Entities.Languages objectToMap)
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
                //AirlineNameByLanguageS = objectToMap.AirlineNameByLanguageS.Where(c => c.State == 0).Select(item => airlineNameByLanguageMapper.Map(item)).ToList(),
                //CountryNameByLanguageS = objectToMap.CountryNameByLanguageS.Where(c => c.State == 0).Select(item => countryNameByLanguageMapper.Map(item)).ToList(),
                //CityNameByLanguageS = objectToMap.CityNameByLanguageS.Where(c => c.State == 0).Select(item => cityNameByLanguageMapper.Map(item)).ToList(),
                //AirportNameByLanguageS = objectToMap.AirportNameByLanguageS.Where(c => c.State == 0).Select(item => airportNameByLanguageMapper.Map(item)).ToList(),
                //StateProvinceNameByLanguageS = objectToMap.StateProvinceNameByLanguageS.Where(c => c.State == 0).Select(item => stateProvinceNameByLanguageMapper.Map(item)).ToList(),
                //UserLanguagesS = objectToMap.UserLanguagesS.Where(c => c.State == 0).Select(item => userLanguageMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
