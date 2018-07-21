using UserEmails = SBSWebProject.Data.Entities.UserEmails;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class UserEmailMapper : IMappingObject<Web.Api.Models.UserEmails, UserEmails>
    {
        public UserEmails Map(Web.Api.Models.UserEmails objectToMap)
        {
            if (objectToMap == null) return null;
            var requestAirplaneTicketMapper = new RequestAirplaneTicketMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new UserEmails
            {
                Id = objectToMap.Id,
                UsersItem = usersMapper.Map(objectToMap.UsersItem),
                Email = objectToMap.Email
            };
            return outputModel;
        }
    }
}
