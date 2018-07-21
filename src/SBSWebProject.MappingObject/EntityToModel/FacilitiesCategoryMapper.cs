using System.Linq;
using FacilitiesCategory = SBSWebProject.Web.Api.Models.FacilitiesCategory;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class FacilitiesCategoryMapper : IMappingObject<Data.Entities.FacilitiesCategory, FacilitiesCategory>
    {
        public FacilitiesCategory Map(Data.Entities.FacilitiesCategory objectToMap)
        {
            if (objectToMap == null) return null;
            var facilitiesMapper = new FacilitiesMapper();
            var outputModel = new FacilitiesCategory
            {
                Id = objectToMap.Id,
                CategoryName=objectToMap.CategoryName,
                //FacilitiesS= (objectToMap.FacilitiesS != null) ? objectToMap.FacilitiesS.Where(c => c.State == 0).Select(item => facilitiesMapper.Map(item)).ToList() : null
                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
