using System.Linq;
using SbsBranchImages = SBSWebProject.Data.Entities.SbsBranchImages;

namespace SBSWebProject.MappingObject.ModelToEntity
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
    }
}
