using System.Linq;
using AirlineClass = SBSWebProject.Data.Entities.AirlineClasses;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class AirlineClassesMapper : IMappingObject<Web.Api.Models.AirlineClasses, AirlineClass>
    {
        public AirlineClass Map(Web.Api.Models.AirlineClasses objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new AirlineClass
            {
                Id = objectToMap.Id,
                FlightClassName = objectToMap.FlightClassName,
                AirlineItem = airlineMapper.Map(objectToMap.AirlineItem),
                //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public AirlineClass Map(Web.Api.Models.AirlineClasses objectToMap, AirlineClass refObj)
        {
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            refObj.Id = objectToMap.Id;
            refObj.FlightClassName = objectToMap.FlightClassName;
            refObj.AirlineItem = airlineMapper.Map(objectToMap.AirlineItem);
            //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
