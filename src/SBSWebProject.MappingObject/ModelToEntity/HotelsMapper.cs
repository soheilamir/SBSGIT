using System.Linq;
using Hotels = SBSWebProject.Data.Entities.Hotels;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class HotelsMapper : IMappingObject<Web.Api.Models.Hotels, Hotels>
    {
        public Hotels Map(Web.Api.Models.Hotels objectToMap)
        {
            if (objectToMap == null) return null;
            var cityMapper = new CityMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new Hotels
            {
                Id = objectToMap.Id,
                Address = objectToMap.Address,
                CityItem = cityMapper.Map(objectToMap.CityItem),
                Description = objectToMap.Description,
                Rate = objectToMap.Rate,
                Stars = objectToMap.Stars,
                //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
