using System.Linq;
using HotelRoomComments = SBSWebProject.Data.Entities.HotelRoomComments;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class HotelRoomCommentsMapper : IMappingObject<Web.Api.Models.HotelRoomComments, HotelRoomComments>
    {
        public HotelRoomComments Map(Web.Api.Models.HotelRoomComments objectToMap)
        {
            if (objectToMap == null) return null;
            var hotelRoomMapper = new HotelRoomMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new HotelRoomComments
            {
                Id = objectToMap.Id,
                Comments = objectToMap.Comments,
                HotelRoomItem = hotelRoomMapper.Map(objectToMap.HotelRoomItem),
                UserItem = usersMapper.Map(objectToMap.UserItem),
                //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public HotelRoomComments Map(Web.Api.Models.HotelRoomComments objectToMap, HotelRoomComments refObj)
        {
            if (objectToMap == null) return null;
            var hotelRoomMapper = new HotelRoomMapper();
            var usersMapper = new UsersMapper();
            refObj.Id = objectToMap.Id;
            refObj.Comments = objectToMap.Comments;
            refObj.HotelRoomItem = hotelRoomMapper.Map(objectToMap.HotelRoomItem);
            refObj.UserItem = usersMapper.Map(objectToMap.UserItem);
            //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
