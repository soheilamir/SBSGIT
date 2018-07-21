using AirlineMember = SBSWebProject.Web.Api.Models.AirlineMembers;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class AirlineMemberMapper : IMappingObject<Data.Entities.AirlineMembers, AirlineMember>
    {
        public AirlineMember Map(Data.Entities.AirlineMembers objectToMap)
        {
            if (objectToMap == null) return null;
            var usersMapping = new UsersMapper();
            var passengerMapper = new PassengerMapper();
            var airlineMapper = new AirlineMapper();
            var outputModel = new AirlineMember
            {
                Id = objectToMap.Id,
                MembershipNumber = objectToMap.MembershipNumber,
                RegisteredDate = objectToMap.RegisteredDate,
                UsersItem = usersMapping.Map(objectToMap.UsersItem),
                PassengersItem = passengerMapper.Map(objectToMap.PassengersItem),
                AirlinesItem = airlineMapper.Map(objectToMap.AirlinesItem)
            };
            return outputModel;
        }
    }
}
