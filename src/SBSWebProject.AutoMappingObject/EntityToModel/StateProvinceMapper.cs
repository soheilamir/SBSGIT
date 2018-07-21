using System.Collections.Generic;
using System.Linq;
using StateProvince = SBSWebProject.Web.Api.Models.StateProvince;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class StateProvinceMapper : IMappingObject<Data.Entities.StateProvince, StateProvince>
    {
        public StateProvince Map(Data.Entities.StateProvince objectToMap)
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
                StateProvinceName = GetStateProvinceNameByLangISO(objectToMap.StateProvinceNameByLanguageS, "EN"),
                //StateProvinceNameByLanguageS = objectToMap.StateProvinceNameByLanguageS.Where(c => c.State == 0).Select(item => stateProvinceNameByLanguageMapper.Map(item)).ToList()
                //TODO
            };
            return outputModel;
        }

        private string GetStateProvinceNameByLangISO(IList<SBSWebProject.Data.Entities.StateProvinceNameByLanguage> lstName, string isoLangName)
        {
            IList<SBSWebProject.Data.Entities.StateProvinceNameByLanguage> lstResult = lstName.Where(c => c.State == 0 && c.LanguagesItem.ISO6391 == isoLangName).ToList();
            if (lstResult.Count > 0)
                return lstResult[0].StateProvinceName;
            return null;
        }
    }
}
