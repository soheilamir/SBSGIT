using System.Linq;
using HotelRoomTypeNameByLanguage = SBSWebProject.Web.Api.Models.HotelRoomTypeNameByLanguage;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class HotelRoomTypeNameByLanguageMapper : IMappingObject<Data.Entities.HotelRoomTypeNameByLanguage, HotelRoomTypeNameByLanguage>
    {
        public HotelRoomTypeNameByLanguage Map(Data.Entities.HotelRoomTypeNameByLanguage objectToMap)
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
                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
