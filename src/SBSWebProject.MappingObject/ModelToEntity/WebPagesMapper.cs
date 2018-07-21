using System.Linq;
using WebPages = SBSWebProject.Data.Entities.WebPages;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class WebPagesMapper : IMappingObject<Web.Api.Models.WebPages, WebPages>
    {
        public WebPages Map(Web.Api.Models.WebPages objectToMap)
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
                //WebPageBannersS = objectToMap.WebPageBannersS.Select(item => webPageBannersMapper.Map(item)).ToList(),
                //WebPageContextS = objectToMap.WebPageContextS.Select(item => webPageContextMapper.Map(item)).ToList(),
                //WebsiteCategoryS = objectToMap.WebsiteCategoryS.Select(item => websiteCategoryMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
