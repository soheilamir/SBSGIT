using System.Linq;
using Blogs = SBSWebProject.Data.Entities.Blogs;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class BlogsMapper : IMappingObject<Web.Api.Models.Blogs, Blogs>
    {
        public Blogs Map(Web.Api.Models.Blogs objectToMap)
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
        public Blogs Map(Web.Api.Models.Blogs objectToMap, Blogs refObj)
        {
            if (objectToMap == null) return null;
            var filesMapper = new FilesMapper();
            var sbsBranchTeamMapper = new SbsBranchTeamMapper();
            var websiteCategoryMapper = new WebsiteCategoryMapper();
            refObj.Id = objectToMap.Id;
            refObj.Context = objectToMap.Context;
            refObj.FilesItem = filesMapper.Map(objectToMap.FilesItem);
            refObj.PublishDate = objectToMap.PublishDate;
            refObj.SbsBranchTeamItem = sbsBranchTeamMapper.Map(objectToMap.SbsBranchTeamItem);
            refObj.Title = objectToMap.Title;
            refObj.WebsiteCategoryItem = websiteCategoryMapper.Map(objectToMap.WebsiteCategoryItem);
            return refObj;
        }
    }
}
