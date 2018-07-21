using System.Linq;
using Company = SBSWebProject.Data.Entities.Company;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class CompanyMapper : IMappingObject<Web.Api.Models.Company, Company>
    {
        public Company Map(Web.Api.Models.Company objectToMap)
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
                //OrdersS = (objectToMap.OrdersS != null) ? objectToMap.OrdersS.Select(item => ordersMapper.Map(item)).ToList() : null,
                //CompanyAttachmentS = (objectToMap.CompanyAttachmentS != null) ? objectToMap.CompanyAttachmentS.Select(item => companyAttachmentMapper.Map(item)).ToList() : null,
                //CompanyEmployeeS = (objectToMap.CompanyEmployeeS != null) ? objectToMap.CompanyEmployeeS.Select(item => companyEmployeeMapper.Map(item)).ToList() : null,
                //CompanyServiceFeeS = (objectToMap.CompanyServiceFeeS != null) ? objectToMap.CompanyServiceFeeS.Select(item => companyServiceFeeMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
        public Company Map(Web.Api.Models.Company objectToMap, Company refObj)
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
            refObj.CreditDay = objectToMap.CreditDay;
            refObj.CreditFee = objectToMap.CreditFee;
            refObj.DepositPercent = objectToMap.DepositPercent;
            refObj.EndCooperation = objectToMap.EndCooperation;
            refObj.HasAttachment = objectToMap.HasAttachment;
            refObj.RegisterDate = objectToMap.RegisterDate;
            refObj.StartCooperation = objectToMap.StartCooperation;
            refObj.Tel = objectToMap.Tel;
            refObj.Fax = objectToMap.Fax;
            //OrdersS = (objectToMap.OrdersS != null) ? objectToMap.OrdersS.Select(item => ordersMapper.Map(item)).ToList() : null,
            //CompanyAttachmentS = (objectToMap.CompanyAttachmentS != null) ? objectToMap.CompanyAttachmentS.Select(item => companyAttachmentMapper.Map(item)).ToList() : null,
            //CompanyEmployeeS = (objectToMap.CompanyEmployeeS != null) ? objectToMap.CompanyEmployeeS.Select(item => companyEmployeeMapper.Map(item)).ToList() : null,
            //CompanyServiceFeeS = (objectToMap.CompanyServiceFeeS != null) ? objectToMap.CompanyServiceFeeS.Select(item => companyServiceFeeMapper.Map(item)).ToList() : null
            return refObj;
        }
    }
}
