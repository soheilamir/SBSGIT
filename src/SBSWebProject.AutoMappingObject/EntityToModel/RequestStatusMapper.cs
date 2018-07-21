using System.Linq;
using RequestStatus = SBSWebProject.Web.Api.Models.RequestStatus;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class RequestStatusMapper : IMappingObject<Data.Entities.RequestStatus, RequestStatus>
    {
        public RequestStatus Map(Data.Entities.RequestStatus objectToMap)
        {
            if (objectToMap == null) return null;
            var requestAirplaneServiceMapper = new RequestAirplaneServiceMapper();
            var cityMapper = new CityMapper();
            var outputModel = new RequestStatus
            {
                Id = objectToMap.Id,
                Name = objectToMap.Name,
                //RequestAirplaneServiceS = objectToMap.RequestAirplaneServiceS.Where(c => c.State == 0).Select(item => requestAirplaneServiceMapper.Map(item)).ToList(),
                Code = objectToMap.Code
            };
            return outputModel;
        }
    }
}
