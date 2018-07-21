using System;
using System.Linq;
using HotelComments = SBSWebProject.Web.Api.Models.HotelComments;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class HotelCommentsMapper : IMappingObject<Data.Entities.HotelComments, HotelComments>
    {
        public HotelComments Map(Data.Entities.HotelComments objectToMap)
        {
            if (objectToMap == null) return null;
            var usersMapper = new UsersMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            DateController dc = new DateController();
            var outputModel = new HotelComments
            {
                Id = objectToMap.Id,
                Comments = objectToMap.Comments,
                //Date= dc.ConvertGer2Jalai(Convert.ToDateTime(objectToMap.Date)),
                UserItem = usersMapper.Map(objectToMap.UserItem),
                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
