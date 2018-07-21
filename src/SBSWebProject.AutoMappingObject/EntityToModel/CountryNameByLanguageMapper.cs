using CountryNameByLanguage = SBSWebProject.Web.Api.Models.CountryNameByLanguage;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class CountryNameByLanguageMapper : IMappingObject<Data.Entities.CountryNameByLanguage, CountryNameByLanguage>
    {
        public CountryNameByLanguage Map(Data.Entities.CountryNameByLanguage objectToMap)
        {
            if (objectToMap == null) return null;
            //var countryMapper = new CountryMapper();
            //var languageMapper = new LanguageMapper();
            var outputModel = new CountryNameByLanguage
            {
                Id = objectToMap.Id,
                ContryName = objectToMap.ContryName,
                LanguageName = objectToMap.LanguagesItem.LanguageName,
                //CountryItem = countryMapper.Map(objectToMap.CountryItem),
                //LanguagesItem = languageMapper.Map(objectToMap.LanguagesItem)
            };
            return outputModel;
        }
    }
}
