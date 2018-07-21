using System.Linq;
using WebPageBanners = SBSWebProject.Data.Entities.WebPageBanners;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class WebPageBannersMapper : IMappingObject<Web.Api.Models.WebPageBanners, WebPageBanners>
    {
        public WebPageBanners Map(Web.Api.Models.WebPageBanners objectToMap)
        {
            if (objectToMap == null) return null;
            var filesMapper = new FilesMapper();
            var webPagesMapper = new WebPagesMapper();
            var outputModel = new WebPageBanners
            {
                Id = objectToMap.Id,
                Description = objectToMap.Description,
                FilesItem = filesMapper.Map(objectToMap.FilesItem),
                Title = objectToMap.Title,
                WebPagesItem = webPagesMapper.Map(objectToMap.WebPagesItem),
            };
            return outputModel;
        }
    }
}
