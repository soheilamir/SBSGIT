using RequestAirplaneTicketPassenger = SBSWebProject.Data.Entities.RequestAirplaneTicketPassenger;

namespace SBSWebProject.MappingObject.ModelToEntity
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
    }
}
