using System.Linq;
using WebsiteCategory = SBSWebProject.Data.Entities.WebsiteCategory;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class WebsiteCategoryMapper : IMappingObject<Web.Api.Models.WebsiteCategory, WebsiteCategory>
    {
        public WebsiteCategory Map(Web.Api.Models.WebsiteCategory objectToMap)
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
                //BlogsS = objectToMap.BlogsS.Select(item => blogsMapper.Map(item)).ToList(),
               // NewsS = objectToMap.NewsS.Where(c => c.State == 0).Select(item => newsMapper.Map(item)).ToList(),
                Title = objectToMap.Title,
                WebPagesItem = webPagesMapper.Map(objectToMap.WebPagesItem),
                WebsiteCategoryItem = websiteCategoryMapper.Map(objectToMap.WebsiteCategoryItem),
                //WebsiteCategoryS = objectToMap.WebsiteCategoryS.Select(item => websiteCategoryMapper.Map(item)).ToList(),
                //WebsiteFAQsS = objectToMap.WebsiteFAQsS.Select(item => websiteFAQsMapper.Map(item)).ToList(),
            };
            return outputModel;
        }
        public WebsiteCategory Map(Web.Api.Models.WebsiteCategory objectToMap, WebsiteCategory refObj)
        {
            if (objectToMap == null) return null;
            var blogsMapper = new BlogsMapper();
            var newsMapper = new NewsMapper();
            var webPagesMapper = new WebPagesMapper();
            var websiteCategoryMapper = new WebsiteCategoryMapper();
            var websiteFAQsMapper = new WebsiteFAQsMapper();

            refObj.Id = objectToMap.Id;
            //refObj.BlogsS = objectToMap.BlogsS.Select(item => blogsMapper.Map(item)).ToList();
            //refObj.NewsS = objectToMap.NewsS.Where(c => c.State == 0).Select(item => newsMapper.Map(item)).ToList();
            refObj.Title = objectToMap.Title;
            refObj.WebPagesItem = webPagesMapper.Map(objectToMap.WebPagesItem);
            refObj.WebsiteCategoryItem = websiteCategoryMapper.Map(objectToMap.WebsiteCategoryItem);
            //WebsiteCategoryS = objectToMap.WebsiteCategoryS.Select(item => websiteCategoryMapper.Map(item)).ToList(),
            //WebsiteFAQsS = objectToMap.WebsiteFAQsS.Select(item => websiteFAQsMapper.Map(item)).ToList(),
            return refObj;
        }
    }
}
