using System.Linq;
using CityPublicPlaceNameByLanguage = SBSWebProject.Data.Entities.CityPublicPlaceNameByLanguage;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class CityPublicPlaceNameByLanguageMapper : IMappingObject<Web.Api.Models.CityPublicPlaceNameByLanguage, CityPublicPlaceNameByLanguage>
    {

        public CityPublicPlaceNameByLanguage Map(Web.Api.Models.CityPublicPlaceNameByLanguage objectToMap)
        {
            if (objectToMap == null) return null;
            var cityPublicPlaceMapper = new CityPublicPlaceMapper();
            var outputModel = new CityPublicPlaceNameByLanguage
            {
                Id = objectToMap.Id,
                CityPublicPlaceItem = cityPublicPlaceMapper.Map(objectToMap.CityPublicPlaceItem),
                Description = objectToMap.Description,
                Name = objectToMap.Name,
                LanguagesItem = new Data.Entities.Languages { Id = objectToMap.LanguagesItem.Id },
                //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
