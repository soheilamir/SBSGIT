using System.Linq;
using AirlineClass = SBSWebProject.Web.Api.Models.AirlineClasses;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class AirlineClassesMapper : IMappingObject<Data.Entities.AirlineClasses, AirlineClass>
    {
        public AirlineClass Map(Data.Entities.AirlineClasses objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new AirlineClass
            {
                Id = objectToMap.Id,
                FlightClassName = objectToMap.FlightClassName,
                AirlineItem = airlineMapper.Map(objectToMap.AirlineItem),
                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
