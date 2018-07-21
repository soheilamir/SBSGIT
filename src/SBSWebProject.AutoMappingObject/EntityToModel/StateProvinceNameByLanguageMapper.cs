using StateProvinceNameByLanguage = SBSWebProject.Web.Api.Models.StateProvinceNameByLanguage;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class StateProvinceNameByLanguageMapper : IMappingObject<Data.Entities.StateProvinceNameByLanguage, StateProvinceNameByLanguage>
    {
        public StateProvinceNameByLanguage Map(Data.Entities.StateProvinceNameByLanguage objectToMap)
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
