using System.Linq;
using FlightCondition = SBSWebProject.Data.Entities.FlightCondition;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class FlightConditionMapper : IMappingObject<Web.Api.Models.FlightCondition, FlightCondition>
    {
        public FlightCondition Map(Web.Api.Models.FlightCondition objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var conditionTypeMapper = new ConditionTypeMapper();
            var conditionValueMapper = new ConditionValuesMapper();
            var flightNumbersMapper = new FlightNumbersMapper();
            var outputModel = new FlightCondition
            {
                Id = objectToMap.Id,
                AirlinesItem = airlineMapper.Map(objectToMap.AirlinesItem),
                ConditionTypeItem = conditionTypeMapper.Map(objectToMap.ConditionTypeItem),
                //ConditionValuesS = objectToMap.ConditionValuesS.Select(item => conditionValueMapper.Map(item)).ToList(),
                //FlightNumberItem = flightNumbersMapper.Map(objectToMap.FlightNumberItem)
            };
            return outputModel;
        }
        public FlightCondition Map(Web.Api.Models.FlightCondition objectToMap, FlightCondition refObj)
        {
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var conditionTypeMapper = new ConditionTypeMapper();
            var conditionValueMapper = new ConditionValuesMapper();
            var flightNumbersMapper = new FlightNumbersMapper();
            refObj.Id = objectToMap.Id;
            refObj.AirlinesItem = airlineMapper.Map(objectToMap.AirlinesItem);
            refObj.ConditionTypeItem = conditionTypeMapper.Map(objectToMap.ConditionTypeItem);
            //ConditionValuesS = objectToMap.ConditionValuesS.Select(item => conditionValueMapper.Map(item)).ToList(),
            //FlightNumberItem = flightNumbersMapper.Map(objectToMap.FlightNumberItem)
            return refObj;
        }
    }
}
