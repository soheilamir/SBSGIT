using System.Linq;
using HotelFacilities = SBSWebProject.Data.Entities.HotelFacilities;
using SBSWebProject.Data.DataHandlers;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class HotelFacilitiesMapper : IMappingObject<Web.Api.Models.HotelFacilities, HotelFacilities>
    {
        public HotelFacilities Map(Web.Api.Models.HotelFacilities objectToMap)
        {
            if (objectToMap == null) return null;
            var facilitiesMapper = new FacilitiesMapper();
            var hotelsMapper = new HotelsMapper();
            var outputModel = new HotelFacilities
            {
                Id = objectToMap.Id,
                FacilitiesItem = facilitiesMapper.Map(objectToMap.FacilitiesItem),
                HotelItem = hotelsMapper.Map(objectToMap.HotelItem),

                //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public HotelFacilities Map(Web.Api.Models.HotelFacilities objectToMap, HotelFacilities refObj)
        {
            if (objectToMap == null) return null;
            var facilitiesMapper = new FacilitiesMapper();
            var hotelsMapper = new HotelsMapper();
            refObj.Id = objectToMap.Id;
            refObj.FacilitiesItem = facilitiesMapper.Map(objectToMap.FacilitiesItem);
            refObj.HotelItem = hotelsMapper.Map(objectToMap.HotelItem);
            //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
