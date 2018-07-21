using System.Linq;
using HotelFacilities = SBSWebProject.Data.Entities.HotelFacilities;
using SBSWebProject.Data.DataHandlers;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class HotelFacilitiesMapper : IMappingObject<Web.Api.Models.HotelFacilities, HotelFacilities>
    {
        private readonly IBasicDataHandler<Data.Entities.Facilities> _facilitiesDataHandler;
        private readonly IBasicDataHandler<Data.Entities.FacilitiesCategory> _facilitiesCategoryDataHandler;
        public HotelFacilitiesMapper(IBasicDataHandler<Data.Entities.Facilities> facilitiesDataHandler
            , IBasicDataHandler<Data.Entities.FacilitiesCategory> facilitiesCategoryDataHandler)
        {
            _facilitiesCategoryDataHandler = facilitiesCategoryDataHandler;
            _facilitiesDataHandler = facilitiesDataHandler;

        }
        public HotelFacilities Map(Web.Api.Models.HotelFacilities objectToMap)
        {
            if (objectToMap == null) return null;
            var facilitiesMapper = new FacilitiesMapper(_facilitiesDataHandler, _facilitiesCategoryDataHandler);
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
    }
}
