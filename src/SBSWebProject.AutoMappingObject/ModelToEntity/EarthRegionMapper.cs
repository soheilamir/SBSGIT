using System.Linq;
using EarthRegion = SBSWebProject.Data.Entities.EarthRegion;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class EarthRegionMapper : IMappingObject<Web.Api.Models.EarthRegion, EarthRegion>
    {
        public EarthRegion Map(Web.Api.Models.EarthRegion objectToMap)
        {
            if (objectToMap == null) return null;
            var countryMapper = new CountryMapper();
            var outputModel = new EarthRegion
            {
                Id = objectToMap.Id,
                EarthRegionName = objectToMap.EarthRegionName,
                //CountryS = objectToMap.CountryS.Select(item => countryMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public EarthRegion Map(Web.Api.Models.EarthRegion objectToMap, EarthRegion refObj)
        {
            if (objectToMap == null) return null;
            var countryMapper = new CountryMapper();
            refObj.Id = objectToMap.Id;
            refObj.EarthRegionName = objectToMap.EarthRegionName;
            //CountryS = objectToMap.CountryS.Select(item => countryMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
