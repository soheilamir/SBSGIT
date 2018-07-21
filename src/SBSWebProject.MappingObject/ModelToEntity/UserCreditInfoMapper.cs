using UserCreditInfo = SBSWebProject.Data.Entities.UserCreditInfo;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class UserCreditInfoMapper : IMappingObject<Web.Api.Models.UserCreditInfo, UserCreditInfo>
    {
        public UserCreditInfo Map(Web.Api.Models.UserCreditInfo objectToMap)
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
