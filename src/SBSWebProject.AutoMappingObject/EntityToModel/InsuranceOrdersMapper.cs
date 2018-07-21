using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using InsuranceOrders = SBSWebProject.Web.Api.Models.InsuranceOrders;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    class InsuranceOrdersMapper : IMappingObject<Data.Entities.InsuranceOrders, InsuranceOrders>
    {
        public InsuranceOrders Map(Data.Entities.InsuranceOrders objectToMap)
        {
            if (objectToMap == null) return null;
            //var airlineMapper = new AirlineMapper();
            //var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new InsuranceOrders
            {
                Id = objectToMap.Id,

                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
