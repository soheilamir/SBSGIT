using FlightFreeServices = SBSWebProject.Web.Api.Models.FlightFreeServices;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class FlightFreeServiceMapper : IMappingObject<Data.Entities.FlightFreeServices, FlightFreeServices>
    {
        public FlightFreeServices Map(Data.Entities.FlightFreeServices objectToMap)
        {
            if (objectToMap == null) return null;
            var flightNumbersMapper=new FlightNumbersMapper();
            var outputModel = new FlightFreeServices
            {
                Id = objectToMap.Id,
                ServiceDescription = objectToMap.ServiceDescription,
                ServiceName = objectToMap.ServiceName,
                //FlightNumberItem = flightNumbersMapper.Map(objectToMap.FlightNumberItem)
            };
            return outputModel;
        }
    }
}
