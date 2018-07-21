using System;
using System.Linq;
using HotelRoomNightPrice = SBSWebProject.Web.Api.Models.HotelRoomNightPrice;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class HotelRoomNightPriceMapper : IMappingObject<Data.Entities.HotelRoomNightPrice, HotelRoomNightPrice>
    {
        public HotelRoomNightPrice Map(Data.Entities.HotelRoomNightPrice objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            DateController dc = new DateController();
            var outputModel = new HotelRoomNightPrice
            {
                Id = objectToMap.Id,
                Date = dc.ConvertGer2Jalai(Convert.ToDateTime(objectToMap.Date)),
                Description = objectToMap.Description,
                Price = objectToMap.Price,
                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
