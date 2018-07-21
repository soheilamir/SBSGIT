using System.Linq;
using CityPublicPlace = SBSWebProject.Web.Api.Models.CityPublicPlace;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class CityPublicPlaceMapper : IMappingObject<Data.Entities.CityPublicPlace, CityPublicPlace>
    {
        public CityPublicPlace Map(Data.Entities.CityPublicPlace objectToMap)
        {
            if (objectToMap == null) return null;
            var cityMapper = new CityMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new CityPublicPlace
            {
                Id = objectToMap.Id,
                CityItem = cityMapper.Map(objectToMap.CityItem),
                
                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
