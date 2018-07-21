using System.Linq;
using CityPublicPlaceNameByLanguage = SBSWebProject.Web.Api.Models.CityPublicPlaceNameByLanguage;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class CityPublicPlaceNameByLanguageMapper : IMappingObject<Data.Entities.CityPublicPlaceNameByLanguage, CityPublicPlaceNameByLanguage>
    {
        public CityPublicPlaceNameByLanguage Map(Data.Entities.CityPublicPlaceNameByLanguage objectToMap)
        {
            if (objectToMap == null) return null;
            var languageMapper = new LanguageMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new CityPublicPlaceNameByLanguage
            {
                Id = objectToMap.Id,
                Description = objectToMap.Description,
                LanguagesItem = languageMapper.Map(objectToMap.LanguagesItem),
                Name = objectToMap.Name,
                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
