using System.Linq;
using Company = SBSWebProject.Data.Entities.Company;

namespace SBSWebProject.MappingObject.ModelToEntity
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
    }
}
