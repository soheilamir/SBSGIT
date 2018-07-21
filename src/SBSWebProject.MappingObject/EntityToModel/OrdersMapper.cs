using System.Linq;
using Orders = SBSWebProject.Web.Api.Models.Orders;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class OrdersMapper : IMappingObject<Data.Entities.Orders, Orders>
    {
        public Orders Map(Data.Entities.Orders objectToMap)
        {
            if (objectToMap == null) return null;
            var userMapper = new UsersMapper();
            var companyMapper = new CompanyMapper();
            var companyAttachmentMapper = new CompanyAttachmentMapper();
            var onlineFlightTicketMapper = new OnlineFlightTicketMapper();
            var requestAirplaneServiceMapper = new RequestAirplaneServiceMapper();
            var outputModel = new Orders
            {
                id = objectToMap.Id,
                //UsersItem = userMapper.Map(objectToMap.UsersItem),
                //CompanyItem = companyMapper.Map(objectToMap.CompanyItem),
                CompletionDateTime = objectToMap.CompletionDateTime,
                //IsHealthSave = objectToMap.IsHealthSave,
                //OrderStatusItem = objectToMap.OrderStatusItem,
                SubmitDateTime = objectToMap.SubmitDateTime,
                //CompanyAttachmentS = objectToMap.CompanyAttachmentS.Where(c => c.State == 0).Select(item => companyAttachmentMapper.Map(item)).ToList(),
                //OnlineFlightTicketS = objectToMap.OnlineFlightTicketS.Where(c => c.State == 0).Select(item => onlineFlightTicketMapper.Map(item)).ToList(),
                //RequestAirplaneServiceS = objectToMap.RequestAirplaneServiceS.Where(c => c.State == 0).Select(item => requestAirplaneServiceMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
