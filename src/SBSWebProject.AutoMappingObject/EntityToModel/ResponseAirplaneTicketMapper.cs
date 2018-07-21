using System.Linq;
using ResponseAirplaneTicket = SBSWebProject.Web.Api.Models.ResponseAirplaneTicket;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class ResponseAirplaneTicketMapper : IMappingObject<Data.Entities.ResponseAirplaneTicket, ResponseAirplaneTicket>
    {
        public ResponseAirplaneTicket Map(Data.Entities.ResponseAirplaneTicket objectToMap)
        {
            if (objectToMap == null) return null;
            var requestAirplaneTicketMapper = new RequestAirplaneTicketMapper();
            var flightNumbersMapper = new FlightNumbersMapper();
            var ticketNumberMapper = new TicketNumberMapper();
            var outputModel = new ResponseAirplaneTicket
            {
                Id = objectToMap.Id,
                RequestAirplaneTicketItem = requestAirplaneTicketMapper.Map(objectToMap.RequestAirplaneTicketItem),
                AdultPrice = objectToMap.AdultPrice,
                Availability = objectToMap.Availability,
                ChildPrice = objectToMap.ChildPrice,
                //FlightNumbersItem = flightNumbersMapper.Map(objectToMap.FlightNumbersItem),
                InfantPrice = objectToMap.InfantPrice,
                IsReturning = objectToMap.IsReturning,
                IsSelect = objectToMap.IsSelect,
                SbsRecommend = objectToMap.SbsRecommend,
                TicketDate = objectToMap.TicketDate,
                TicketTime = objectToMap.TicketTime,
                //TicketNumberS = objectToMap.TicketNumberS.Where(c => c.State == 0).Select(item => ticketNumberMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
