using System.Linq;
using Orders = SBSWebProject.Data.Entities.Orders;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class OrdersMapper : IMappingObject<Web.Api.Models.Orders, Orders>
    {
        public Orders Map(Web.Api.Models.Orders objectToMap)
        {
            if (objectToMap == null) return null;
            var userMapper = new UsersMapper();
            var companyMapper = new CompanyMapper();
            var companyAttachmentMapper = new CompanyAttachmentMapper();
            var onlineFlightTicketMapper = new OnlineFlightTicketMapper();
            var requestAirplaneServiceMapper = new RequestAirplaneServiceMapper();
            var outputModel = new Orders
            {
                Id = objectToMap.id,
                UsersItem = userMapper.Map(objectToMap.UsersItem),
                CompanyItem = companyMapper.Map(objectToMap.CompanyItem),
                CompletionDateTime = objectToMap.CompletionDateTime,
                //IsHealthSave = objectToMap.IsHealthSave,
                //OrderStatusItem = objectToMap.OrderStatusItem,
                SubmitDateTime = objectToMap.SubmitDateTime,
                //CompanyAttachmentS = objectToMap.CompanyAttachmentS.Select(item => companyAttachmentMapper.Map(item)).ToList(),
                //OnlineFlightTicketS = objectToMap.OnlineFlightTicketS.Select(item => onlineFlightTicketMapper.Map(item)).ToList(),
                //RequestAirplaneServiceS = objectToMap.RequestAirplaneServiceS.Select(item => requestAirplaneServiceMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
