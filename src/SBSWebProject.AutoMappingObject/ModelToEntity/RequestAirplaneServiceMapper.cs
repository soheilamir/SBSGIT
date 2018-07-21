using System.Linq;
using RequestAirplaneService = SBSWebProject.Data.Entities.RequestAirplaneService;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class RequestAirplaneServiceMapper : IMappingObject<Web.Api.Models.RequestAirplaneService, RequestAirplaneService>
    {
        public RequestAirplaneService Map(Web.Api.Models.RequestAirplaneService objectToMap)
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
                //RequestAirplaneTicketS = objectToMap.lstFlight.Select(item => requestAirplaneTicketMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public RequestAirplaneService Map(Web.Api.Models.RequestAirplaneService objectToMap, RequestAirplaneService refObj)
        {
            if (objectToMap == null) return null;
            var userMapper = new UsersMapper();
            var orderMapper = new OrdersMapper();
            var requestAirplaneTicketMapper = new RequestAirplaneTicketMapper();
            var requestStatusMapper = new RequestStatusMapper();
            refObj.Id = objectToMap.Id;
            refObj.Description = objectToMap.Description;
            refObj.IsActiveRequest = objectToMap.IsActiveRequest;
            refObj.IsChanged = objectToMap.IsChanged;
            refObj.OrdersItem = orderMapper.Map(objectToMap.OrdersItem);
            refObj.SubmitDate = objectToMap.SubmitDate;
            refObj.UserItem = userMapper.Map(objectToMap.UserItem);
            refObj.RequestStatusItem = requestStatusMapper.Map(objectToMap.RequestStatusItem);
            //RequestAirplaneTicketS = objectToMap.lstFlight.Select(item => requestAirplaneTicketMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
