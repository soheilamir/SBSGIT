using System.Collections.Generic;
using System.Linq;
using Airlines = SBSWebProject.Web.Api.Models.Airlines;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class AirlineMapper : IMappingObject<Data.Entities.Airlines, Airlines>
    {
        public Airlines Map(Data.Entities.Airlines objectToMap)
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
                CountryName = (objectToMap.CountryItem != null) ? GetCountryNameByLangISO(objectToMap.CountryItem.CountryNameByLanguageS, "EN") : null,
                //FlightConditionS = (objectToMap.FlightConditionS != null) ? objectToMap.FlightConditionS.Where(c => c.State == 0).Select(item => flightConditionMapper.Map(item)).ToList() : null,
                //AirlineMembersS = (objectToMap.AirlineMembersS != null) ? objectToMap.AirlineMembersS.Where(c => c.State == 0).Select(item => airlineMemberMapper.Map(item)).ToList() : null,
                //AirlineNameByLanguageS = (objectToMap.AirlineNameByLanguageS != null) ? objectToMap.AirlineNameByLanguageS.Where(c => c.State == 0).Select(item => airlineNameByLanguageMapper.Map(item)).ToList() : null,
                //AirlineClassesS = (objectToMap.AirlineClassesS != null) ? objectToMap.AirlineClassesS.Where(c => c.State == 0).Select(item => airlineClassesMapper.Map(item)).ToList() : null,
                //UserFavoriteAirlinesS = (objectToMap.UserFavoriteAirlinesS != null) ? objectToMap.UserFavoriteAirlinesS.Where(c => c.State == 0).Select(item => userFavoriteAirlineMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
        private SBSWebProject.Web.Api.Models.ComboBox GetCountryNameByLangISO(IList<SBSWebProject.Data.Entities.CountryNameByLanguage> lstName, string isoLangName)
        {
            IList<SBSWebProject.Data.Entities.CountryNameByLanguage> lstResult = lstName.Where(c => c.State == 0 && c.LanguagesItem.ISO6391 == isoLangName).ToList();
            if (lstResult.Count > 0)
                return new SBSWebProject.Web.Api.Models.ComboBox { id = (int)lstResult[0].Id, name = lstResult[0].ContryName };
            return null;
        }
    }
}
