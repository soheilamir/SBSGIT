using System.Linq;
using System.Collections.Generic;
using Country = SBSWebProject.Web.Api.Models.Country;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class CountryMapper : IMappingObject<Data.Entities.Country, Country>
    {
        public Country Map(Data.Entities.Country objectToMap)
        {
            if (objectToMap == null) return null;
            var continentMapper = new ContinentMapper();
            //var airlineMapper = new AirlineMapper();
            //var countryIpAddressMapper = new CountryIpAddressMapper();
            //var countryNameByLanguageMapper = new CountryNameByLanguageMapper();
            var earthRegionMapper = new EarthRegionMapper();
            //var stateProvinceMapper = new StateProvinceMapper();
            //var userLoginLogMapper = new UserLoginLogMapper();

            var outputModel = new Country
            {
                Id = objectToMap.Id,
                DialingCode = objectToMap.DialingCode,
                IsoCode = objectToMap.IsoCode,
                UnCode = objectToMap.UnCode,
                UnNum = objectToMap.UnNum,
                FlagUrl = objectToMap.FlagUrl,
                ContinentItem = continentMapper.Map(objectToMap.ContinentItem),
                CountryName = GetCountryNameByLangISO(objectToMap.CountryNameByLanguageS, "EN"),
                //AirlinesS = objectToMap.AirlinesS.Where(c => c.State == 0).Select(item => airlineMapper.Map(item)).ToList(),
                //CountryIpAddressesS = objectToMap.CountryIpAddressesS.Where(c => c.State == 0).Select(item => countryIpAddressMapper.Map(item)).ToList(),
                //CountryNameByLanguageS = objectToMap.CountryNameByLanguageS.Where(c => c.State == 0).Select(item => countryNameByLanguageMapper.Map(item)).ToList(),
                EarthRegionItem = earthRegionMapper.Map(objectToMap.EarthRegionItem),
                //StateProvinceS = objectToMap.StateProvinceS.Where(c => c.State == 0).Select(item => stateProvinceMapper.Map(item)).ToList(),
                //UserLoginLogS = objectToMap.UserLoginLogS.Where(c => c.State == 0).Select(item => userLoginLogMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        private string GetCountryNameByLangISO(IList<SBSWebProject.Data.Entities.CountryNameByLanguage> lstName, string isoLangName)
        {
            IList<SBSWebProject.Data.Entities.CountryNameByLanguage> lstResult = lstName.Where(c => c.State == 0 && c.LanguagesItem.ISO6391 == isoLangName).ToList();
            if (lstResult.Count > 0)
                return lstResult[0].ContryName;
            return null;
        }
    }
}
