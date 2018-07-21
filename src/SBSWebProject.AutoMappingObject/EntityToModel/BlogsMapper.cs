using System.Linq;
using Blogs = SBSWebProject.Web.Api.Models.Blogs;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class BlogsMapper : IMappingObject<Data.Entities.Blogs, Blogs>
    {
        public Blogs Map(Data.Entities.Blogs objectToMap)
        {
            if (objectToMap == null) return null;
            var filesMapper = new FilesMapper();
            var sbsBranchTeamMapper = new SbsBranchTeamMapper();
            var websiteCategoryMapper = new WebsiteCategoryMapper();
            var outputModel = new Blogs
            {
                Id = objectToMap.Id,
                Context = objectToMap.Context,
                FilesItem = filesMapper.Map(objectToMap.FilesItem),
                PublishDate = objectToMap.PublishDate,
                SbsBranchTeamItem = sbsBranchTeamMapper.Map(objectToMap.SbsBranchTeamItem),
                Title = objectToMap.Title,
                WebsiteCategoryItem = websiteCategoryMapper.Map(objectToMap.WebsiteCategoryItem),
            };
            return outputModel;
        }
    }
}
