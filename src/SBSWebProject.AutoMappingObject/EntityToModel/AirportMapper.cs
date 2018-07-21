using System.Linq;
using Airport = SBSWebProject.Web.Api.Models.Airports;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class AirportMapper : IMappingObject<Data.Entities.Airports, Airport>
    {
        public Airport Map(Data.Entities.Airports objectToMap)
        {
            if (objectToMap == null) return null;
            var airportNameByLanguageMapping = new AirportNameByLanguageMapper();
            var cityMapping = new CityMapper();
            var outputModel = new Airport
            {
                Id = objectToMap.Id,
                Address = objectToMap.Address,
                //AirportNamebyLanguageS = (objectToMap.AirportNamebyLanguageS != null) ? objectToMap.AirportNamebyLanguageS.Where(c => c.State == 0).Select(item => airportNameByLanguageMapping.Map(item)).ToList() : null,
                CityItem = cityMapping.Map(objectToMap.CityItem)
            };
            return outputModel;
        }
    }
}
