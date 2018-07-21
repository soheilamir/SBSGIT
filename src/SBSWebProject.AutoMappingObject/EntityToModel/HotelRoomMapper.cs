using System.Linq;
using HotelRoom = SBSWebProject.Web.Api.Models.HotelRoom;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class HotelRoomMapper : IMappingObject<Data.Entities.HotelRoom, HotelRoom>
    {
        public HotelRoom Map(Data.Entities.HotelRoom objectToMap)
        {
            if (objectToMap == null) return null;
            var hotelRoomTypeMapper = new HotelRoomTypeMapper();
            var hotelOrRoomConditionsMapper = new HotelOrRoomConditionsMapper();
            var hotelRoomCommentsMapper = new HotelRoomCommentsMapper();
            var hotelRoomNightPriceMapper = new HotelRoomNightPriceMapper();
            var outputModel = new HotelRoom
            {
                Id = objectToMap.Id,
                ChildAge = objectToMap.ChildAge,
                ChildNum = objectToMap.ChildNum,
                Dimension = objectToMap.Dimension,
                HasBreakfast = objectToMap.HasBreakfast,
                HasDinner = objectToMap.HasDinner,
                HasLunch = objectToMap.HasLunch,
                MaxAdults = objectToMap.MaxAdults,
                MaxChildren = objectToMap.MaxChildren,
                MaxGuests = objectToMap.MaxGuests,
                RoomCount = objectToMap.RoomCount,
                HotelRoomTypeItem = hotelRoomTypeMapper.Map(objectToMap.HotelRoomTypeItem),
                HotelOrRoomConditionsS = (objectToMap.HotelOrRoomConditionsS != null) ? objectToMap.HotelOrRoomConditionsS.Where(c => c.State == 0).Select(item => hotelOrRoomConditionsMapper.Map(item)).ToList() : null,
                HotelRoomCommentsS = (objectToMap.HotelRoomCommentsS != null) ? objectToMap.HotelRoomCommentsS.Where(c => c.State == 0).Select(item => hotelRoomCommentsMapper.Map(item)).ToList() : null,
                HotelRoomNightPriceS = (objectToMap.HotelRoomNightPriceS != null) ? objectToMap.HotelRoomNightPriceS.Where(c => c.State == 0).Select(item => hotelRoomNightPriceMapper.Map(item)).ToList() : null,
                ActiveNightPriceItem = (objectToMap.HotelRoomNightPriceS != null) ? hotelRoomNightPriceMapper.Map(objectToMap.HotelRoomNightPriceS.Where(c => c.State == 0 && c.IsActive == true).ToList()[0]) : null,
                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
