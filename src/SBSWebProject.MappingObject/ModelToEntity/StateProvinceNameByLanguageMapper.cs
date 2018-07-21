using StateProvinceNameByLanguage = SBSWebProject.Data.Entities.StateProvinceNameByLanguage;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class StateProvinceNameByLanguageMapper : IMappingObject<Web.Api.Models.StateProvinceNameByLanguage, StateProvinceNameByLanguage>
    {
        public StateProvinceNameByLanguage Map(Web.Api.Models.StateProvinceNameByLanguage objectToMap)
        {
            if (objectToMap == null) return null;
            var stateProvinceMapper = new StateProvinceMapper();
            var languageMapper = new LanguageMapper();
            var outputModel = new StateProvinceNameByLanguage
            {
                Id = objectToMap.Id,
                LanguagesItem = languageMapper.Map(objectToMap.LanguagesItem),
                StateProvinceItem = stateProvinceMapper.Map(objectToMap.StateProvinceItem),
                StateProvinceName = objectToMap.StateProvinceName
            };
            return outputModel;
        }
    }
}
