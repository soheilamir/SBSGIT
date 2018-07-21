using System.Linq;
using FacilitiesCategory = SBSWebProject.Data.Entities.FacilitiesCategory;
using SBSWebProject.Data.DataHandlers;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class FacilitiesCategoryMapper : IMappingObject<Web.Api.Models.FacilitiesCategory, FacilitiesCategory>
    {
        private readonly IBasicDataHandler<Data.Entities.FacilitiesCategory> _facilitiesCategoryDataHandler;
        public FacilitiesCategoryMapper(IBasicDataHandler<Data.Entities.FacilitiesCategory> facilitiesCategoryDataHandler)
        {
            _facilitiesCategoryDataHandler = facilitiesCategoryDataHandler;
        }
        public FacilitiesCategory Map(Web.Api.Models.FacilitiesCategory objectToMap)
        {
            var outputModel = new FacilitiesCategory();
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            if (objectToMap.Id != 0)
            {
                outputModel = _facilitiesCategoryDataHandler.GetEntity(objectToMap.Id);
            }
            outputModel.CategoryName = objectToMap.CategoryName;
            return outputModel;
        }
    }
}
