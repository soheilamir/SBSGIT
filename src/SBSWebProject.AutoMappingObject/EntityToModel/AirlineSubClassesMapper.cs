using System.Linq;
using AirlineSubClasses = SBSWebProject.Web.Api.Models.AirlineSubClasses;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class AirlineSubClassesMapper : IMappingObject<Data.Entities.AirlineSubClasses, AirlineSubClasses>
    {
        public AirlineSubClasses Map(Data.Entities.AirlineSubClasses objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineClassesMapper = new AirlineClassesMapper();
            var flightNumbersMapper = new FlightNumbersMapper();
            var outputModel = new AirlineSubClasses
            {
                Id = objectToMap.Id,
                AirlineSubClassName = objectToMap.AirlineSubClassName,
                AirlineClassesItem = airlineClassesMapper.Map(objectToMap.AirlineClassesItem),
                //FlightNumberS = (objectToMap.FlightNumberS != null) ? objectToMap.FlightNumberS.Where(c => c.State == 0).Select(item => flightNumbersMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
