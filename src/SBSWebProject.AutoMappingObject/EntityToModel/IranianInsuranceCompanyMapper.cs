using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using IranianInsuranceCompany = SBSWebProject.Web.Api.Models.IranianInsuranceCompany;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    class IranianInsuranceCompanyMapper : IMappingObject<Data.Entities.IranianInsuranceCompany, IranianInsuranceCompany>
    {
        public IranianInsuranceCompany Map(Data.Entities.IranianInsuranceCompany objectToMap)
        {
            if (objectToMap == null) return null;
            //var airlineMapper = new AirlineMapper();
            //var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new IranianInsuranceCompany
            {
                Id = objectToMap.Id,
                
                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
