using Status = SBSWebProject.Data.Entities.Status;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class StatusMapper : IMappingObject<Web.Api.Models.Status, Status>
    {
        public Status Map(Web.Api.Models.Status objectToMap)
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
