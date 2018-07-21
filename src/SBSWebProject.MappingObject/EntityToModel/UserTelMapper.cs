using UserTels = SBSWebProject.Web.Api.Models.UserTels;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class UserTelMapper : IMappingObject<Data.Entities.UserTels, UserTels>
    {
        public UserTels Map(Data.Entities.UserTels objectToMap)
        {
            if (objectToMap == null) return null;
            var userAddressMapper = new UserAddressMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new UserTels
            {
                Id = objectToMap.Id,
                UsersItem = usersMapper.Map(objectToMap.UsersItem),
                TelNumber = objectToMap.TelNumber,
                TelType = objectToMap.TelType,
                UserAddressesItem = userAddressMapper.Map(objectToMap.UserAddressesItem)
            };
            return outputModel;
        }
    }
}
