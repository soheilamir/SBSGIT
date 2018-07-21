using System.Linq;
using HotelRoomType = SBSWebProject.Web.Api.Models.HotelRoomType;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class HotelRoomTypeMapper : IMappingObject<Data.Entities.HotelRoomType, HotelRoomType>
    {
        public HotelRoomType Map(Data.Entities.HotelRoomType objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new HotelRoomType
            {
                Id = objectToMap.Id,
                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
