using System.Linq;
using WebsiteFAQs = SBSWebProject.Web.Api.Models.WebsiteFAQs;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class WebsiteFAQsMapper : IMappingObject<Data.Entities.WebsiteFAQs, WebsiteFAQs>
    {
        public WebsiteFAQs Map(Data.Entities.WebsiteFAQs objectToMap)
        {
            if (objectToMap == null) return null;
            var websiteCategoryMapper = new WebsiteCategoryMapper();
            var outputModel = new WebsiteFAQs
            {
                Id = objectToMap.Id,
                Answer = objectToMap.Answer,
                Question = objectToMap.Question,
                WebsiteCategoryItem = websiteCategoryMapper.Map(objectToMap.WebsiteCategoryItem)
            };
            return outputModel;
        }
    }
}
