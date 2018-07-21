using System.Linq;
using HotelRoomType = SBSWebProject.Data.Entities.HotelRoomType;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class HotelRoomTypeMapper : IMappingObject<Web.Api.Models.HotelRoomType, HotelRoomType>
    {
        public HotelRoomType Map(Web.Api.Models.HotelRoomType objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new HotelRoomType
            {
                Id = objectToMap.Id,
                //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public HotelRoomType Map(Web.Api.Models.HotelRoomType objectToMap, HotelRoomType refObj)
        {
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            refObj.Id = objectToMap.Id;
            //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
