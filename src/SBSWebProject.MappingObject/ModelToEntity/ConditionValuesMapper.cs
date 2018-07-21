using ConditionValues = SBSWebProject.Data.Entities.ConditionValues;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class ConditionValuesMapper : IMappingObject<Web.Api.Models.ConditionValues, ConditionValues>
    {
        public ConditionValues Map(Web.Api.Models.ConditionValues objectToMap)
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
