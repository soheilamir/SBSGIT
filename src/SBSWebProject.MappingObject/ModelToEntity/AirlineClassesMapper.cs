using System.Linq;
using AirlineClass = SBSWebProject.Data.Entities.AirlineClasses;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class AirlineClassesMapper : IMappingObject<Web.Api.Models.AirlineClasses, AirlineClass>
    {
        public AirlineClass Map(Web.Api.Models.AirlineClasses objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineMapper=new AirlineMapper();
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
    }
}
