using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using Country = SBSWebProject.Data.Entities.Country;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class ExcelCountryMapper : IMappingObject<Web.Api.Models.ExcelReaderCountry, Country>
    {
        public Country Map(ExcelReaderCountry objectToMap)
        {
            if (objectToMap == null) return null;
            var continentMapper = new ContinentMapper();
            var earthRegionMapper = new EarthRegionMapper();
            var outputModel = new Country
            {
                ContinentItem = continentMapper.Map(objectToMap.ContinentItem),
                EarthRegionItem = earthRegionMapper.Map(objectToMap.EarthRegionItem),
                DialingCode = objectToMap.DialingCode,
                IsoCode = objectToMap.IsoCode,
                UnCode = objectToMap.UnCode,
                UnNum = objectToMap.UnNum,
            };
            return outputModel;
        }
        public Country Map(ExcelReaderCountry objectToMap, Country refObj)
        {
            if (objectToMap == null) return null;
            var continentMapper = new ContinentMapper();
            var earthRegionMapper = new EarthRegionMapper();
            refObj.ContinentItem = continentMapper.Map(objectToMap.ContinentItem);
            refObj.EarthRegionItem = earthRegionMapper.Map(objectToMap.EarthRegionItem);
            refObj.DialingCode = objectToMap.DialingCode;
            refObj.IsoCode = objectToMap.IsoCode;
            refObj.UnCode = objectToMap.UnCode;
            refObj.UnNum = objectToMap.UnNum;
            return refObj;
        }
    }
}
