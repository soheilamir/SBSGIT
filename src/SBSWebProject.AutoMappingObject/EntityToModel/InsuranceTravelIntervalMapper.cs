using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using InsuranceTravelInterval = SBSWebProject.Web.Api.Models.InsuranceTravelInterval;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    class InsuranceTravelIntervalMapper : IMappingObject<Data.Entities.InsuranceTravelInterval, InsuranceTravelInterval>
    {
        public InsuranceTravelInterval Map(Data.Entities.InsuranceTravelInterval objectToMap)
        {
            if (objectToMap == null) return null;
            //var airlineMapper = new AirlineMapper();
            //var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new InsuranceTravelInterval
            {
                Id = objectToMap.Id,

                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
