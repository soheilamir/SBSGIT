using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Status = SBSWebProject.Web.Api.Models.Status;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class StatusMapper : IMappingObject<Data.Entities.Status, Status>
    {
        public Status Map(Data.Entities.Status objectToMap)
        {
            if (objectToMap == null) return null;
            var requestAirplaneTicketMapper = new RequestAirplaneTicketMapper();
            var flightNumbersMapper = new FlightNumbersMapper();
            var outputModel = new Status
            {
                
                //TODO
            };
            return outputModel;
        }
    }
}
