using System.Linq;
using OnlineFlightTicket = SBSWebProject.Data.Entities.OnlineFlightTicket;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class OnlineFlightTicketMapper : IMappingObject<Web.Api.Models.OnlineFlightTicket, OnlineFlightTicket>
    {
        public OnlineFlightTicket Map(Web.Api.Models.OnlineFlightTicket objectToMap)
        {
            if (objectToMap == null) return null;
            var onlineFlightTicketMapper = new OnlineFlightTicketMapper();
            var airlineClassPathMapper = new AirlineClassPathMapper();
            var servicesMapper = new ServicesMapper();
            var onlineFlightTicketPassengersMapper = new OnlineFlightTicketPassengersMapper();
            var ordersMapper = new OrdersMapper();


            var outputModel = new OnlineFlightTicket
            {
                Id = objectToMap.Id,
                OrdersItem = ordersMapper.Map(objectToMap.OrdersItem),
                PNR = objectToMap.PNR,
                ServicesItem = servicesMapper.Map(objectToMap.ServicesItem),
                //OnlineFlightTicketPassengersS = objectToMap.OnlineFlightTicketPassengersS.Where(c => c.State == 0).Select(item => onlineFlightTicketPassengersMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
