using RequestAirplaneTicketPassenger = SBSWebProject.Data.Entities.RequestAirplaneTicketPassenger;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class RequestAirplaneTicketPassengerMapper : IMappingObject<Web.Api.Models.RequestAirplaneTicketPassenger, RequestAirplaneTicketPassenger>
    {
        public RequestAirplaneTicketPassenger Map(Web.Api.Models.RequestAirplaneTicketPassenger objectToMap)
        {
            if (objectToMap == null) return null;
            var passengerMapper = new PassengerMapper();
            var requestAirplaneTicketMapper = new RequestAirplaneTicketMapper();
            var outputModel = new RequestAirplaneTicketPassenger
            {
                Id = objectToMap.Id,
                PassengersItem = passengerMapper.Map(objectToMap.PassengersItem),
                RequestAirplaneTicketItem = requestAirplaneTicketMapper.Map(objectToMap.RequestAirplaneTicketItem)
            };
            return outputModel;
        }
        public RequestAirplaneTicketPassenger Map(Web.Api.Models.RequestAirplaneTicketPassenger objectToMap, RequestAirplaneTicketPassenger refObj)
        {
            if (objectToMap == null) return null;
            var passengerMapper = new PassengerMapper();
            var requestAirplaneTicketMapper = new RequestAirplaneTicketMapper();
            refObj.Id = objectToMap.Id;
            refObj.PassengersItem = passengerMapper.Map(objectToMap.PassengersItem);
            refObj.RequestAirplaneTicketItem = requestAirplaneTicketMapper.Map(objectToMap.RequestAirplaneTicketItem);
            return refObj;
        }
    }
}
