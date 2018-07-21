using FlightStopOver = SBSWebProject.Web.Api.Models.FlightStopOver;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class FlightStopOverMapper : IMappingObject<Data.Entities.FlightStopOver, FlightStopOver>
    {
        public FlightStopOver Map(Data.Entities.FlightStopOver objectToMap)
        {
            if (objectToMap == null) return null;
            var flightNumbersMapper = new FlightNumbersMapper();
            var cityMapper=new CityMapper();
            var outputModel = new FlightStopOver
            {
                Id = objectToMap.Id,
                //FlightNumberItem = flightNumbersMapper.Map(objectToMap.FlightNumberItem),
                StopCity = cityMapper.Map(objectToMap.StopCity),
                StopTime = objectToMap.StopTime
            };
            return outputModel;
        }
    }
}
