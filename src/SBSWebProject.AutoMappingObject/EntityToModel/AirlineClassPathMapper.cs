using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using AirlineClassPath = SBSWebProject.Web.Api.Models.AirlineClassPath;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class AirlineClassPathMapper : IMappingObject<Data.Entities.AirlineClassPath, AirlineClassPath>
    {
        public AirlineClassPath Map(Data.Entities.AirlineClassPath objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var flightConditionMapper = new FlightConditionMapper();
            var flightNumbersMapper = new FlightNumbersMapper();
            var flightPathMapper = new FlightPathMapper();
            var outputModel = new AirlineClassPath
            {
                Id = objectToMap.Id,
                AirlineSubClassesItem = airlineSubClassesMapper.Map(objectToMap.AirlineSubClassesItem),
                IsActive = objectToMap.IsActive,
                //FlightConditionS = (objectToMap.FlightConditionS != null) ? objectToMap.FlightConditionS.Where(c => c.State == 0).Select(item => flightConditionMapper.Map(item)).ToList() : null,
                //FlightNumbersS = (objectToMap.FlightNumbersS != null) ? objectToMap.FlightNumbersS.Where(c => c.State == 0).Select(item => flightNumbersMapper.Map(item)).ToList() : null,
                FlightPathItem = flightPathMapper.Map(objectToMap.FlightPathItem)
            };
            return outputModel;
        }
    }
}
