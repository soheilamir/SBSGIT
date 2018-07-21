using System.Linq;
using FlightNumbers = SBSWebProject.Data.Entities.FlightNumbers;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class FlightNumbersMapper : IMappingObject<Web.Api.Models.FlightNumbers, FlightNumbers>
    {
        public FlightNumbers Map(Web.Api.Models.FlightNumbers objectToMap)
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
                AirlineSubClassesItem = airlineSubClassesMapper.Map(objectToMap.AirlineSubClassItem),
                AirplaneItem = airplaneMapper.Map(objectToMap.AirplaneItem),
                //DestinationCityItem = cityMapper.Map(objectToMap.DestinationCityItem),
                //FlightConditionS = objectToMap.FlightConditionS.Select(item => flightConditionMapper.Map(item)).ToList(),
                FlightFreeServicesesS = objectToMap.FlightFreeServicesesS.Select(item => flightFreeServiceMapper.Map(item)).ToList(),
                FlightNumber = objectToMap.FlightNumber,
                LandingTime = objectToMap.LandingTime,
                //SourceCityItem = cityMapper.Map(objectToMap.SourceCityItem),
                TakeOffTime = objectToMap.TakeOffTime,
                TransitTime = objectToMap.TransitTime,
                TicketValidation = objectToMap.TicketValidation,
                //FlightStopOverS = objectToMap.FlightStopOverS.Select(item => flightStopOverMapper.Map(item)).ToList(),
                //ResponseAirplaneTicketS = objectToMap.ResponseAirplaneTicketS.Select(item => responseAirplaneTicketMapper.Map(item)).ToList()
            };
            return outputModel;
        }

        public FlightNumbers Map(Web.Api.Models.FlightNumbers objectToMap, FlightNumbers refObj)
        {
            if (objectToMap == null) return null;
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var airplaneMapper = new AirplaneMapper();
            var cityMapper = new CityMapper();
            var flightConditionMapper = new FlightConditionMapper();
            var flightFreeServiceMapper = new FlightFreeServiceMapper();
            var flightStopOverMapper = new FlightStopOverMapper();
            var responseAirplaneTicketMapper = new ResponseAirplaneTicketMapper();
            refObj.Id = objectToMap.Id;
            refObj.AirlineSubClassesItem = airlineSubClassesMapper.Map(objectToMap.AirlineSubClassItem);
            refObj.AirplaneItem = airplaneMapper.Map(objectToMap.AirplaneItem);
            //DestinationCityItem = cityMapper.Map(objectToMap.DestinationCityItem),
            //FlightConditionS = objectToMap.FlightConditionS.Select(item => flightConditionMapper.Map(item)).ToList(),
            refObj.FlightFreeServicesesS = objectToMap.FlightFreeServicesesS.Select(item => flightFreeServiceMapper.Map(item)).ToList();
            refObj.FlightNumber = objectToMap.FlightNumber;
            refObj.LandingTime = objectToMap.LandingTime;
            //SourceCityItem = cityMapper.Map(objectToMap.SourceCityItem),
            refObj.TakeOffTime = objectToMap.TakeOffTime;
            refObj.TransitTime = objectToMap.TransitTime;
            refObj.TicketValidation = objectToMap.TicketValidation;
            //FlightStopOverS = objectToMap.FlightStopOverS.Select(item => flightStopOverMapper.Map(item)).ToList(),
            //ResponseAirplaneTicketS = objectToMap.ResponseAirplaneTicketS.Select(item => responseAirplaneTicketMapper.Map(item)).ToList()
            return refObj;
        }

    }
}
