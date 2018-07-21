using System.Linq;
using WebPageContext = SBSWebProject.Data.Entities.WebPageContext;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class WebPageContextMapper : IMappingObject<Web.Api.Models.WebPageContext, WebPageContext>
    {
        public WebPageContext Map(Web.Api.Models.WebPageContext objectToMap)
        {
            if (objectToMap == null) return null;
            var webPagesMapper = new WebPagesMapper();
            var outputModel = new WebPageContext
            {
                Id = objectToMap.Id,
                Context = objectToMap.Context,
                WebPagesItem = webPagesMapper.Map(objectToMap.WebPagesItem)
            };
            return outputModel;
        }
    }
}
