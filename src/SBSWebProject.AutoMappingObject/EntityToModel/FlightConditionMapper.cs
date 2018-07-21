using System.Linq;
using FlightCondition = SBSWebProject.Web.Api.Models.FlightCondition;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class FlightConditionMapper : IMappingObject<Data.Entities.FlightCondition, FlightCondition>
    {
        public FlightCondition Map(Data.Entities.FlightCondition objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var conditionTypeMapper = new ConditionTypeMapper();
            //var conditionValueMapper = new ConditionValuesMapper();
            //var flightNumbersMapper = new FlightNumbersMapper();
            var outputModel = new FlightCondition
            {
                Id = objectToMap.Id,
                AirlinesItem = airlineMapper.Map(objectToMap.AirlinesItem),
                ConditionTypeItem = conditionTypeMapper.Map(objectToMap.ConditionTypeItem),
                //ConditionValuesS = objectToMap.ConditionValuesS.Where(c => c.State == 0).Select(item => conditionValueMapper.Map(item)).ToList(),
                //FlightNumberItem = flightNumbersMapper.Map(objectToMap.FlightNumberItem)
            };
            return outputModel;
        }
    }
}
