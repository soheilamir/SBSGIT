using System.Linq;
using SbsBranchImages = SBSWebProject.Data.Entities.SbsBranchImages;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class SbsBranchImagesMapper : IMappingObject<Web.Api.Models.SbsBranchImages, SbsBranchImages>
    {
        public SbsBranchImages Map(Web.Api.Models.SbsBranchImages objectToMap)
        {
            if (objectToMap == null) return null;
            var filesMapper = new FilesMapper();
            var sbsBranchesMapper = new SbsBranchesMapper();
            var outputModel = new SbsBranchImages
            {
                Id = objectToMap.Id,
                Description = objectToMap.Description,
                FilesItem = filesMapper.Map(objectToMap.FilesItem),
                Title = objectToMap.Title,
                SbsBranchesItem = sbsBranchesMapper.Map(objectToMap.SbsBranchesItem),
            };
            return outputModel;
        }
        public SbsBranchImages Map(Web.Api.Models.SbsBranchImages objectToMap, SbsBranchImages refObj)
        {
            if (objectToMap == null) return null;
            var filesMapper = new FilesMapper();
            var sbsBranchesMapper = new SbsBranchesMapper();

            refObj.Id = objectToMap.Id;
            refObj.Description = objectToMap.Description;
            refObj.FilesItem = filesMapper.Map(objectToMap.FilesItem);
            refObj.Title = objectToMap.Title;
            refObj.SbsBranchesItem = sbsBranchesMapper.Map(objectToMap.SbsBranchesItem);
            return refObj;
        }
    }
}
