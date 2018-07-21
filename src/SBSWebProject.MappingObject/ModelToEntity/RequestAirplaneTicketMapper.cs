using System;
using System.Linq;
using RequestAirplaneTicket = SBSWebProject.Data.Entities.RequestAirplaneTicket;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class RequestAirplaneTicketMapper : IMappingObject<Web.Api.Models.RequestAirplaneTicket, RequestAirplaneTicket>
    {
        public RequestAirplaneTicket Map(Web.Api.Models.RequestAirplaneTicket objectToMap)
        {
            if (objectToMap == null) return null;
            var requestAirplaneServiceMapper = new RequestAirplaneServiceMapper();
            var cityMapper = new CityMapper();
            var requestAirplaneTicketPassengerMapper = new RequestAirplaneTicketPassengerMapper();
            var responseAirplaneTicketMapper = new ResponseAirplaneTicketMapper();
            DateController dc = new DateController();
            var outputModel = new RequestAirplaneTicket
            {
                Id = objectToMap.Id,
                SourceCityItem = cityMapper.Map(objectToMap.from),
                DestinationCityItem = cityMapper.Map(objectToMap.to),
                DepartureDate = dc.ConvertJalai2Ger(objectToMap.departingDate),
                IsDateFlexible = objectToMap.selectedFlexibleDate,
                TicketClass = objectToMap.cabinClass.id,
                TicketType = objectToMap.ticketType.id,
                JourneyType = objectToMap.journeyType.id,
                PreferredTime = objectToMap.PreferredTime.id,
                RequestAirplaneServiceItem = requestAirplaneServiceMapper.Map(objectToMap.RequestAirplaneServiceItem),
                ReturningDate = dc.ConvertJalai2Ger(objectToMap.returningDate),
                //PlaneTicketStatusId = objectToMap.PlaneTicketStatusId,
                AdminUserId = objectToMap.AdminUserId,//TODO
                //RequestAirplaneTicketPassengerS = objectToMap.RequestAirplaneTicketPassengerS.Select(item => requestAirplaneTicketPassengerMapper.Map(item)).ToList(),
                //ResponseAirplaneTicketS = objectToMap.flightRecomend.Select(item => responseAirplaneTicketMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
