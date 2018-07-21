using UserLanguages = SBSWebProject.Data.Entities.UserLanguages;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class UserLanguageMapper : IMappingObject<Web.Api.Models.UserLanguages, UserLanguages>
    {
        public UserLanguages Map(Web.Api.Models.UserLanguages objectToMap)
        {
            if (objectToMap == null) return null;
            var languageMapper = new LanguageMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new UserLanguages
            {
                Id = objectToMap.Id,
                UsersItem = usersMapper.Map(objectToMap.UsersItem),
                LanguagesItem = languageMapper.Map(objectToMap.LanguagesItem),
                Proficiency = objectToMap.Proficiency
            };
            return outputModel;
        }
        public UserLanguages Map(Web.Api.Models.UserLanguages objectToMap, UserLanguages refObj)
        {
            if (objectToMap == null) return null;
            var languageMapper = new LanguageMapper();
            var usersMapper = new UsersMapper();

            refObj.Id = objectToMap.Id;
            refObj.UsersItem = usersMapper.Map(objectToMap.UsersItem);
            refObj.LanguagesItem = languageMapper.Map(objectToMap.LanguagesItem);
            refObj.Proficiency = objectToMap.Proficiency;
            return refObj;
        }
    }
}
