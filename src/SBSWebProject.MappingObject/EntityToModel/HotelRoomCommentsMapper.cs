using System.Linq;
using HotelRoomComments = SBSWebProject.Web.Api.Models.HotelRoomComments;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class HotelRoomCommentsMapper : IMappingObject<Data.Entities.HotelRoomComments, HotelRoomComments>
    {
        public HotelRoomComments Map(Data.Entities.HotelRoomComments objectToMap)
        {
            if (objectToMap == null) return null;
            var usersMapper = new UsersMapper();
            var outputModel = new HotelRoomComments
            {
                Id = objectToMap.Id,
                Comments = objectToMap.Comments,
                UserItem = usersMapper.Map(objectToMap.UserItem),
                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
