using System.Linq;
using HotelRoomBeds = SBSWebProject.Data.Entities.HotelRoomBeds;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class HotelRoomBedsMapper : IMappingObject<Web.Api.Models.HotelRoomBeds, HotelRoomBeds>
    {
        public HotelRoomBeds Map(Web.Api.Models.HotelRoomBeds objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new HotelRoomBeds
            {
                Id = objectToMap.Id,
                BedHeight = objectToMap.BedHeight,
                BedWidth = objectToMap.BedWidth,
                BedName = objectToMap.BedName,
                //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
