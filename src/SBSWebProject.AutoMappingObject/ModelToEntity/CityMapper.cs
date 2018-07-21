using System.Linq;
using City = SBSWebProject.Data.Entities.City;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class CityMapper : IMappingObject<Web.Api.Models.City, City>
    {
        public City Map(Web.Api.Models.City objectToMap)
        {
            if (objectToMap == null) return null;
            var stateProvinceMapper = new StateProvinceMapper();
            var passengerMapper = new PassengerMapper();
            var airportMapper = new AirportMapper();
            var usersMapper = new UsersMapper();
            var cityNameByLanguageMapper = new CityNameByLanguageMapper();
            var flightPathMapper = new FlightPathMapper();
            var flightStopOverMapper = new FlightStopOverMapper();
            var requestAirplaneTicketMapper = new RequestAirplaneTicketMapper();
            var outputModel = new City
            {
                Id = objectToMap.Id,
                //CharCode = objectToMap.OriginIATACODE,
                CharCode = objectToMap.CharCode,
                //CityMapFile = objectToMap.CityMapFile,
                //IsCapital = objectToMap.IsCapital,
                //Priority = objectToMap.Priority,
                //TelCode = objectToMap.TelCode,
                //StateProvinceItem = stateProvinceMapper.Map(objectToMap.StateProvinceItem),


                //BirthPlacePassengerS = objectToMap.BirthPlacePassengerS.Select(item => passengerMapper.Map(item)).ToList(),
                //AirportsS = objectToMap.AirportsS.Select(item => airportMapper.Map(item)).ToList(),
                //BirthPlaceUserS = objectToMap.BirthPlaceUserS.Select(item => usersMapper.Map(item)).ToList(),
                //CityNameByLanguageS = objectToMap.CityNameByLanguageS.Select(item => cityNameByLanguageMapper.Map(item)).ToList(),
                //DestinationCityFlightPathS = objectToMap.DestinationCityFlightPathS.Select(item => flightPathMapper.Map(item)).ToList(),
                //FlightStopOverS = objectToMap.FlightStopOverS.Select(item => flightStopOverMapper.Map(item)).ToList(),
                //LeavingPlaceUserS = objectToMap.LeavingPlaceUserS.Select(item => usersMapper.Map(item)).ToList(),
                //RequestDestinationAirplaneTicketS = objectToMap.RequestDestinationAirplaneTicketS.Select(item => requestAirplaneTicketMapper.Map(item)).ToList(),
                //RequestSourceAirplaneTicketS = objectToMap.RequestSourceAirplaneTicketS.Select(item => requestAirplaneTicketMapper.Map(item)).ToList(),
                //SourceCityFlightPathS = objectToMap.SourceCityFlightPathS.Select(item => flightPathMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public City Map(Web.Api.Models.City objectToMap, City refObj)
        {
            if (objectToMap == null) return null;
            var stateProvinceMapper = new StateProvinceMapper();
            var passengerMapper = new PassengerMapper();
            var airportMapper = new AirportMapper();
            var usersMapper = new UsersMapper();
            var cityNameByLanguageMapper = new CityNameByLanguageMapper();
            var flightPathMapper = new FlightPathMapper();
            var flightStopOverMapper = new FlightStopOverMapper();
            refObj.Id = objectToMap.Id;
            //CharCode = objectToMap.OriginIATACODE,
            refObj.CharCode = objectToMap.CharCode;
            //CityMapFile = objectToMap.CityMapFile,
            //IsCapital = objectToMap.IsCapital,
            //Priority = objectToMap.Priority,
            //TelCode = objectToMap.TelCode,
            //StateProvinceItem = stateProvinceMapper.Map(objectToMap.StateProvinceItem),


            //BirthPlacePassengerS = objectToMap.BirthPlacePassengerS.Select(item => passengerMapper.Map(item)).ToList(),
            //AirportsS = objectToMap.AirportsS.Select(item => airportMapper.Map(item)).ToList(),
            //BirthPlaceUserS = objectToMap.BirthPlaceUserS.Select(item => usersMapper.Map(item)).ToList(),
            //CityNameByLanguageS = objectToMap.CityNameByLanguageS.Select(item => cityNameByLanguageMapper.Map(item)).ToList(),
            //DestinationCityFlightPathS = objectToMap.DestinationCityFlightPathS.Select(item => flightPathMapper.Map(item)).ToList(),
            //FlightStopOverS = objectToMap.FlightStopOverS.Select(item => flightStopOverMapper.Map(item)).ToList(),
            //LeavingPlaceUserS = objectToMap.LeavingPlaceUserS.Select(item => usersMapper.Map(item)).ToList(),
            //RequestDestinationAirplaneTicketS = objectToMap.RequestDestinationAirplaneTicketS.Select(item => requestAirplaneTicketMapper.Map(item)).ToList(),
            //RequestSourceAirplaneTicketS = objectToMap.RequestSourceAirplaneTicketS.Select(item => requestAirplaneTicketMapper.Map(item)).ToList(),
            //SourceCityFlightPathS = objectToMap.SourceCityFlightPathS.Select(item => flightPathMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
