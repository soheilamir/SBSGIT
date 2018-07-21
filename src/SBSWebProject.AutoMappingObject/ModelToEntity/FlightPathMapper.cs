using System.Linq;
using FlightPath = SBSWebProject.Data.Entities.FlightPath;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class FlightPathMapper : IMappingObject<Web.Api.Models.FlightPath, FlightPath>
    {
        public FlightPath Map(Web.Api.Models.FlightPath objectToMap)
        {
            if (objectToMap == null) return null;
            var cityMapper = new CityMapper();
            var airlineClassPathMapper = new AirlineClassPathMapper();
            var outputModel = new FlightPath
            {
                Id = objectToMap.Id,
                DestinationCityItem = cityMapper.Map(objectToMap.DestinationCityItem),
                SourceCityItem = cityMapper.Map(objectToMap.SourceCityItem),
                //AirlineClassPathS = objectToMap.AirlineClassPathS.Select(item => airlineClassPathMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public FlightPath Map(Web.Api.Models.FlightPath objectToMap, FlightPath refObj)
        {
            if (objectToMap == null) return null;
            var cityMapper = new CityMapper();
            var airlineClassPathMapper = new AirlineClassPathMapper();
            refObj.Id = objectToMap.Id;
            refObj.DestinationCityItem = cityMapper.Map(objectToMap.DestinationCityItem);
            refObj.SourceCityItem = cityMapper.Map(objectToMap.SourceCityItem);
            //AirlineClassPathS = objectToMap.AirlineClassPathS.Select(item => airlineClassPathMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
