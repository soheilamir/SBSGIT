using AirportNameByLanguage = SBSWebProject.Web.Api.Models.AirportNameByLanguage;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class AirportNameByLanguageMapper : IMappingObject<Data.Entities.AirportNameByLanguage, AirportNameByLanguage>
    {
        public AirportNameByLanguage Map(Data.Entities.AirportNameByLanguage objectToMap)
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
