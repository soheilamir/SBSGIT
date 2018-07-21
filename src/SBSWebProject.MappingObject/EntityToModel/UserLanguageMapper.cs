using UserLanguages = SBSWebProject.Web.Api.Models.UserLanguages;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class UserLanguageMapper : IMappingObject<Data.Entities.UserLanguages, UserLanguages>
    {
        public UserLanguages Map(Data.Entities.UserLanguages objectToMap)
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
    }
}
