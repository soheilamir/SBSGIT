using System.Linq;
using ConditionType = SBSWebProject.Web.Api.Models.ConditionType;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class ConditionTypeMapper : IMappingObject<Data.Entities.ConditionType, ConditionType>
    {
        public ConditionType Map(Data.Entities.ConditionType objectToMap)
        {
            if (objectToMap == null) return null;
            var flightConditionMapper = new FlightConditionMapper();
            var cityMapper = new CityMapper();
            var outputModel = new ConditionType
            {
                Id = objectToMap.Id,
                TypeName = objectToMap.TypeName,
                //FlightConditionS = objectToMap.FlightConditionS.Where(c=>c.State==0).Select(item=> flightConditionMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
