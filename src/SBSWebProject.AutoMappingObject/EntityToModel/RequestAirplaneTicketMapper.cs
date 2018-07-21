using System.Linq;
using RequestAirplaneTicket = SBSWebProject.Web.Api.Models.RequestAirplaneTicket;
using ComboBoxType = SBSWebProject.Web.Api.Models.ComboBox;
using System;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class RequestAirplaneTicketMapper : IMappingObject<Data.Entities.RequestAirplaneTicket, RequestAirplaneTicket>
    {
        public RequestAirplaneTicket Map(Data.Entities.RequestAirplaneTicket objectToMap)
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
                from = cityMapper.Map(objectToMap.SourceCityItem),
                to = cityMapper.Map(objectToMap.DestinationCityItem),
                departingDate = dc.ConvertGer2Jalai((DateTime)objectToMap.DepartureDate),
                selectedFlexibleDate = objectToMap.IsDateFlexible,
                cabinClass = new ComboBoxType { id = (int)objectToMap.TicketClass },
                ticketType = new ComboBoxType { id = (int)objectToMap.TicketType },
                journeyType = new ComboBoxType { id = (int)objectToMap.JourneyType },
                PreferredTime = new ComboBoxType { id = (int)objectToMap.PreferredTime },
                RequestAirplaneServiceItem = requestAirplaneServiceMapper.Map(objectToMap.RequestAirplaneServiceItem),
                returningDate = dc.ConvertGer2Jalai((DateTime)objectToMap.ReturningDate),
                // PlaneTicketStatusId = objectToMap.PlaneTicketStatusId,
                AdminUserId = objectToMap.AdminUserId,//TODO
                //RequestAirplaneTicketPassengerS = objectToMap.RequestAirplaneTicketPassengerS.Where(c => c.State == 0).Select(item => requestAirplaneTicketPassengerMapper.Map(item)).ToList(),
                flightRecomend = objectToMap.ResponseAirplaneTicketS.Where(c => c.State == 0).Select(item => responseAirplaneTicketMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
