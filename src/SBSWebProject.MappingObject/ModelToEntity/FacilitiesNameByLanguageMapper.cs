using System.Linq;
using FacilitiesNameByLanguage = SBSWebProject.Data.Entities.FacilitiesNameByLanguage;
using SBSWebProject.Data.DataHandlers;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class FacilitiesNameByLanguageMapper : IMappingObject<Web.Api.Models.FacilitiesNameByLanguage, FacilitiesNameByLanguage>
    {
        private readonly IBasicDataHandler<Data.Entities.Facilities> _facilitiesDataHandler;
        private readonly IBasicDataHandler<Data.Entities.FacilitiesCategory> _facilitiesCategoryDataHandler;
        public FacilitiesNameByLanguageMapper(IBasicDataHandler<Data.Entities.Facilities> facilitiesDataHandler
            , IBasicDataHandler<Data.Entities.FacilitiesCategory> facilitiesCategoryDataHandler)
        {
            _facilitiesCategoryDataHandler = facilitiesCategoryDataHandler;
            _facilitiesDataHandler = facilitiesDataHandler;

        }
        public FacilitiesNameByLanguage Map(Web.Api.Models.FacilitiesNameByLanguage objectToMap)
        {
            if (objectToMap == null) return null;
            var languageMapper = new LanguageMapper();
            var facilitiesMapper = new FacilitiesMapper(_facilitiesDataHandler, _facilitiesCategoryDataHandler);
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
    }
}
