using System.Linq;
using FlightPath = SBSWebProject.Web.Api.Models.FlightPath;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class FlightPathMapper : IMappingObject<Data.Entities.FlightPath, FlightPath>
    {
        public FlightPath Map(Data.Entities.FlightPath objectToMap)
        {
            if (objectToMap == null) return null;
            var cityMapper = new CityMapper();
            var airlineClassPathMapper = new AirlineClassPathMapper();
            var outputModel = new FlightPath
            {
                Id = objectToMap.Id,
                DestinationCityItem = cityMapper.Map(objectToMap.DestinationCityItem),
                SourceCityItem= cityMapper.Map(objectToMap.SourceCityItem),
                //AirlineClassPathS= objectToMap.AirlineClassPathS.Where(c => c.State == 0).Select(item => airlineClassPathMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
