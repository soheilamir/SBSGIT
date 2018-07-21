using FlightStopOver = SBSWebProject.Data.Entities.FlightStopOver;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class FlightStopOverMapper : IMappingObject<Web.Api.Models.FlightStopOver, FlightStopOver>
    {
        public FlightStopOver Map(Web.Api.Models.FlightStopOver objectToMap)
        {
            if (objectToMap == null) return null;
            var flightNumbersMapper = new FlightNumbersMapper();
            var cityMapper = new CityMapper();
            var outputModel = new FlightStopOver
            {
                Id = objectToMap.Id,
                FlightNumberItem = flightNumbersMapper.Map(objectToMap.FlightNumberItem),
                StopCity = cityMapper.Map(objectToMap.StopCity),
                StopTime = objectToMap.StopTime
            };
            return outputModel;
        }
        public FlightStopOver Map(Web.Api.Models.FlightStopOver objectToMap, FlightStopOver refObj)
        {
            if (objectToMap == null) return null;
            var flightNumbersMapper = new FlightNumbersMapper();
            var cityMapper = new CityMapper();
            refObj.Id = objectToMap.Id;
            refObj.FlightNumberItem = flightNumbersMapper.Map(objectToMap.FlightNumberItem);
            refObj.StopCity = cityMapper.Map(objectToMap.StopCity);
            refObj.StopTime = objectToMap.StopTime;
            return refObj;
        }
    }
}
