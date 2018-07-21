using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using OnlineFlightTicketPassengers = SBSWebProject.Web.Api.Models.OnlineFlightTicketPassengers;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class OnlineFlightTicketPassengersMapper : IMappingObject<Data.Entities.OnlineFlightTicketPassengers, OnlineFlightTicketPassengers>
    {
        public OnlineFlightTicketPassengers Map(Data.Entities.OnlineFlightTicketPassengers objectToMap)
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
    }
}
