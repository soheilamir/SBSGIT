using TicketNumbers = SBSWebProject.Data.Entities.TicketNumbers;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class TicketNumberMapper : IMappingObject<Web.Api.Models.TicketNumbers, TicketNumbers>
    {
        public TicketNumbers Map(Web.Api.Models.TicketNumbers objectToMap)
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
        public TicketNumbers Map(Web.Api.Models.TicketNumbers objectToMap, TicketNumbers refObj)
        {
            if (objectToMap == null) return null;
            var responseAirplaneTicketMapper = new ResponseAirplaneTicketMapper();
            var passengerMapper = new PassengerMapper();

            refObj.Id = objectToMap.Id;
            refObj.PassengersItem = passengerMapper.Map(objectToMap.PassengersItem);
            refObj.ResponseAirplaneTicketItem = responseAirplaneTicketMapper.Map(objectToMap.ResponseAirplaneTicketItem);
            refObj.TicketNumber = objectToMap.TicketNumber;
            return refObj;
        }
    }
}

