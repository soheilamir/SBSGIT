using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using InsuranceCoverage = SBSWebProject.Web.Api.Models.InsuranceCoverage;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    class InsuranceCoverageMapper : IMappingObject<Data.Entities.InsuranceCoverage, InsuranceCoverage>
    {
        public InsuranceCoverage Map(Data.Entities.InsuranceCoverage objectToMap)
        {
            if (objectToMap == null) return null;
            //var airlineMapper = new AirlineMapper();
            //var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new InsuranceCoverage
            {
                Id = objectToMap.Id,

                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
