using ConditionValues = SBSWebProject.Web.Api.Models.ConditionValues;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class ConditionValuesMapper : IMappingObject<Data.Entities.ConditionValues, ConditionValues>
    {
        public ConditionValues Map(Data.Entities.ConditionValues objectToMap)
        {
            if (objectToMap == null) return null;
            var flightConditionMapper = new FlightConditionMapper();
            var outputModel = new ConditionValues
            {
                Id = objectToMap.Id,
                ConditionKey = objectToMap.ConditionKey,
                ConditionValue = objectToMap.ConditionValue,
                FlightConditionItem = flightConditionMapper.Map(objectToMap.FlightConditionItem)
            };
            return outputModel;
        }
    }
}
