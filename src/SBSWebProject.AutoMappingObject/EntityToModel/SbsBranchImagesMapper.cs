using System.Linq;
using SbsBranchImages = SBSWebProject.Web.Api.Models.SbsBranchImages;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class SbsBranchImagesMapper : IMappingObject<Data.Entities.SbsBranchImages, SbsBranchImages>
    {
        public SbsBranchImages Map(Data.Entities.SbsBranchImages objectToMap)
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
