using System.Linq;
using CompanyServiceFee = SBSWebProject.Data.Entities.CompanyServiceFee;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class CompanyServiceFeeMapper : IMappingObject<Web.Api.Models.CompanyServiceFee, CompanyServiceFee>
    {
        public CompanyServiceFee Map(Web.Api.Models.CompanyServiceFee objectToMap)
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
        public CompanyServiceFee Map(Web.Api.Models.CompanyServiceFee objectToMap, CompanyServiceFee refObj)
        {
            if (objectToMap == null) return null;
            var companyMapper = new CompanyMapper();
            var servicesMapper = new ServicesMapper();
            refObj.Id = objectToMap.Id;
            refObj.IsPercent = objectToMap.IsPercent;
            refObj.ServiceItem = servicesMapper.Map(objectToMap.ServiceItem);
            refObj.ServiceFee = objectToMap.ServiceFee;
            refObj.CompanyItem = companyMapper.Map(objectToMap.CompanyItem);
            return refObj;
        }
    }
}
