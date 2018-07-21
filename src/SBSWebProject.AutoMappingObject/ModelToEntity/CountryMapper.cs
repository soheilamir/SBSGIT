using System.Linq;
using Country = SBSWebProject.Data.Entities.Country;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class CountryMapper : IMappingObject<Web.Api.Models.Country, Country>
    {
        public Country Map(Web.Api.Models.Country objectToMap)
        {
            if (objectToMap == null) return null;
            var continentMapper = new ContinentMapper();
            var airlineMapper = new AirlineMapper();
            var countryIpAddressMapper = new CountryIpAddressMapper();
            var countryNameByLanguageMapper = new CountryNameByLanguageMapper();
            var earthRegionMapper = new EarthRegionMapper();
            var stateProvinceMapper = new StateProvinceMapper();
            var userLoginLogMapper = new UserLoginLogMapper();
            var outputModel = new Country
            {
                Id = objectToMap.Id,
                DialingCode = objectToMap.DialingCode,
                IsoCode = objectToMap.IsoCode,
                UnCode = objectToMap.UnCode,
                UnNum = objectToMap.UnNum,
                FlagUrl = objectToMap.FlagUrl,
                ContinentItem = continentMapper.Map(objectToMap.ContinentItem),
                //AirlinesS = objectToMap.AirlinesS.Select(item => airlineMapper.Map(item)).ToList(),
                //CountryIpAddressesS = objectToMap.CountryIpAddressesS.Select(item => countryIpAddressMapper.Map(item)).ToList(),
                //CountryNameByLanguageS = objectToMap.CountryNameByLanguageS.Select(item => countryNameByLanguageMapper.Map(item)).ToList(),
                //EarthRegionItem = earthRegionMapper.Map(objectToMap.EarthRegionItem),
                //StateProvinceS = objectToMap.StateProvinceS.Select(item => stateProvinceMapper.Map(item)).ToList(),
                //UserLoginLogS = objectToMap.UserLoginLogS.Select(item => userLoginLogMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public Country Map(Web.Api.Models.Country objectToMap, Country refObj)
        {
            if (objectToMap == null) return null;
            var continentMapper = new ContinentMapper();
            var airlineMapper = new AirlineMapper();
            var countryIpAddressMapper = new CountryIpAddressMapper();
            var countryNameByLanguageMapper = new CountryNameByLanguageMapper();
            var earthRegionMapper = new EarthRegionMapper();
            var stateProvinceMapper = new StateProvinceMapper();
            var userLoginLogMapper = new UserLoginLogMapper();
            refObj.Id = objectToMap.Id;
            refObj.DialingCode = objectToMap.DialingCode;
            refObj.IsoCode = objectToMap.IsoCode;
            refObj.UnCode = objectToMap.UnCode;
            refObj.UnNum = objectToMap.UnNum;
            refObj.FlagUrl = objectToMap.FlagUrl;
            refObj.ContinentItem = continentMapper.Map(objectToMap.ContinentItem);
            //AirlinesS = objectToMap.AirlinesS.Select(item => airlineMapper.Map(item)).ToList(),
            //CountryIpAddressesS = objectToMap.CountryIpAddressesS.Select(item => countryIpAddressMapper.Map(item)).ToList(),
            //CountryNameByLanguageS = objectToMap.CountryNameByLanguageS.Select(item => countryNameByLanguageMapper.Map(item)).ToList(),
            //EarthRegionItem = earthRegionMapper.Map(objectToMap.EarthRegionItem),
            //StateProvinceS = objectToMap.StateProvinceS.Select(item => stateProvinceMapper.Map(item)).ToList(),
            //UserLoginLogS = objectToMap.UserLoginLogS.Select(item => userLoginLogMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
