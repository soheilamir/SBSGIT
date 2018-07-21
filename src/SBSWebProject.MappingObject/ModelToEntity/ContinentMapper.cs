using System.Linq;
using Continent = SBSWebProject.Data.Entities.Continent;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class ContinentMapper : IMappingObject<Web.Api.Models.Continent, Continent>
    {
        public Continent Map(Web.Api.Models.Continent objectToMap)
        {
            if (objectToMap == null) return null;
            var countryMapper = new CountryMapper();
            var outputModel = new Continent
            {
                Id = objectToMap.Id,
                ContinentName = objectToMap.ContinentName,
                //CountryS = objectToMap.CountryS.Select(item => countryMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
