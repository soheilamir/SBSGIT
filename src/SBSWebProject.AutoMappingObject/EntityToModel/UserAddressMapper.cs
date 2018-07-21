using System.Linq;
using UserAddresses = SBSWebProject.Web.Api.Models.UserAddresses;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class UserAddressMapper : IMappingObject<Data.Entities.UserAddresses, UserAddresses>
    {
        public UserAddresses Map(Data.Entities.UserAddresses objectToMap)
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
                //UserTelsS = objectToMap.UserTelsS.Where(c => c.State == 0).Select(item => userTelMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
