using System.Linq;
using HotelFacilities = SBSWebProject.Web.Api.Models.HotelFacilities;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class HotelFacilitiesMapper : IMappingObject<Data.Entities.HotelFacilities, HotelFacilities>
    {
        public HotelFacilities Map(Data.Entities.HotelFacilities objectToMap)
        {
            if (objectToMap == null) return null;
            var facilitiesMapper = new FacilitiesMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new HotelFacilities
            {
                Id = objectToMap.Id,
                FacilitiesItem = facilitiesMapper.Map(objectToMap.FacilitiesItem),
                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
