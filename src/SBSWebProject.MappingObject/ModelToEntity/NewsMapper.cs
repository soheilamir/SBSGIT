using System.Linq;
using News = SBSWebProject.Data.Entities.News;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class NewsMapper : IMappingObject<Web.Api.Models.News, News>
    {
        public News Map(Web.Api.Models.News objectToMap)
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
                State = objectToMap.State,
                SubmitDate = objectToMap.SubmitDate,
                Title = objectToMap.Title,
                WebsiteCategoryItem = websiteCategoryMapper.Map(objectToMap.WebsiteCategoryItem)
            };
            return outputModel;
        }
    }
}
