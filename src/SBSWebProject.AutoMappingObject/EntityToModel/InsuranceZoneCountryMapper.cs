using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using InsuranceZoneCountry = SBSWebProject.Web.Api.Models.InsuranceZoneCountry;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    class InsuranceZoneCountryMapper : IMappingObject<Data.Entities.InsuranceZoneCountry, InsuranceZoneCountry>
    {
        public InsuranceZoneCountry Map(Data.Entities.InsuranceZoneCountry objectToMap)
        {
            if (objectToMap == null) return null;
            //var airlineMapper = new AirlineMapper();
            //var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new InsuranceZoneCountry
            {
                Id = objectToMap.Id,

                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
