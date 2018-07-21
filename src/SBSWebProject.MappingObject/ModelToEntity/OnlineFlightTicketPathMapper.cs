using System.Linq;
using OnlineFlightTicketPath = SBSWebProject.Data.Entities.OnlineFlightTicketPath;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class OnlineFlightTicketPathMapper : IMappingObject<Web.Api.Models.OnlineFlightTicketPath, OnlineFlightTicketPath>
    {
        public OnlineFlightTicketPath Map(Web.Api.Models.OnlineFlightTicketPath objectToMap)
        {
            if (objectToMap == null) return null;
            var onlineFlightTicketMapper = new OnlineFlightTicketMapper();
            var airlineClassPathMapper = new AirlineClassPathMapper();
            var outputModel = new OnlineFlightTicketPath
            {
                Id = objectToMap.Id,
                //AirlineClassPathFeeItem = airlineClassPathMapper.Map(objectToMap.AirlineClassPathItem),
                DeparturDate = objectToMap.DeparturDate,
                OnlineFlightTicketItem = onlineFlightTicketMapper.Map(objectToMap.OnlineFlightTicketItem)

            };
            return outputModel;
        }
    }
}
