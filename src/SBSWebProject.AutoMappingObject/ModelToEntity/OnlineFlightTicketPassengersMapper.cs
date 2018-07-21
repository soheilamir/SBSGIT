using System.Linq;
using OnlineFlightTicketPassengers = SBSWebProject.Data.Entities.OnlineFlightTicketPassengers;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class OnlineFlightTicketPassengersMapper : IMappingObject<Web.Api.Models.OnlineFlightTicketPassengers, OnlineFlightTicketPassengers>
    {
        public OnlineFlightTicketPassengers Map(Web.Api.Models.OnlineFlightTicketPassengers objectToMap)
        {
            if (objectToMap == null) return null;
            var onlineFlightTicketMapper = new OnlineFlightTicketMapper();
            var passengerMapper = new PassengerMapper();
            var outputModel = new OnlineFlightTicketPassengers
            {
                Id = objectToMap.Id,
                OnlineFlightTicketItem = onlineFlightTicketMapper.Map(objectToMap.OnlineFlightTicketItem),
                PassengersItem = passengerMapper.Map(objectToMap.PassengersItem)
            };
            return outputModel;
        }
        public OnlineFlightTicketPassengers Map(Web.Api.Models.OnlineFlightTicketPassengers objectToMap, OnlineFlightTicketPassengers refObj)
        {
            if (objectToMap == null) return null;
            var onlineFlightTicketMapper = new OnlineFlightTicketMapper();
            var passengerMapper = new PassengerMapper();
            refObj.Id = objectToMap.Id;
            refObj.OnlineFlightTicketItem = onlineFlightTicketMapper.Map(objectToMap.OnlineFlightTicketItem);
            refObj.PassengersItem = passengerMapper.Map(objectToMap.PassengersItem);
            return refObj;
        }
    }
}
