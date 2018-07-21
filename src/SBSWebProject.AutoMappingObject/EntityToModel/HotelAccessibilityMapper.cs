using System.Linq;
using HotelAccessibility = SBSWebProject.Web.Api.Models.HotelAccessibility;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class HotelAccessibilityMapper : IMappingObject<Data.Entities.HotelAccessibility, HotelAccessibility>
    {
        public HotelAccessibility Map(Data.Entities.HotelAccessibility objectToMap)
        {
            if (objectToMap == null) return null;
            var cityPublicPlaceMapper = new CityPublicPlaceMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new HotelAccessibility
            {
                Id = objectToMap.Id,
                CityPublicPlaceItem = cityPublicPlaceMapper.Map(objectToMap.CityPublicPlaceItem),
                Distance = objectToMap.Distance,
                TimeWithCar = objectToMap.TimeWithCar,
                TimeWithWalk = objectToMap.TimeWithWalk,
                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
