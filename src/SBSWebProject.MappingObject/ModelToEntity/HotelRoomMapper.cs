using System.Linq;
using HotelRoom = SBSWebProject.Data.Entities.HotelRoom;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class HotelRoomMapper : IMappingObject<Web.Api.Models.HotelRoom, HotelRoom>
    {
        public HotelRoom Map(Web.Api.Models.HotelRoom objectToMap)
        {
            if (objectToMap == null) return null;
            var hotelsMapper = new HotelsMapper();
            var hotelRoomTypeMapper = new HotelRoomTypeMapper();
            var outputModel = new HotelRoom
            {
                Id = objectToMap.Id,
                ChildAge = objectToMap.ChildAge,
                ChildNum = objectToMap.ChildNum,
                Dimension = objectToMap.Dimension,
                HasBreakfast = objectToMap.HasBreakfast,
                HasDinner = objectToMap.HasDinner,
                HasLunch = objectToMap.HasLunch,
                HotelItem = hotelsMapper.Map(objectToMap.HotelItem),
                HotelRoomTypeItem = hotelRoomTypeMapper.Map(objectToMap.HotelRoomTypeItem),
                MaxAdults = objectToMap.MaxAdults,
                MaxChildren = objectToMap.MaxChildren,
                MaxGuests = objectToMap.MaxGuests,
                RoomCount = objectToMap.RoomCount,
                //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
