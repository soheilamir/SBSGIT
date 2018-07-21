using System.Linq;
using Airport = SBSWebProject.Data.Entities.Airports;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
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
        public Airport Map(Web.Api.Models.Airports objectToMap, Airport refObj)
        {
            if (objectToMap == null) return null;
            var airportNameByLanguageMapping = new AirportNameByLanguageMapper();
            var cityMapping = new CityMapper();
            refObj.Id = objectToMap.Id;
            refObj.Address = objectToMap.Address;
            //AirportNamebyLanguageS = objectToMap.AirportNamebyLanguageS.Select(item => airportNameByLanguageMapping.Map(item)).ToList(),
            refObj.CityItem = cityMapping.Map(objectToMap.CityItem);
            return refObj;
        }
    }
}
