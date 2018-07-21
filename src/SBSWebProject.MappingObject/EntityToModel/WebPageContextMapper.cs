using System.Linq;
using WebPageContext = SBSWebProject.Web.Api.Models.WebPageContext;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class WebPageContextMapper : IMappingObject<Data.Entities.WebPageContext, WebPageContext>
    {
        public WebPageContext Map(Data.Entities.WebPageContext objectToMap)
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
