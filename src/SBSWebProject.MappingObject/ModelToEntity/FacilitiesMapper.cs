using System.Linq;
using Facilities = SBSWebProject.Data.Entities.Facilities;
using SBSWebProject.Data.DataHandlers;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class FacilitiesMapper : IMappingObject<Web.Api.Models.Facilities, Facilities>
    {
        private readonly IBasicDataHandler<Data.Entities.FacilitiesCategory> _facilitiesCategoryDataHandler;
        private readonly IBasicDataHandler<Data.Entities.Facilities> _facilitiesDataHandler;
        public FacilitiesMapper(IBasicDataHandler<Data.Entities.Facilities> facilitiesDataHandler
            , IBasicDataHandler<Data.Entities.FacilitiesCategory> facilitiesCategoryDataHandler)
        {
            _facilitiesCategoryDataHandler = facilitiesCategoryDataHandler;
            _facilitiesDataHandler = facilitiesDataHandler;

        }
        public Facilities Map(Web.Api.Models.Facilities objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var facilitiesCategoryMapper = new FacilitiesCategoryMapper(_facilitiesCategoryDataHandler);

            var outputModel = new Facilities();
            if (objectToMap.Id != 0)
            {
                outputModel = _facilitiesDataHandler.GetEntity(objectToMap.Id);
            }
            outputModel.FacilitiesCategoryItem = facilitiesCategoryMapper.Map(objectToMap.FacilitiesCategoryItem);
            //outputModel.AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList();
            return outputModel;
        }
    }
}
