using System.Linq;
using HotelRoomTypeNameByLanguage = SBSWebProject.Data.Entities.HotelRoomTypeNameByLanguage;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class HotelRoomTypeNameByLanguageMapper : IMappingObject<Web.Api.Models.HotelRoomTypeNameByLanguage, HotelRoomTypeNameByLanguage>
    {
        public HotelRoomTypeNameByLanguage Map(Web.Api.Models.HotelRoomTypeNameByLanguage objectToMap)
        {
            if (objectToMap == null) return null;
            var languageMapper = new LanguageMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new HotelRoomTypeNameByLanguage
            {
                Id = objectToMap.Id,
                Description = objectToMap.Description,
                LanguagesItem = languageMapper.Map(objectToMap.LanguagesItem),
                Name = objectToMap.Name,
                //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public HotelRoomTypeNameByLanguage Map(Web.Api.Models.HotelRoomTypeNameByLanguage objectToMap, HotelRoomTypeNameByLanguage refObj)
        {
            if (objectToMap == null) return null;
            var languageMapper = new LanguageMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            refObj.Id = objectToMap.Id;
            refObj.Description = objectToMap.Description;
            refObj.LanguagesItem = languageMapper.Map(objectToMap.LanguagesItem);
            refObj.Name = objectToMap.Name;
            //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
