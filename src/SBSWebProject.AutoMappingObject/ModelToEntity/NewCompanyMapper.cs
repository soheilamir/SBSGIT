using System.Linq;
using Company = SBSWebProject.Data.Entities.Company;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class NewCompanyMapper : IMappingObject<Web.Api.Models.NewCompany, Company>
    {
        public Company Map(Web.Api.Models.NewCompany objectToMap)
        {
            if (objectToMap == null) return null;
            var companyAttachmentMapper = new CompanyAttachmentMapper();
            var companyEmployeeMapper = new CompanyEmployeeMapper();
            var companyServiceFeeMapper = new CompanyServiceFeeMapper();
            var ordersMapper = new OrdersMapper();
            var outputModel = new Company
            {
                Id = objectToMap.Id,
                Address = objectToMap.Address,
                CompanyName = objectToMap.CompanyName,
                ContractNumber = objectToMap.ContractNumber,
                RegisterDate = objectToMap.RegisterDate,
                Tel = objectToMap.Tel,
                Fax = objectToMap.Fax,

            };
            return outputModel;
        }
        public Company Map(Web.Api.Models.NewCompany objectToMap, Company refObj)
        {
            if (objectToMap == null) return null;
            var companyAttachmentMapper = new CompanyAttachmentMapper();
            var companyEmployeeMapper = new CompanyEmployeeMapper();
            var companyServiceFeeMapper = new CompanyServiceFeeMapper();
            var ordersMapper = new OrdersMapper();
            refObj.Id = objectToMap.Id;
            refObj.Address = objectToMap.Address;
            refObj.CompanyName = objectToMap.CompanyName;
            refObj.ContractNumber = objectToMap.ContractNumber;
            refObj.RegisterDate = objectToMap.RegisterDate;
            refObj.Tel = objectToMap.Tel;
            refObj.Fax = objectToMap.Fax;
            return refObj;
        }
    }
}
