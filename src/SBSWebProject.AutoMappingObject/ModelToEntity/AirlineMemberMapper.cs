using AirlineMember = SBSWebProject.Data.Entities.AirlineMembers;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class AirlineMemberMapper : IMappingObject<Web.Api.Models.AirlineMembers, AirlineMember>
    {
        public AirlineMember Map(Web.Api.Models.AirlineMembers objectToMap)
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
        public AirlineMember Map(Web.Api.Models.AirlineMembers objectToMap, AirlineMember refObj)
        {
            if (objectToMap == null) return null;
            var usersMapping = new UsersMapper();
            var passengerMapper = new PassengerMapper();
            var airlineMapper = new AirlineMapper();
            refObj.Id = objectToMap.Id;
            refObj.MembershipNumber = objectToMap.MembershipNumber;
            refObj.RegisteredDate = objectToMap.RegisteredDate;
            refObj.UsersItem = usersMapping.Map(objectToMap.UsersItem);
            refObj.PassengersItem = passengerMapper.Map(objectToMap.PassengersItem);
            refObj.AirlinesItem = airlineMapper.Map(objectToMap.AirlinesItem);
            return refObj;
        }
    }
}
