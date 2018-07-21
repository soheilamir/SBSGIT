using System.Linq;
using FacilitiesCategory = SBSWebProject.Data.Entities.FacilitiesCategory;
using SBSWebProject.Data.DataHandlers;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class FacilitiesCategoryMapper : IMappingObject<Web.Api.Models.FacilitiesCategory, FacilitiesCategory>
    {
        public FacilitiesCategory Map(Web.Api.Models.FacilitiesCategory objectToMap)
        {

            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new FacilitiesCategory
            {
                CategoryName = objectToMap.CategoryName,
            };

            return outputModel;
        }
        public FacilitiesCategory Map(Web.Api.Models.FacilitiesCategory objectToMap, FacilitiesCategory refObj)
        {

            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            refObj.CategoryName = objectToMap.CategoryName;
            return refObj;
        }
    }
}
