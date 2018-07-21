using UserPassenger = SBSWebProject.Web.Api.Models.UserPassenger;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class UserPassengerMapper : IMappingObject<Data.Entities.UserPassenger, UserPassenger>
    {
        public UserPassenger Map(Data.Entities.UserPassenger objectToMap)
        {
            if (objectToMap == null) return null;
            var passengerMapper = new PassengerMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new UserPassenger
            {
                Id = objectToMap.Id,
                UsersItem = usersMapper.Map(objectToMap.UsersItem),
                PassengersItem = passengerMapper.Map(objectToMap.PassengersItem)
            };
            return outputModel;
        }
    }
}
