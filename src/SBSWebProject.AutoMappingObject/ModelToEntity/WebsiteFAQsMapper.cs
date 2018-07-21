using System.Linq;
using WebsiteFAQs = SBSWebProject.Data.Entities.WebsiteFAQs;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
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
        public WebsiteFAQs Map(Web.Api.Models.WebsiteFAQs objectToMap, WebsiteFAQs refObj)
        {
            if (objectToMap == null) return null;
            var websiteCategoryMapper = new WebsiteCategoryMapper();
            refObj.Id = objectToMap.Id;
            refObj.Answer = objectToMap.Answer;
            refObj.Question = objectToMap.Question;
            refObj.WebsiteCategoryItem = websiteCategoryMapper.Map(objectToMap.WebsiteCategoryItem);
            return refObj;
        }
    }
}
