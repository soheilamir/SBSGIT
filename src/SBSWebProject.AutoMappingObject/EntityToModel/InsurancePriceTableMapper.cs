using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using InsurancePriceTable = SBSWebProject.Web.Api.Models.InsurancePriceTable;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    class InsurancePriceTableMapper : IMappingObject<Data.Entities.InsurancePriceTable, InsurancePriceTable>
    {
        public InsurancePriceTable Map(Data.Entities.InsurancePriceTable objectToMap)
        {
            if (objectToMap == null) return null;
            //var airlineMapper = new AirlineMapper();
            //var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new InsurancePriceTable
            {
                Id = objectToMap.Id,

                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
