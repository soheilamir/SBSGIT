using System.Linq;
using WebsiteCategory = SBSWebProject.Web.Api.Models.WebsiteCategory;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class WebsiteCategoryMapper : IMappingObject<Data.Entities.WebsiteCategory, WebsiteCategory>
    {
        public WebsiteCategory Map(Data.Entities.WebsiteCategory objectToMap)
        {
            if (objectToMap == null) return null;
            var blogsMapper = new BlogsMapper();
            var newsMapper = new NewsMapper();
            var webPagesMapper = new WebPagesMapper();
            var websiteCategoryMapper = new WebsiteCategoryMapper();
            var websiteFAQsMapper = new WebsiteFAQsMapper();
            var outputModel = new WebsiteCategory
            {
                Id = objectToMap.Id,
                BlogsS = objectToMap.BlogsS.Where(c => c.State == 0).Select(item => blogsMapper.Map(item)).ToList(),
                NewsS = objectToMap.NewsS.Where(c => c.State == 0).Select(item => newsMapper.Map(item)).ToList(),
                Title = objectToMap.Title,
                WebPagesItem = webPagesMapper.Map(objectToMap.WebPagesItem),
                WebsiteCategoryItem = websiteCategoryMapper.Map(objectToMap.WebsiteCategoryItem),
                //WebsiteCategoryS = objectToMap.WebsiteCategoryS.Where(c => c.State == 0).Select(item => websiteCategoryMapper.Map(item)).ToList(),
                //WebsiteFAQsS = objectToMap.WebsiteFAQsS.Where(c => c.State == 0).Select(item => websiteFAQsMapper.Map(item)).ToList(),
            };
            return outputModel;
        }
    }
}
