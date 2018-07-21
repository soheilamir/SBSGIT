using System.Linq;
using HotelComments = SBSWebProject.Data.Entities.HotelComments;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class HotelCommentsMapper : IMappingObject<Web.Api.Models.HotelComments, HotelComments>
    {

        public HotelComments Map(Web.Api.Models.HotelComments objectToMap)
        {
            if (objectToMap == null) return null;
            var usersMapper = new UsersMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            DateController dc = new DateController();
            var outputModel = new HotelComments
            {
                Id = objectToMap.Id,
                Comments = objectToMap.Comments,
                Date = dc.ConvertJalai2Ger(objectToMap.Date.ToString()),
                //HotelItem=,
                UserItem= usersMapper.Map(objectToMap.UserItem),
                //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
