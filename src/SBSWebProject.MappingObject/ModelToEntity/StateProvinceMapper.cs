using System.Linq;
using StateProvince = SBSWebProject.Data.Entities.StateProvince;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class StateProvinceMapper : IMappingObject<Web.Api.Models.StateProvince, StateProvince>
    {
        public StateProvince Map(Web.Api.Models.StateProvince objectToMap)
        {
            if (objectToMap == null) return null;
            var stateProvinceNameByLanguageMapper = new StateProvinceNameByLanguageMapper();
            var countryMapper = new CountryMapper();
            var outputModel = new StateProvince
            {
                Id = objectToMap.Id,
                CountryItem = countryMapper.Map(objectToMap.CountryItem),
                CharCode = objectToMap.CharCode,
                TelCode = objectToMap.TelCode,
                Priority = objectToMap.Priority,
                //StateProvinceNameByLanguageS = objectToMap.StateProvinceNameByLanguageS.Select(item => stateProvinceNameByLanguageMapper.Map(item)).ToList()
                //TODO
            };
            return outputModel;
        }
    }
}
