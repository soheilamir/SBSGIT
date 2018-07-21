using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using CompanyOrdersConfirmation = SBSWebProject.Web.Api.Models.CompanyOrdersConfirmation;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class CompanyOrdersConfirmationMapper : IMappingObject<Data.Entities.CompanyOrdersConfirmation, CompanyOrdersConfirmation>
    {
        public CompanyOrdersConfirmation Map(Data.Entities.CompanyOrdersConfirmation objectToMap)
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
