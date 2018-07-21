using System.Linq;
using ConditionType = SBSWebProject.Data.Entities.ConditionType;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class ConditionTypeMapper : IMappingObject<Web.Api.Models.ConditionType, ConditionType>
    {
        public ConditionType Map(Web.Api.Models.ConditionType objectToMap)
        {
            if (objectToMap == null) return null;
            var flightConditionMapper = new FlightConditionMapper();
            var cityMapper = new CityMapper();
            var outputModel = new ConditionType
            {
                Id = objectToMap.Id,
                TypeName = objectToMap.TypeName,
                //FlightConditionS = objectToMap.FlightConditionS.Select(item=> flightConditionMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public ConditionType Map(Web.Api.Models.ConditionType objectToMap, ConditionType refObj)
        {
            if (objectToMap == null) return null;
            var flightConditionMapper = new FlightConditionMapper();
            var cityMapper = new CityMapper();
            refObj.Id = objectToMap.Id;
            refObj.TypeName = objectToMap.TypeName;
            //FlightConditionS = objectToMap.FlightConditionS.Select(item=> flightConditionMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
