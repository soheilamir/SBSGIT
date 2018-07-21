using System.Linq;
using Company = SBSWebProject.Web.Api.Models.Company;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class CompanyMapper : IMappingObject<Data.Entities.Company, Company>
    {
        public Company Map(Data.Entities.Company objectToMap)
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
                CreditDay = objectToMap.CreditDay,
                CreditFee = objectToMap.CreditFee,
                DepositPercent = objectToMap.DepositPercent,
                EndCooperation = objectToMap.EndCooperation,
                HasAttachment = objectToMap.HasAttachment,
                RegisterDate = objectToMap.RegisterDate,
                StartCooperation = objectToMap.StartCooperation,
                Tel = objectToMap.Tel,
                Fax = objectToMap.Fax,

                //OrdersS = (objectToMap.OrdersS != null) ? objectToMap.OrdersS.Where(c => c.State == 0).Select(item => ordersMapper.Map(item)).ToList() : null,
                //CompanyAttachmentS = (objectToMap.CompanyAttachmentS != null) ? objectToMap.CompanyAttachmentS.Where(c => c.State == 0).Select(item => companyAttachmentMapper.Map(item)).ToList() : null,
                //CompanyEmployeeS = (objectToMap.CompanyEmployeeS != null) ? objectToMap.CompanyEmployeeS.Where(c => c.State == 0).Select(item => companyEmployeeMapper.Map(item)).ToList() : null,
                //CompanyServiceFeeS = (objectToMap.CompanyServiceFeeS != null) ? objectToMap.CompanyServiceFeeS.Where(c => c.State == 0).Select(item => companyServiceFeeMapper.Map(item)).ToList() : null

            };


            return outputModel;
        }
    }
}
