using System.Linq;
using WebPages = SBSWebProject.Web.Api.Models.WebPages;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class WebPagesMapper : IMappingObject<Data.Entities.WebPages, WebPages>
    {
        public WebPages Map(Data.Entities.WebPages objectToMap)
        {
            if (objectToMap == null) return null;
            var webPageBannersMapper = new WebPageBannersMapper();
            var webPageContextMapper = new WebPageContextMapper();
            var websiteCategoryMapper = new WebsiteCategoryMapper();
            var outputModel = new WebPages
            {
                Id = objectToMap.Id,
                Description = objectToMap.Description,
                PageName = objectToMap.PageName,
                RoutUrl = objectToMap.RoutUrl,
                SourceUrl = objectToMap.SourceUrl,
                Title = objectToMap.Title,
                //WebPageBannersS = objectToMap.WebPageBannersS.Where(c => c.State == 0).Select(item => webPageBannersMapper.Map(item)).ToList(),
                //WebPageContextS = objectToMap.WebPageContextS.Where(c => c.State == 0).Select(item => webPageContextMapper.Map(item)).ToList(),
                //WebsiteCategoryS = objectToMap.WebsiteCategoryS.Where(c => c.State == 0).Select(item => websiteCategoryMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
