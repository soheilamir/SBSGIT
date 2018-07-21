using System.Linq;
using HotelOrRoomConditions = SBSWebProject.Data.Entities.HotelOrRoomConditions;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class HotelOrRoomConditionsMapper : IMappingObject<Web.Api.Models.HotelOrRoomConditions, HotelOrRoomConditions>
    {
        public HotelOrRoomConditions Map(Web.Api.Models.HotelOrRoomConditions objectToMap)
        {
            if (objectToMap == null) return null;
            var hotelsMapper = new HotelsMapper();
            var hotelRoomMapper = new HotelRoomMapper();
            var outputModel = new HotelOrRoomConditions
            {
                Id = objectToMap.Id,
                Condition = objectToMap.Condition,
                HotelItem = hotelsMapper.Map(objectToMap.HotelItem),
                HotelroomItem = hotelRoomMapper.Map(objectToMap.HotelroomItem),
                //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}