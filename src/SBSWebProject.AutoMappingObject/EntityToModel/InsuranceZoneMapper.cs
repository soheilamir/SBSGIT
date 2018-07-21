using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using InsuranceZone = SBSWebProject.Web.Api.Models.InsuranceZone;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    class InsuranceZoneMapper : IMappingObject<Data.Entities.InsuranceZone, InsuranceZone>
    {
        public InsuranceZone Map(Data.Entities.InsuranceZone objectToMap)
        {
            if (objectToMap == null) return null;
            //var airlineMapper = new AirlineMapper();
            //var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new InsuranceZone
            {
                Id = objectToMap.Id,

                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
