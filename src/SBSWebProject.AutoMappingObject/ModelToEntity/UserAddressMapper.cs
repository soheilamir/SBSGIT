using System.Linq;
using UserAddresses = SBSWebProject.Data.Entities.UserAddresses;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class UserAddressMapper : IMappingObject<Web.Api.Models.UserAddresses, UserAddresses>
    {
        public UserAddresses Map(Web.Api.Models.UserAddresses objectToMap)
        {
            if (objectToMap == null) return null;
            var userTelMapper = new UserTelMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new UserAddresses
            {
                Id = objectToMap.Id,
                UsersItem = usersMapper.Map(objectToMap.UsersItem),
                Address = objectToMap.Address,
                AddressType = objectToMap.AddressType,
                PostalCode = objectToMap.PostalCode,
                //UserTelsS = objectToMap.UserTelsS.Select(item => userTelMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public UserAddresses Map(Web.Api.Models.UserAddresses objectToMap, UserAddresses refObj)
        {
            if (objectToMap == null) return null;
            var userTelMapper = new UserTelMapper();
            var usersMapper = new UsersMapper();
            refObj.Id = objectToMap.Id;
            refObj.UsersItem = usersMapper.Map(objectToMap.UsersItem);
            refObj.Address = objectToMap.Address;
            refObj.AddressType = objectToMap.AddressType;
            refObj.PostalCode = objectToMap.PostalCode;
            //UserTelsS = objectToMap.UserTelsS.Select(item => userTelMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
