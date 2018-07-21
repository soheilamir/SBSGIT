using UserEmails = SBSWebProject.Web.Api.Models.UserEmails;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class UserEmailMapper : IMappingObject<Data.Entities.UserEmails, UserEmails>
    {
        public UserEmails Map(Data.Entities.UserEmails objectToMap)
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
