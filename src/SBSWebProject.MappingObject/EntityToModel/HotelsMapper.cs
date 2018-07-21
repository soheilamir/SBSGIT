using System.Linq;
using Hotels = SBSWebProject.Web.Api.Models.Hotels;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class HotelsMapper : IMappingObject<Data.Entities.Hotels, Hotels>
    {
        public Hotels Map(Data.Entities.Hotels objectToMap)
        {
            if (objectToMap == null) return null;
            var cityMapper = new CityMapper();
            var hotelAccessibilityMapper = new HotelAccessibilityMapper();
            var hotelCommentsMapper = new HotelCommentsMapper();
            var hotelFacilitiesMapper = new HotelFacilitiesMapper();
            var hotelNameByLanguageMapper = new HotelNameByLanguageMapper();
            var hotelOrRoomConditionsMapper = new HotelOrRoomConditionsMapper();
            var hotelPhotosMapper = new HotelPhotosMapper();
            var hotelRoomMapper = new HotelRoomMapper();
            var outputModel = new Hotels
            {
                Id = objectToMap.Id,
                Address = objectToMap.Address,
                CityItem = cityMapper.Map(objectToMap.CityItem),
                Description = objectToMap.Description,
                FreeWifi = objectToMap.FreeWifi,
                HotelAccessibilityS = (objectToMap.HotelAccessibilityS != null) ? objectToMap.HotelAccessibilityS.Where(c => c.State == 0).Select(item => hotelAccessibilityMapper.Map(item)).ToList() : null,
                HotelCommentsS = (objectToMap.HotelCommentsS != null) ? objectToMap.HotelCommentsS.Where(c => c.State == 0).Select(item => hotelCommentsMapper.Map(item)).ToList() : null,
                HotelFacilitiesS = (objectToMap.HotelFacilitiesS != null) ? objectToMap.HotelFacilitiesS.Where(c => c.State == 0).Select(item => hotelFacilitiesMapper.Map(item)).ToList() : null,
                HotelNameByLanguageS = (objectToMap.HotelNameByLanguageS != null) ? objectToMap.HotelNameByLanguageS.Where(c => c.State == 0).Select(item => hotelNameByLanguageMapper.Map(item)).ToList() : null,
                HotelOrRoomConditionsS = (objectToMap.HotelOrRoomConditionsS != null) ? objectToMap.HotelOrRoomConditionsS.Where(c => c.State == 0).Select(item => hotelOrRoomConditionsMapper.Map(item)).ToList() : null,
                HotelPhotosS = (objectToMap.HotelPhotosS != null) ? objectToMap.HotelPhotosS.Where(c => c.State == 0).Select(item => hotelPhotosMapper.Map(item)).ToList() : null,
                HotelRoomS = (objectToMap.HotelRoomS != null) ? objectToMap.HotelRoomS.Where(c => c.State == 0).Select(item => hotelRoomMapper.Map(item)).ToList() : null,
                Rate = objectToMap.Rate,
                Stars = objectToMap.Stars,
                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
