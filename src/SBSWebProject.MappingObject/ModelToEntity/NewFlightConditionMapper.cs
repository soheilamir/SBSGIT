using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using FlightCondition = SBSWebProject.Data.Entities.FlightCondition;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class NewFlightConditionMapper : IMappingObject<Web.Api.Models.NewFlightCondition, FlightCondition>
    {
        public FlightCondition Map(NewFlightCondition objectToMap)
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
                ConditionTypeItem = conditionTypeMapper.Map(objectToMap.ConditionTypeItem)
            };
            return outputModel;
        }
    }
}
