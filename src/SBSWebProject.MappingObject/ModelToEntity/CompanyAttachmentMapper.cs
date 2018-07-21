using System.Linq;
using CompanyAttachment = SBSWebProject.Data.Entities.CompanyAttachment;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class CompanyAttachmentMapper : IMappingObject<Web.Api.Models.CompanyAttachment, CompanyAttachment>
    {
        public CompanyAttachment Map(Web.Api.Models.CompanyAttachment objectToMap)
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
