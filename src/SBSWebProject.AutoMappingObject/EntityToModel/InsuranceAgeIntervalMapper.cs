using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using InsuranceAgeInterval = SBSWebProject.Web.Api.Models.InsuranceAgeInterval;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    class InsuranceAgeIntervalMapper : IMappingObject<Data.Entities.InsuranceAgeInterval, InsuranceAgeInterval>
    {
        public InsuranceAgeInterval Map(Data.Entities.InsuranceAgeInterval objectToMap)
        {
            if (objectToMap == null) return null;
            //var airlineMapper = new AirlineMapper();
            //var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new InsuranceAgeInterval
            {
                Id = objectToMap.Id,

                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
