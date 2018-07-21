using System.Linq;
using FacilitiesNameByLanguage = SBSWebProject.Data.Entities.FacilitiesNameByLanguage;
using SBSWebProject.Data.DataHandlers;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class FacilitiesNameByLanguageMapper : IMappingObject<Web.Api.Models.FacilitiesNameByLanguage, FacilitiesNameByLanguage>
    {
        public FacilitiesNameByLanguage Map(Web.Api.Models.FacilitiesNameByLanguage objectToMap)
        {
            if (objectToMap == null) return null;
            var languageMapper = new LanguageMapper();
            var facilitiesMapper = new FacilitiesMapper();
            var outputModel = new FacilitiesNameByLanguage
            {
                Id = objectToMap.Id,
                Description = objectToMap.Description,
                LanguagesItem = languageMapper.Map(objectToMap.LanguagesItem),
                Name = objectToMap.Name,
                FacilitiesItem = facilitiesMapper.Map(objectToMap.FacilitiesItem),
                //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public FacilitiesNameByLanguage Map(Web.Api.Models.FacilitiesNameByLanguage objectToMap, FacilitiesNameByLanguage refObj)
        {
            if (objectToMap == null) return null;
            var languageMapper = new LanguageMapper();
            var facilitiesMapper = new FacilitiesMapper();
            refObj.Id = objectToMap.Id;
            refObj.Description = objectToMap.Description;
            refObj.LanguagesItem = languageMapper.Map(objectToMap.LanguagesItem);
            refObj.Name = objectToMap.Name;
            refObj.FacilitiesItem = facilitiesMapper.Map(objectToMap.FacilitiesItem);
            //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
