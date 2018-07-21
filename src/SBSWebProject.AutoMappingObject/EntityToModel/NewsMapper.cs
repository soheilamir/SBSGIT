using System.Linq;
using News = SBSWebProject.Web.Api.Models.News;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class NewsMapper : IMappingObject<Data.Entities.News, News>
    {
        public News Map(Data.Entities.News objectToMap)
        {
            if (objectToMap == null) return null;
            var filesMapper = new FilesMapper();
            var websiteCategoryMapper = new WebsiteCategoryMapper();
            var outputModel = new News
            {
                Id = objectToMap.Id,
                Context = objectToMap.Context,
                FilesItem = filesMapper.Map(objectToMap.FilesItem),
                SourceLink = objectToMap.SourceLink,
                SourceName = objectToMap.SourceName,
                //State = objectToMap.State,
                SubmitDate = objectToMap.SubmitDate,
                Title = objectToMap.Title,
                WebsiteCategoryItem = websiteCategoryMapper.Map(objectToMap.WebsiteCategoryItem)
            };
            return outputModel;
        }
    }
}
