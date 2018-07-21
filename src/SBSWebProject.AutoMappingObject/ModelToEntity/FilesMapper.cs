using System.Linq;
using Files = SBSWebProject.Data.Entities.Files;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class FilesMapper : IMappingObject<Web.Api.Models.Files, Files>
    {
        public Files Map(Web.Api.Models.Files objectToMap)
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
                //CompanyAttachmentS = objectToMap.CompanyAttachmentS.Select(item => companyAttachmentMapper.Map(item)).ToList(),
                ExtensionsItem = extensionsMapper.Map(objectToMap.ExtensionsItem),
                FoldersItem = foldersMapper.Map(objectToMap.FoldersItem),
                UsersItem = usersMapper.Map(objectToMap.UsersItem),
                //BlogsS = objectToMap.BlogsS.Select(item => blogsMapper.Map(item)).ToList(),
                //NewsS = objectToMap.NewsS.Where(c => c.State == 0).Select(item => newsMapper.Map(item)).ToList(),
                //WebPageBannersS = objectToMap.WebPageBannersS.Select(item => webPageBannersMapper.Map(item)).ToList(),
                //SbsBranchTeamS = objectToMap.SbsBranchTeamS.Select(item => sbsBranchTeamMapper.Map(item)).ToList(),
                //SbsBranchImagesS = objectToMap.SbsBranchImagesS.Select(item => sbsBranchImagesMapper.Map(item)).ToList(),
                //SbsBranchAwardsS = objectToMap.SbsBranchAwardsS.Select(item => sbsBranchAwardsMapper.Map(item)).ToList(),
                //ReceivedResumeS = objectToMap.ReceivedResumeS.Select(item => receivedResumeMapper.Map(item)).ToList(),

            };
            return outputModel;
        }
        public Files Map(Web.Api.Models.Files objectToMap, Files refObj)
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
            refObj.Id = objectToMap.Id;
            refObj.FileName = objectToMap.FileName;
            refObj.FileSize = objectToMap.FileSize;
            refObj.FileUrl = objectToMap.FileUrl;
            refObj.UploadeDate = objectToMap.UploadeDate;
            //refObj.CompanyAttachmentS = objectToMap.CompanyAttachmentS.Select(item => companyAttachmentMapper.Map(item)).ToList();
            refObj.ExtensionsItem = extensionsMapper.Map(objectToMap.ExtensionsItem);
            refObj.FoldersItem = foldersMapper.Map(objectToMap.FoldersItem);
            refObj.UsersItem = usersMapper.Map(objectToMap.UsersItem);
            //BlogsS = objectToMap.BlogsS.Select(item => blogsMapper.Map(item)).ToList(),
            //NewsS = objectToMap.NewsS.Where(c => c.State == 0).Select(item => newsMapper.Map(item)).ToList(),
            //WebPageBannersS = objectToMap.WebPageBannersS.Select(item => webPageBannersMapper.Map(item)).ToList(),
            //SbsBranchTeamS = objectToMap.SbsBranchTeamS.Select(item => sbsBranchTeamMapper.Map(item)).ToList(),
            //SbsBranchImagesS = objectToMap.SbsBranchImagesS.Select(item => sbsBranchImagesMapper.Map(item)).ToList(),
            //SbsBranchAwardsS = objectToMap.SbsBranchAwardsS.Select(item => sbsBranchAwardsMapper.Map(item)).ToList(),
            //ReceivedResumeS = objectToMap.ReceivedResumeS.Select(item => receivedResumeMapper.Map(item)).ToList(),
            return refObj;
        }
    }
}
