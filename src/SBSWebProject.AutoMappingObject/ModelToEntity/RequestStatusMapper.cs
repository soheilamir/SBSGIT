using System.Linq;
using RequestStatus = SBSWebProject.Data.Entities.RequestStatus;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class RequestStatusMapper : IMappingObject<Web.Api.Models.RequestStatus, RequestStatus>
    {
        public RequestStatus Map(Web.Api.Models.RequestStatus objectToMap)
        {
            if (objectToMap == null) return null;
            var requestAirplaneServiceMapper = new RequestAirplaneServiceMapper();
            var cityMapper = new CityMapper();
            var outputModel = new RequestStatus
            {
                Id = objectToMap.Id,
                Name = objectToMap.Name,
                RequestAirplaneServiceS = objectToMap.RequestAirplaneServiceS.Select(item => requestAirplaneServiceMapper.Map(item)).ToList(),
                Code = objectToMap.Code
            };
            return outputModel;
        }
        public RequestStatus Map(Web.Api.Models.RequestStatus objectToMap, RequestStatus refObj)
        {
            if (objectToMap == null) return null;
            var requestAirplaneServiceMapper = new RequestAirplaneServiceMapper();
            var cityMapper = new CityMapper();
            refObj.Id = objectToMap.Id;
            refObj.Name = objectToMap.Name;
            refObj.RequestAirplaneServiceS = objectToMap.RequestAirplaneServiceS.Select(item => requestAirplaneServiceMapper.Map(item)).ToList();
            refObj.Code = objectToMap.Code;
            return refObj;
        }
    }
}
