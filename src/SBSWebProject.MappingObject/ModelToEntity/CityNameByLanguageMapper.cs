using CityNameByLanguage = SBSWebProject.Data.Entities.CityNameByLanguage;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class CityNameByLanguageMapper : IMappingObject<Web.Api.Models.CityNameByLanguage, CityNameByLanguage>
    {
        public CityNameByLanguage Map(Web.Api.Models.CityNameByLanguage objectToMap)
        {
            if (objectToMap == null) return null;
            var languageMapper = new LanguageMapper();
            var cityMapper = new ModelToEntity.CityMapper();
            var outputModel = new CityNameByLanguage
            {
                Id = objectToMap.Id,
                Name = objectToMap.Name,
                LanguagesItem = languageMapper.Map(objectToMap.LanguagesItem),
                CityItem = cityMapper.Map(objectToMap.CityItem)
            };
            return outputModel;
        }
    }
}
