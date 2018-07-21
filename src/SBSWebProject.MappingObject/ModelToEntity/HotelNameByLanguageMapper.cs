using System.Linq;
using HotelNameByLanguage = SBSWebProject.Data.Entities.HotelNameByLanguage;

namespace SBSWebProject.MappingObject.ModelToEntity
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
    }
}
