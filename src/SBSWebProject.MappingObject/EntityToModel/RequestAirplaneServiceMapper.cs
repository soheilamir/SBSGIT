using System.Linq;
using RequestAirplaneService = SBSWebProject.Web.Api.Models.RequestAirplaneService;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class RequestAirplaneServiceMapper : IMappingObject<Data.Entities.RequestAirplaneService, RequestAirplaneService>
    {
        public RequestAirplaneService Map(Data.Entities.RequestAirplaneService objectToMap)
        {
            if (objectToMap == null) return null;
            var userMapper = new UsersMapper();
            var orderMapper = new OrdersMapper();
            var requestAirplaneTicketMapper = new RequestAirplaneTicketMapper();
            var requestStatusMapper = new RequestStatusMapper();
            var outputModel = new RequestAirplaneService
            {
                Id = objectToMap.Id,
                Description = objectToMap.Description,
                IsActiveRequest = objectToMap.IsActiveRequest,
                IsChanged = objectToMap.IsChanged,
                OrdersItem = orderMapper.Map(objectToMap.OrdersItem),
                SubmitDate = objectToMap.SubmitDate,
                UserItem = userMapper.Map(objectToMap.UserItem),
                RequestStatusItem = requestStatusMapper.Map(objectToMap.RequestStatusItem),
                //RequestAirplaneTicketS = objectToMap.RequestAirplaneTicketS.Where(c => c.State == 0).Select(item => requestAirplaneTicketMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
