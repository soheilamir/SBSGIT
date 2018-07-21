using AirlineNameByLanguage = SBSWebProject.Data.Entities.AirlineNameByLanguage;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class AirlineNameByLanguageMapper : IMappingObject<Web.Api.Models.AirlineNameByLanguage, AirlineNameByLanguage>
    {
        public AirlineNameByLanguage Map(Web.Api.Models.AirlineNameByLanguage objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineMapping = new AirlineMapper();
            var languageMapping = new LanguageMapper();
            var outputModel = new AirlineNameByLanguage
            {
                Id = objectToMap.Id,
                AirlineName = objectToMap.AirlineName,
                AirlinesItem = airlineMapping.Map(objectToMap.AirlinesItem),
                LanguagesItem = languageMapping.Map(objectToMap.LanguagesItem)
            };
            return outputModel;
        }
    }
}
