using FlightStopOver = SBSWebProject.Data.Entities.FlightStopOver;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class FlightStopOverMapper : IMappingObject<Web.Api.Models.FlightStopOver, FlightStopOver>
    {
        public FlightStopOver Map(Web.Api.Models.FlightStopOver objectToMap)
        {
            if (objectToMap == null) return null;
            var flightNumbersMapper = new FlightNumbersMapper();
            var cityMapper=new CityMapper();
            var outputModel = new FlightStopOver
            {
                Id = objectToMap.Id,
                FlightNumberItem = flightNumbersMapper.Map(objectToMap.FlightNumberItem),
                StopCity = cityMapper.Map(objectToMap.StopCity),
                StopTime = objectToMap.StopTime
            };
            return outputModel;
        }
    }
}
