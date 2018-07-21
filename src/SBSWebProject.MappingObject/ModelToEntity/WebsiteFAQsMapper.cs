using System.Linq;
using WebsiteFAQs = SBSWebProject.Data.Entities.WebsiteFAQs;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class WebsiteFAQsMapper : IMappingObject<Web.Api.Models.WebsiteFAQs, WebsiteFAQs>
    {
        public WebsiteFAQs Map(Web.Api.Models.WebsiteFAQs objectToMap)
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
