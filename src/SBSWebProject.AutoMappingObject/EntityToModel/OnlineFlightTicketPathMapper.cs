using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using OnlineFlightTicketPath = SBSWebProject.Web.Api.Models.OnlineFlightTicketPath;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class OnlineFlightTicketPathMapper : IMappingObject<Data.Entities.OnlineFlightTicketPath, OnlineFlightTicketPath>
    {
        public OnlineFlightTicketPath Map(Data.Entities.OnlineFlightTicketPath objectToMap)
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
