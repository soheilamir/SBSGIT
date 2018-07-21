using System.Linq;
using HotelRoom = SBSWebProject.Data.Entities.HotelRoom;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
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
        public HotelRoom Map(Web.Api.Models.HotelRoom objectToMap, HotelRoom refObj)
        {
            if (objectToMap == null) return null;
            var hotelsMapper = new HotelsMapper();
            var hotelRoomTypeMapper = new HotelRoomTypeMapper();
            refObj.Id = objectToMap.Id;
            refObj.ChildAge = objectToMap.ChildAge;
            refObj.ChildNum = objectToMap.ChildNum;
            refObj.Dimension = objectToMap.Dimension;
            refObj.HasBreakfast = objectToMap.HasBreakfast;
            refObj.HasDinner = objectToMap.HasDinner;
            refObj.HasLunch = objectToMap.HasLunch;
            refObj.HotelItem = hotelsMapper.Map(objectToMap.HotelItem);
            refObj.HotelRoomTypeItem = hotelRoomTypeMapper.Map(objectToMap.HotelRoomTypeItem);
            refObj.MaxAdults = objectToMap.MaxAdults;
            refObj.MaxChildren = objectToMap.MaxChildren;
            refObj.MaxGuests = objectToMap.MaxGuests;
            refObj.RoomCount = objectToMap.RoomCount;
            //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
