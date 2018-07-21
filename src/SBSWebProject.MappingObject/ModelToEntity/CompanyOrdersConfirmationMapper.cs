using System;
using System.Linq;
using SBSWebProject.Web.Api.Models;
using CompanyOrdersConfirmation = SBSWebProject.Data.Entities.CompanyOrdersConfirmation;

namespace SBSWebProject.MappingObject.ModelToEntity
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
    }
}
