using System.Linq;
using FlightNumbers = SBSWebProject.Web.Api.Models.FlightNumbers;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class FlightNumbersMapper : IMappingObject<Data.Entities.FlightNumbers, FlightNumbers>
    {
        public FlightNumbers Map(Data.Entities.FlightNumbers objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var airplaneMapper = new AirplaneMapper();
            var cityMapper = new CityMapper();
            var flightConditionMapper = new FlightConditionMapper();
            var flightFreeServiceMapper = new FlightFreeServiceMapper();
            var flightStopOverMapper = new FlightStopOverMapper();
            var responseAirplaneTicketMapper = new ResponseAirplaneTicketMapper();
            var outputModel = new FlightNumbers
            {
                Id = objectToMap.Id,
                AirlineSubClassItem = airlineSubClassesMapper.Map(objectToMap.AirlineSubClassesItem),
                AirplaneItem = airplaneMapper.Map(objectToMap.AirplaneItem),
                //DestinationCityItem = cityMapper.Map(objectToMap.DestinationCityItem),
                //FlightConditionS = objectToMap.FlightConditionS.Where(c => c.State == 0).Select(item => flightConditionMapper.Map(item)).ToList(),
                FlightFreeServicesesS = objectToMap.FlightFreeServicesesS.Where(c => c.State == 0).Select(item => flightFreeServiceMapper.Map(item)).ToList(),
                FlightNumber = objectToMap.FlightNumber,
                LandingTime = objectToMap.LandingTime,
                //SourceCityItem = cityMapper.Map(objectToMap.SourceCityItem),
                TakeOffTime = objectToMap.TakeOffTime,
                TransitTime = objectToMap.TransitTime,
                TicketValidation = objectToMap.TicketValidation,
                //FlightStopOverS = objectToMap.FlightStopOverS.Where(c => c.State == 0).Select(item => flightStopOverMapper.Map(item)).ToList(),
                //ResponseAirplaneTicketS = objectToMap.ResponseAirplaneTicketS.Where(c => c.State == 0).Select(item => responseAirplaneTicketMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
