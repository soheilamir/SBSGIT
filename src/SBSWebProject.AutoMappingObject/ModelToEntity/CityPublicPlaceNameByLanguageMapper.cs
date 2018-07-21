using System.Linq;
using CityPublicPlaceNameByLanguage = SBSWebProject.Data.Entities.CityPublicPlaceNameByLanguage;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
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
        public CityPublicPlaceNameByLanguage Map(Web.Api.Models.CityPublicPlaceNameByLanguage objectToMap, CityPublicPlaceNameByLanguage refObj)
        {
            if (objectToMap == null) return null;
            var cityPublicPlaceMapper = new CityPublicPlaceMapper();
            refObj.Id = objectToMap.Id;
            refObj.CityPublicPlaceItem = cityPublicPlaceMapper.Map(objectToMap.CityPublicPlaceItem);
            refObj.Description = objectToMap.Description;
            refObj.Name = objectToMap.Name;
            refObj.LanguagesItem = new Data.Entities.Languages { Id = objectToMap.LanguagesItem.Id };
            //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
