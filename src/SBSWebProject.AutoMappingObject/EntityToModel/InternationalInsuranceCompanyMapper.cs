using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using InternationalInsuranceCompany = SBSWebProject.Web.Api.Models.InternationalInsuranceCompany;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    class InternationalInsuranceCompanyMapper : IMappingObject<Data.Entities.InternationalInsuranceCompany, InternationalInsuranceCompany>
    {
        public InternationalInsuranceCompany Map(Data.Entities.InternationalInsuranceCompany objectToMap)
        {
            if (objectToMap == null) return null;
            //var airlineMapper = new AirlineMapper();
            //var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new InternationalInsuranceCompany
            {
                Id = objectToMap.Id,

                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
