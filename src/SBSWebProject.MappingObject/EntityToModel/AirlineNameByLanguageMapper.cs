using AirlineNameByLanguage = SBSWebProject.Web.Api.Models.AirlineNameByLanguage;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class AirlineNameByLanguageMapper : IMappingObject<Data.Entities.AirlineNameByLanguage, AirlineNameByLanguage>
    {
        public AirlineNameByLanguage Map(Data.Entities.AirlineNameByLanguage objectToMap)
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
