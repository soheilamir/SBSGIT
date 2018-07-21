using AirportNameByLanguage = SBSWebProject.Data.Entities.AirportNameByLanguage;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class AirportNameByLanguageMapper : IMappingObject<Web.Api.Models.AirportNameByLanguage, AirportNameByLanguage>
    {
        public AirportNameByLanguage Map(Web.Api.Models.AirportNameByLanguage objectToMap)
        {
            if (objectToMap == null) return null;
            var languageMapping = new LanguageMapper();
            var airportMapping = new AirportMapper();
            var outputModel = new AirportNameByLanguage
            {
                AirportName = objectToMap.AirportName,
                AirportsItem = airportMapping.Map(objectToMap.AirportsItem),
                Id = objectToMap.Id,
                LanguagesItem = languageMapping.Map(objectToMap.LanguagesItem)
            };
            return outputModel;
        }
    }
}
