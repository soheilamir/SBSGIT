using System.Linq;
using HotelNameByLanguage = SBSWebProject.Data.Entities.HotelNameByLanguage;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class HotelNameByLanguageMapper : IMappingObject<Web.Api.Models.HotelNameByLanguage, HotelNameByLanguage>
    {
        public HotelNameByLanguage Map(Web.Api.Models.HotelNameByLanguage objectToMap)
        {
            if (objectToMap == null) return null;
            var hotelsMapper = new HotelsMapper();
            var languageMapper = new LanguageMapper();
            var outputModel = new HotelNameByLanguage
            {
                Id = objectToMap.Id,
                HotelItem = hotelsMapper.Map(objectToMap.HotelItem),
                LanguagesItem = languageMapper.Map(objectToMap.LanguagesItem),
                Name = objectToMap.Name,
                //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public HotelNameByLanguage Map(Web.Api.Models.HotelNameByLanguage objectToMap, HotelNameByLanguage refObj)
        {
            if (objectToMap == null) return null;
            var hotelsMapper = new HotelsMapper();
            var languageMapper = new LanguageMapper();
            refObj.Id = objectToMap.Id;
            refObj.HotelItem = hotelsMapper.Map(objectToMap.HotelItem);
            refObj.LanguagesItem = languageMapper.Map(objectToMap.LanguagesItem);
            refObj.Name = objectToMap.Name;
            //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
