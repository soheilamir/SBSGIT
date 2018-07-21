using System.Linq;
using Airlines = SBSWebProject.Data.Entities.Airlines;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class AirlineMapper : IMappingObject<Web.Api.Models.Airlines, Airlines>
    {
        public Airlines Map(Web.Api.Models.Airlines objectToMap)
        {
            if (objectToMap == null) return null;
            var countryMapper = new CountryMapper();
            var flightConditionMapper = new FlightConditionMapper();
            var airlineMemberMapper = new AirlineMemberMapper();
            var airlineNameByLanguageMapper = new AirlineNameByLanguageMapper();
            var airlineClassesMapper = new AirlineClassesMapper();
            var userFavoriteAirlineMapper = new UserFavoriteAirlineMapper();
            var outputModel = new Airlines
            {
                Id = objectToMap.Id,
                FlightStateCode = objectToMap.FlightStateCode,
                IacoCode = objectToMap.IacoCode,
                IataCode = objectToMap.IataCode,
                Name = objectToMap.Name,
                Type = objectToMap.Type,
                Include = objectToMap.Include,
                CountryItem = countryMapper.Map(objectToMap.CountryItem),
                //FlightConditionS = objectToMap.FlightConditionS.Select(item => flightConditionMapper.Map(item)).ToList(),
                //AirlineMembersS = objectToMap.AirlineMembersS.Select(item => airlineMemberMapper.Map(item)).ToList(),
                //AirlineNameByLanguageS = objectToMap.AirlineNameByLanguageS.Select(item => airlineNameByLanguageMapper.Map(item)).ToList(),
                //AirlineClassesS = objectToMap.AirlineClassesS.Select(item => airlineClassesMapper.Map(item)).ToList(),
                //UserFavoriteAirlinesS = objectToMap.UserFavoriteAirlinesS.Select(item => userFavoriteAirlineMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
