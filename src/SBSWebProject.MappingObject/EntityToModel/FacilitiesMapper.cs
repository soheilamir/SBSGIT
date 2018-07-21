using System.Linq;
using Facilities = SBSWebProject.Web.Api.Models.Facilities;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class FacilitiesMapper : IMappingObject<Data.Entities.Facilities, Facilities>
    {
        public Facilities Map(Data.Entities.Facilities objectToMap)
        {
            if (objectToMap == null) return null;
            var facilitiesCategoryMapper = new FacilitiesCategoryMapper();
            var facilitiesNameByLanguageMapper = new FacilitiesNameByLanguageMapper();
            var outputModel = new Facilities
            {
                Id = objectToMap.Id,
                FacilitiesPersianName = GetPersianFacilitiesName(objectToMap),
                FacilitiesCategoryItem = facilitiesCategoryMapper.Map(objectToMap.FacilitiesCategoryItem),
                FacilitiesNameByLanguageS = (objectToMap.FacilitiesNameByLanguageS != null) ? objectToMap.FacilitiesNameByLanguageS.Where(c => c.State == 0).Select(item => facilitiesNameByLanguageMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
        private string GetPersianFacilitiesName(Data.Entities.Facilities obj)
        {
            foreach (Data.Entities.FacilitiesNameByLanguage item in obj.FacilitiesNameByLanguageS)
            {
                if (item.State == 0 && item.LanguagesItem.ISO6391 == "FA")
                    return item.Name;
            }
            return null;
        }
    }
}
