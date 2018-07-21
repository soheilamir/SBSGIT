using System.Linq;
using HotelOrRoomConditions = SBSWebProject.Web.Api.Models.HotelOrRoomConditions;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class HotelOrRoomConditionsMapper : IMappingObject<Data.Entities.HotelOrRoomConditions, HotelOrRoomConditions>
    {
        public HotelOrRoomConditions Map(Data.Entities.HotelOrRoomConditions objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new HotelOrRoomConditions
            {
                Id = objectToMap.Id,
                Condition=objectToMap.Condition,
                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
