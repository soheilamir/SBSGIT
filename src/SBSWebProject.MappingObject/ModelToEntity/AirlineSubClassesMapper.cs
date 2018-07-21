using System.Linq;
using AirlineSubClasses = SBSWebProject.Data.Entities.AirlineSubClasses;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class AirlineSubClassesMapper : IMappingObject<Web.Api.Models.AirlineSubClasses, AirlineSubClasses>
    {
        public AirlineSubClasses Map(Web.Api.Models.AirlineSubClasses objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineClassesMapper = new AirlineClassesMapper();
            var flightNumbersMapper = new FlightNumbersMapper();
            var outputModel = new AirlineSubClasses
            {
                Id = objectToMap.Id,
                AirlineSubClassName = objectToMap.AirlineSubClassName,
                AirlineClassesItem = airlineClassesMapper.Map(objectToMap.AirlineClassesItem),
                //FlightNumbersS = objectToMap.FlightNumberS.Select(item => flightNumbersMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
