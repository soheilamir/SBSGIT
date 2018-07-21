using System.Linq;
using FacilitiesNameByLanguage = SBSWebProject.Web.Api.Models.FacilitiesNameByLanguage;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class FacilitiesNameByLanguageMapper : IMappingObject<Data.Entities.FacilitiesNameByLanguage, FacilitiesNameByLanguage>
    {
        public FacilitiesNameByLanguage Map(Data.Entities.FacilitiesNameByLanguage objectToMap)
        {
            if (objectToMap == null) return null;
            var languageMapper = new LanguageMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new FacilitiesNameByLanguage
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
