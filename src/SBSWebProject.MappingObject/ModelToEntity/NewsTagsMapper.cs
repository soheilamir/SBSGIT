using System.Linq;
using NewsTags = SBSWebProject.Data.Entities.NewsTags;

namespace SBSWebProject.MappingObject.ModelToEntity
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
    }
}
