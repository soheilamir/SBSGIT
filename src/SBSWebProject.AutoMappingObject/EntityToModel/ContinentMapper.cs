using System.Linq;
using Continent = SBSWebProject.Web.Api.Models.Continent;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class ContinentMapper : IMappingObject<Data.Entities.Continent, Continent>
    {
        public Continent Map(Data.Entities.Continent objectToMap)
        {
            if (objectToMap == null) return null;
            var countryMapper = new CountryMapper();
            var outputModel = new Continent
            {
                Id = objectToMap.Id,
                ContinentName = objectToMap.ContinentName,
                //CountryS = objectToMap.CountryS.Where(c => c.State == 0).Select(item => countryMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
