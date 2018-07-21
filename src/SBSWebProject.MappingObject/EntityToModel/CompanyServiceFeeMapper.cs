using System.Linq;
using CompanyServiceFee = SBSWebProject.Web.Api.Models.CompanyServiceFee;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class CompanyServiceFeeMapper : IMappingObject<Data.Entities.CompanyServiceFee, CompanyServiceFee>
    {
        public CompanyServiceFee Map(Data.Entities.CompanyServiceFee objectToMap)
        {
            if (objectToMap == null) return null;
            var companyMapper = new CompanyMapper();
            var servicesMapper = new ServicesMapper();
            var outputModel = new CompanyServiceFee
            {
                Id = objectToMap.Id,
                IsPercent = objectToMap.IsPercent,
                ServiceItem = servicesMapper.Map(objectToMap.ServiceItem),
                ServiceFee = objectToMap.ServiceFee,
                CompanyItem = companyMapper.Map(objectToMap.CompanyItem)
            };
            return outputModel;
        }
    }
}
