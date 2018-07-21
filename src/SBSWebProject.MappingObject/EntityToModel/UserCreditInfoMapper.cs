using UserCreditInfo = SBSWebProject.Web.Api.Models.UserCreditInfo;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class UserCreditInfoMapper : IMappingObject<Data.Entities.UserCreditInfo, UserCreditInfo>
    {
        public UserCreditInfo Map(Data.Entities.UserCreditInfo objectToMap)
        {
            if (objectToMap == null) return null;
            var requestAirplaneTicketMapper = new RequestAirplaneTicketMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new UserCreditInfo
            {
                Id = objectToMap.Id,
                UsersItem = usersMapper.Map(objectToMap.UsersItem)
            };
            return outputModel;
        }
    }
}
