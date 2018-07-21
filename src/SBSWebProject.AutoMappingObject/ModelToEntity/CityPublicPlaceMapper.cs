using System.Linq;
using CityPublicPlace = SBSWebProject.Data.Entities.CityPublicPlace;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class CityPublicPlaceMapper : IMappingObject<Web.Api.Models.CityPublicPlace, CityPublicPlace>
    {

        public CityPublicPlace Map(Web.Api.Models.CityPublicPlace objectToMap)
        {
            if (objectToMap == null) return null;
            var cityMapper = new CityMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new CityPublicPlace
            {
                Id = objectToMap.Id,
                CityItem = cityMapper.Map(objectToMap.CityItem),
                //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public CityPublicPlace Map(Web.Api.Models.CityPublicPlace objectToMap, CityPublicPlace refObj)
        {
            if (objectToMap == null) return null;
            var cityMapper = new CityMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            refObj.Id = objectToMap.Id;
            refObj.CityItem = cityMapper.Map(objectToMap.CityItem);
            //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
