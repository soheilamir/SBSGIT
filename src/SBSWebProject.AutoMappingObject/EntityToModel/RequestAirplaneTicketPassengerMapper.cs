using RequestAirplaneTicketPassenger = SBSWebProject.Web.Api.Models.RequestAirplaneTicketPassenger;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class RequestAirplaneTicketPassengerMapper : IMappingObject<Data.Entities.RequestAirplaneTicketPassenger, RequestAirplaneTicketPassenger>
    {
        public RequestAirplaneTicketPassenger Map(Data.Entities.RequestAirplaneTicketPassenger objectToMap)
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
