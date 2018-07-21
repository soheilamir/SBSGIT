using System.Linq;
using Files = SBSWebProject.Web.Api.Models.Files;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class FilesMapper : IMappingObject<Data.Entities.Files, Files>
    {
        public Files Map(Data.Entities.Files objectToMap)
        {
            if (objectToMap == null) return null;
            var companyAttachmentMapper = new CompanyAttachmentMapper();
            var usersMapper = new UsersMapper();
            var extensionsMapper = new ExtensionsMapper();
            var foldersMapper = new FoldersMapper();
            var blogsMapper = new BlogsMapper();
            var newsMapper = new NewsMapper();
            var webPageBannersMapper = new WebPageBannersMapper();
            var sbsBranchTeamMapper = new SbsBranchTeamMapper();
            var sbsBranchImagesMapper = new SbsBranchImagesMapper();
            var sbsBranchAwardsMapper = new SbsBranchAwardsMapper();
            var receivedResumeMapper = new ReceivedResumeMapper();
            var outputModel = new Files
            {
                Id = objectToMap.Id,
                FileName = objectToMap.FileName,
                FileSize = objectToMap.FileSize,
                FileUrl = objectToMap.FileUrl,
                UploadeDate = objectToMap.UploadeDate,
                
                ExtensionsItem = extensionsMapper.Map(objectToMap.ExtensionsItem),
                FoldersItem = foldersMapper.Map(objectToMap.FoldersItem),
                UsersItem = usersMapper.Map(objectToMap.UsersItem),
                //CompanyAttachmentS = objectToMap.CompanyAttachmentS.Where(c => c.State == 0).Select(item => companyAttachmentMapper.Map(item)).ToList(),
                //BlogsS = objectToMap.BlogsS.Where(c => c.State == 0).Select(item => blogsMapper.Map(item)).ToList(),
                //NewsS = objectToMap.NewsS.Where(c => c.State == 0).Select(item => newsMapper.Map(item)).ToList(),
                //WebPageBannersS = objectToMap.WebPageBannersS.Where(c => c.State == 0).Select(item => webPageBannersMapper.Map(item)).ToList(),
                //SbsBranchTeamS = objectToMap.SbsBranchTeamS.Where(c => c.State == 0).Select(item => sbsBranchTeamMapper.Map(item)).ToList(),
                //SbsBranchImagesS = objectToMap.SbsBranchImagesS.Where(c => c.State == 0).Select(item => sbsBranchImagesMapper.Map(item)).ToList(),
                //SbsBranchAwardsS = objectToMap.SbsBranchAwardsS.Where(c => c.State == 0).Select(item => sbsBranchAwardsMapper.Map(item)).ToList(),
                //ReceivedResumeS = objectToMap.ReceivedResumeS.Where(c => c.State == 0).Select(item => receivedResumeMapper.Map(item)).ToList(),

            };
            return outputModel;
        }
    }
}
