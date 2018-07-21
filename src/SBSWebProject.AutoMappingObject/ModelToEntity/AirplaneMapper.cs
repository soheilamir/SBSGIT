using System.Linq;
using Airplane = SBSWebProject.Data.Entities.Airplane;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class AirplaneMapper : IMappingObject<Web.Api.Models.Airplane, Airplane>
    {
        public Airplane Map(Web.Api.Models.Airplane objectToMap)
        {
            if (objectToMap == null) return null;
            var flightNumbersMapper = new FlightNumbersMapper();
            var outputModel = new Airplane
            {
                Id = objectToMap.Id,
                Name = objectToMap.Name,
                Company = objectToMap.Company,
                //FlightNumberS = objectToMap.FlightNumberS.Select(item => flightNumbersMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public Airplane Map(Web.Api.Models.Airplane objectToMap, Airplane refObj)
        {
            if (objectToMap == null) return null;
            var flightNumbersMapper = new FlightNumbersMapper();
            refObj.Id = objectToMap.Id;
            refObj.Name = objectToMap.Name;
            refObj.Company = objectToMap.Company;
            //FlightNumberS = objectToMap.FlightNumberS.Select(item => flightNumbersMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
