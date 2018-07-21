using System.Linq;
using EarthRegion = SBSWebProject.Web.Api.Models.EarthRegion;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class EarthRegionMapper : IMappingObject<Data.Entities.EarthRegion, EarthRegion>
    {
        public EarthRegion Map(Data.Entities.EarthRegion objectToMap)
        {
            if (objectToMap == null) return null;
            //var countryMapper = new CountryMapper();
            var outputModel = new EarthRegion
            {
                Id = objectToMap.Id,
                EarthRegionName = objectToMap.EarthRegionName,
                //CountryS = objectToMap.CountryS.Where(c => c.State == 0).Select(item => countryMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
