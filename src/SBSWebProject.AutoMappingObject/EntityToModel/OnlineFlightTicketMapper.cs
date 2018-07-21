using System.Linq;
using OnlineFlightTicket = SBSWebProject.Web.Api.Models.OnlineFlightTicket;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class OnlineFlightTicketMapper : IMappingObject<Data.Entities.OnlineFlightTicket, OnlineFlightTicket>
    {

        public OnlineFlightTicket Map(Data.Entities.OnlineFlightTicket objectToMap)
        {
            if (objectToMap == null) return null;
            var onlineFlightTicketMapper = new OnlineFlightTicketMapper();
            var onlineFlightTicketPathMapper = new OnlineFlightTicketPathMapper();
            var servicesMapper = new ServicesMapper();
            var onlineFlightTicketPassengersMapper = new OnlineFlightTicketPassengersMapper();
            var ordersMapper = new OrdersMapper();


            var outputModel = new OnlineFlightTicket
            {
                Id = objectToMap.Id,
                OrdersItem = ordersMapper.Map(objectToMap.OrdersItem),
                PNR = objectToMap.PNR,
                ServicesItem = servicesMapper.Map(objectToMap.ServicesItem),
                //OnlineFlightTicketPassengersS = objectToMap.OnlineFlightTicketPassengersS.Where(c => c.State == 0).Select(item => onlineFlightTicketPassengersMapper.Map(item)).ToList(),
                //OnlineFlightTicketPathS= objectToMap.OnlineFlightTicketPathS.Where(c => c.State == 0).Select(item => onlineFlightTicketPathMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
