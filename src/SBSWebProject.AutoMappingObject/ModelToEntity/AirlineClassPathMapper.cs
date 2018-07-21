using System.Linq;
using AirlineClassPath = SBSWebProject.Data.Entities.AirlineClassPath;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class AirlineClassPathMapper : IMappingObject<Web.Api.Models.AirlineClassPath, AirlineClassPath>
    {
        public AirlineClassPath Map(Web.Api.Models.AirlineClassPath objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var flightConditionMapper = new FlightConditionMapper();
            var flightNumbersMapper = new FlightNumbersMapper();
            var flightPathMapper = new FlightPathMapper();
            var outputModel = new AirlineClassPath
            {
                Id = objectToMap.Id,
                AirlineSubClassesItem = airlineSubClassesMapper.Map(objectToMap.AirlineSubClassesItem),
                IsActive = objectToMap.IsActive,
                //FlightConditionS = objectToMap.FlightConditionS.Select(item => flightConditionMapper.Map(item)).ToList(),
                //FlightNumbersS = objectToMap.FlightNumbersS.Select(item => flightNumbersMapper.Map(item)).ToList(),
                FlightPathItem = flightPathMapper.Map(objectToMap.FlightPathItem)
            };
            return outputModel;
        }
        public AirlineClassPath Map(Web.Api.Models.AirlineClassPath objectToMap, AirlineClassPath refObj)
        {
            if (objectToMap == null) return null;
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var flightConditionMapper = new FlightConditionMapper();
            var flightNumbersMapper = new FlightNumbersMapper();
            var flightPathMapper = new FlightPathMapper();
            refObj.Id = objectToMap.Id;
            refObj.AirlineSubClassesItem = airlineSubClassesMapper.Map(objectToMap.AirlineSubClassesItem);
            refObj.IsActive = objectToMap.IsActive;
            //FlightConditionS = objectToMap.FlightConditionS.Select(item => flightConditionMapper.Map(item)).ToList(),
            //FlightNumbersS = objectToMap.FlightNumbersS.Select(item => flightNumbersMapper.Map(item)).ToList(),
            refObj.FlightPathItem = flightPathMapper.Map(objectToMap.FlightPathItem);
            return refObj;
        }
    }
}
