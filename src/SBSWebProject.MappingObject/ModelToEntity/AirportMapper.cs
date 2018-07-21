using System.Linq;
using Airport = SBSWebProject.Data.Entities.Airports;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class AirportMapper : IMappingObject<Web.Api.Models.Airports, Airport>
    {
        public Airport Map(Web.Api.Models.Airports objectToMap)
        {
            if (objectToMap == null) return null;
            var airportNameByLanguageMapping = new AirportNameByLanguageMapper();
            var cityMapping = new CityMapper();
            var outputModel = new Airport
            {
                Id = objectToMap.Id,
                Address = objectToMap.Address,
                //AirportNamebyLanguageS = objectToMap.AirportNamebyLanguageS.Select(item => airportNameByLanguageMapping.Map(item)).ToList(),
                CityItem = cityMapping.Map(objectToMap.CityItem)
            };
            return outputModel;
        }
    }
}
