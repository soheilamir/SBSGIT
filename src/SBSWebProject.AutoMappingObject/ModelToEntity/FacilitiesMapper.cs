using System.Linq;
using Facilities = SBSWebProject.Data.Entities.Facilities;
using SBSWebProject.Data.DataHandlers;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class FacilitiesMapper : IMappingObject<Web.Api.Models.Facilities, Facilities>
    {
        public Facilities Map(Web.Api.Models.Facilities objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var facilitiesCategoryMapper = new FacilitiesCategoryMapper();
            var outputModel = new Facilities
            {
                Id = objectToMap.Id,
                FacilitiesCategoryItem = facilitiesCategoryMapper.Map(objectToMap.FacilitiesCategoryItem),
                //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList(),
            };
            return outputModel;
        }
        public Facilities Map(Web.Api.Models.Facilities objectToMap, Facilities refObj)
        {
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var facilitiesCategoryMapper = new FacilitiesCategoryMapper();
            refObj.Id = objectToMap.Id;
            refObj.FacilitiesCategoryItem = facilitiesCategoryMapper.Map(objectToMap.FacilitiesCategoryItem);
            //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList(),
            return refObj;
        }
    }
}
