using System.Collections.Generic;
using System.Linq;
using City = SBSWebProject.Web.Api.Models.City;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class CityMapper : IMappingObject<Data.Entities.City, City>
    {
        public City Map(Data.Entities.City objectToMap)
        {
            if (objectToMap == null) return null;
            var stateProvinceMapper = new StateProvinceMapper();
            var passengerMapper = new PassengerMapper();
            var airportMapper = new AirportMapper();
            var usersMapper = new UsersMapper();
            var cityNameByLanguageMapper = new CityNameByLanguageMapper();
            var flightNumbersMapper = new FlightNumbersMapper();
            var flightStopOverMapper = new FlightStopOverMapper();
            var requestAirplaneTicketMapper = new RequestAirplaneTicketMapper();
            var outputModel = new City
            {
                Id = objectToMap.Id,
                CharCode = objectToMap.CharCode,
                //CityMapFile = objectToMap.CityMapFile,
                //IsCapital = objectToMap.IsCapital,
                //Priority = objectToMap.Priority,
                //TelCode = objectToMap.TelCode,
                //StateProvinceItem = stateProvinceMapper.Map(objectToMap.StateProvinceItem),
                //OriginIATACODE = objectToMap.CharCode,
                CityName = GetCityNameByLangISO(objectToMap.CityNameByLanguageS, "FA"),
                //BirthPlacePassengerS = objectToMap.BirthPlacePassengerS.Where(c => c.State == 0).Select(item => passengerMapper.Map(item)).ToList(),
                //AirportsS = objectToMap.AirportsS.Where(c => c.State == 0).Select(item => airportMapper.Map(item)).ToList(),
                //BirthPlaceUserS = objectToMap.BirthPlaceUserS.Where(c => c.State == 0).Select(item => usersMapper.Map(item)).ToList(),
                //CityNameByLanguageS = objectToMap.CityNameByLanguageS.Where(c => c.State == 0).Select(item => cityNameByLanguageMapper.Map(item)).ToList(),
                //DestinationCityFlightNumberS = objectToMap.DestinationCityFlightNumberS.Where(c => c.State == 0).Select(item => flightNumbersMapper.Map(item)).ToList(),
                //FlightStopOverS = objectToMap.FlightStopOverS.Where(c => c.State == 0).Select(item => flightStopOverMapper.Map(item)).ToList(),
                //LeavingPlaceUserS = objectToMap.LeavingPlaceUserS.Where(c => c.State == 0).Select(item => usersMapper.Map(item)).ToList(),
                //RequestDestinationAirplaneTicketS = objectToMap.RequestDestinationAirplaneTicketS.Where(c => c.State == 0).Select(item => requestAirplaneTicketMapper.Map(item)).ToList(),
                //RequestSourceAirplaneTicketS = objectToMap.RequestSourceAirplaneTicketS.Where(c => c.State == 0).Select(item => requestAirplaneTicketMapper.Map(item)).ToList(),
                //SourceCityFlightNumberS = objectToMap.SourceCityFlightNumberS.Where(c => c.State == 0).Select(item => flightNumbersMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        private string GetCityNameByLangISO(IList<SBSWebProject.Data.Entities.CityNameByLanguage> lstName, string isoLangName)
        {
            IList<SBSWebProject.Data.Entities.CityNameByLanguage> lstResult = lstName.Where(c => c.State == 0 && c.LanguagesItem.ISO6391 == isoLangName).ToList();
            if (lstResult.Count > 0)
                return lstResult[0].Name;
            return null;
        }
    }
}
