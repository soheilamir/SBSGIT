using FlightFreeServices = SBSWebProject.Data.Entities.FlightFreeServices;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class FlightFreeServiceMapper : IMappingObject<Web.Api.Models.FlightFreeServices, FlightFreeServices>
    {
        public FlightFreeServices Map(Web.Api.Models.FlightFreeServices objectToMap)
        {
            if (objectToMap == null) return null;
            var flightNumbersMapper=new FlightNumbersMapper();
            var outputModel = new FlightFreeServices
            {
                Id = objectToMap.Id,
                ServiceDescription = objectToMap.ServiceDescription,
                ServiceName = objectToMap.ServiceName,
                FlightNumberItem = flightNumbersMapper.Map(objectToMap.FlightNumberItem)
            };
            return outputModel;
        }
        public FlightFreeServices Map(Web.Api.Models.FlightFreeServices objectToMap, FlightFreeServices refObj)
        {
            if (objectToMap == null) return null;
            var flightNumbersMapper = new FlightNumbersMapper();
            refObj.Id = objectToMap.Id;
            refObj.ServiceDescription = objectToMap.ServiceDescription;
            refObj.ServiceName = objectToMap.ServiceName;
            refObj.FlightNumberItem = flightNumbersMapper.Map(objectToMap.FlightNumberItem);
            return refObj;
        }
    }
}
