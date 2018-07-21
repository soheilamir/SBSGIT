using System;
using System.Linq;
using SBSWebProject.Web.Api.Models;
using CompanyOrdersConfirmation = SBSWebProject.Data.Entities.CompanyOrdersConfirmation;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class CompanyOrdersConfirmationMapper : IMappingObject<Web.Api.Models.CompanyOrdersConfirmation, CompanyOrdersConfirmation>
    {
        public CompanyOrdersConfirmation Map(Web.Api.Models.CompanyOrdersConfirmation objectToMap)
        {
            if (objectToMap == null) return null;
            var ordersMapper = new OrdersMapper();
            var companyEmployeeMapper = new CompanyEmployeeMapper();
            var outputModel = new CompanyOrdersConfirmation
            {
                CompanyEmployeeItem = companyEmployeeMapper.Map(objectToMap.CompanyEmployeeItem),
                ConfirmLevel = objectToMap.ConfirmLevel,
                IsConfirm = objectToMap.IsConfirm,
                OrdersItem = ordersMapper.Map(objectToMap.OrdersItem)
            };


            return outputModel;
        }
        public CompanyOrdersConfirmation Map(Web.Api.Models.CompanyOrdersConfirmation objectToMap, CompanyOrdersConfirmation refObj)
        {
            if (objectToMap == null) return null;
            var ordersMapper = new OrdersMapper();
            var companyEmployeeMapper = new CompanyEmployeeMapper();
            refObj.CompanyEmployeeItem = companyEmployeeMapper.Map(objectToMap.CompanyEmployeeItem);
            refObj.ConfirmLevel = objectToMap.ConfirmLevel;
            refObj.IsConfirm = objectToMap.IsConfirm;
            refObj.OrdersItem = ordersMapper.Map(objectToMap.OrdersItem);


            return refObj;
        }
    }
}
