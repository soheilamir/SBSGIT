using System.Linq;
using WebPageBanners = SBSWebProject.Web.Api.Models.WebPageBanners;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class WebPageBannersMapper : IMappingObject<Data.Entities.WebPageBanners, WebPageBanners>
    {
        public WebPageBanners Map(Data.Entities.WebPageBanners objectToMap)
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
