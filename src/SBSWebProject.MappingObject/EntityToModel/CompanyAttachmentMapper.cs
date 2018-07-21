using System.Linq;
using CompanyAttachment = SBSWebProject.Web.Api.Models.CompanyAttachment;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class CompanyAttachmentMapper : IMappingObject<Data.Entities.CompanyAttachment, CompanyAttachment>
    {
        public CompanyAttachment Map(Data.Entities.CompanyAttachment objectToMap)
        {
            if (objectToMap == null) return null;
            var ordersMapper = new OrdersMapper();
            var companyMapper = new CompanyMapper();
            var filesMapper = new FilesMapper();
            var outputModel = new CompanyAttachment
            {
                Id = objectToMap.Id,
                CompanyItem = companyMapper.Map(objectToMap.CompanyItem),
                IsDefect = objectToMap.IsDefect,
                OrdersItem = ordersMapper.Map(objectToMap.OrdersItem),
                ReasonOfDefect = objectToMap.ReasonOfDefect,
                FilesItem = filesMapper.Map(objectToMap.FilesItem)
            };
            return outputModel;
        }
    }
}
