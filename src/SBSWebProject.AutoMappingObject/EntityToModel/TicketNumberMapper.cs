using TicketNumbers = SBSWebProject.Web.Api.Models.TicketNumbers;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class TicketNumberMapper : IMappingObject<Data.Entities.TicketNumbers, TicketNumbers>
    {
        public TicketNumbers Map(Data.Entities.TicketNumbers objectToMap)
        {
            if (objectToMap == null) return null;
            var responseAirplaneTicketMapper = new ResponseAirplaneTicketMapper();
            var passengerMapper = new PassengerMapper();
            var outputModel = new TicketNumbers
            {
                Id = objectToMap.Id,
                PassengersItem = passengerMapper.Map(objectToMap.PassengersItem),
                ResponseAirplaneTicketItem = responseAirplaneTicketMapper.Map(objectToMap.ResponseAirplaneTicketItem),
                TicketNumber = objectToMap.TicketNumber
            };
            return outputModel;
        }
    }
}
