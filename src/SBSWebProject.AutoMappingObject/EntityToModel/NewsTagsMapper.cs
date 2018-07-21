using System.Linq;
using NewsTags = SBSWebProject.Web.Api.Models.NewsTags;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class NewsTagsMapper : IMappingObject<Data.Entities.NewsTags, NewsTags>
    {
        public NewsTags Map(Data.Entities.NewsTags objectToMap)
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
