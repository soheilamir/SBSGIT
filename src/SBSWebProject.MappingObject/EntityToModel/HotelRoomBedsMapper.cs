using System.Linq;
using HotelRoomBeds = SBSWebProject.Web.Api.Models.HotelRoomBeds;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class HotelRoomBedsMapper : IMappingObject<Data.Entities.HotelRoomBeds, HotelRoomBeds>
    {
        public HotelRoomBeds Map(Data.Entities.HotelRoomBeds objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new HotelRoomBeds
            {
                Id = objectToMap.Id,
                BedHeight = objectToMap.BedHeight,
                BedName = objectToMap.BedName,
                BedWidth = objectToMap.BedWidth,
                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
