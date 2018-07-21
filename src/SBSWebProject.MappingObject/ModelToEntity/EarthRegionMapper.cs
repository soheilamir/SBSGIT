using System.Linq;
using EarthRegion = SBSWebProject.Data.Entities.EarthRegion;

namespace SBSWebProject.MappingObject.ModelToEntity
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
    }
}
