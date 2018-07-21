using System.Linq;
using NewsTags = SBSWebProject.Data.Entities.NewsTags;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class NewsTagsMapper : IMappingObject<Web.Api.Models.NewsTags, NewsTags>
    {
        public NewsTags Map(Web.Api.Models.NewsTags objectToMap)
        {
            if (objectToMap == null) return null;
            var newsMapper = new NewsMapper();
            var sbsTagsMapper = new SbsTagsMapper();
            var outputModel = new NewsTags
            {
                Id = objectToMap.Id,
                NewsItem = newsMapper.Map(objectToMap.NewsItem),
                SbstagsItem = sbsTagsMapper.Map(objectToMap.SbstagsItem)
            };
            return outputModel;
        }
        public NewsTags Map(Web.Api.Models.NewsTags objectToMap, NewsTags refObj)
        {
            if (objectToMap == null) return null;
            var newsMapper = new NewsMapper();
            var sbsTagsMapper = new SbsTagsMapper();
            refObj.Id = objectToMap.Id;
            refObj.NewsItem = newsMapper.Map(objectToMap.NewsItem);
            refObj.SbstagsItem = sbsTagsMapper.Map(objectToMap.SbstagsItem);
            return refObj;
        }
    }
}
