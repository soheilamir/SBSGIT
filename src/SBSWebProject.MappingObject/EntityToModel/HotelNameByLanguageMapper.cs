using System.Linq;
using HotelNameByLanguage = SBSWebProject.Web.Api.Models.HotelNameByLanguage;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class HotelNameByLanguageMapper : IMappingObject<Data.Entities.HotelNameByLanguage, HotelNameByLanguage>
    {
        public HotelNameByLanguage Map(Data.Entities.HotelNameByLanguage objectToMap)
        {
            if (objectToMap == null) return null;
            var languageMapper = new LanguageMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new HotelNameByLanguage
            {
                Id = objectToMap.Id,
                LanguagesItem = languageMapper.Map(objectToMap.LanguagesItem),
                Name = objectToMap.Name,
                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
