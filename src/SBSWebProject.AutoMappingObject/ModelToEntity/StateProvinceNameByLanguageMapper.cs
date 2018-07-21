using StateProvinceNameByLanguage = SBSWebProject.Data.Entities.StateProvinceNameByLanguage;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
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
        public StateProvinceNameByLanguage Map(Web.Api.Models.StateProvinceNameByLanguage objectToMap, StateProvinceNameByLanguage refObj)
        {
            if (objectToMap == null) return null;
            var stateProvinceMapper = new StateProvinceMapper();
            var languageMapper = new LanguageMapper();
            refObj.Id = objectToMap.Id;
            refObj.LanguagesItem = languageMapper.Map(objectToMap.LanguagesItem);
            refObj.StateProvinceItem = stateProvinceMapper.Map(objectToMap.StateProvinceItem);
            refObj.StateProvinceName = objectToMap.StateProvinceName;
            return refObj;
        }
    }
}
