using System.Linq;
using Airplane = SBSWebProject.Web.Api.Models.Airplane;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class AirplaneMapper : IMappingObject<Data.Entities.Airplane, Airplane>
    {
        public Airplane Map(Data.Entities.Airplane objectToMap)
        {
            if (objectToMap == null) return null;
            var flightNumbersMapper = new FlightNumbersMapper();
            var outputModel = new Airplane
            {
                Id = objectToMap.Id,
                Name = objectToMap.Name,
                Company = objectToMap.Company,
                //FlightNumberS = (objectToMap.FlightNumberS != null) ? objectToMap.FlightNumberS.Where(c => c.State == 0).Select(item => flightNumbersMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
