using System.Linq;
using SbsBranchAwards = SBSWebProject.Data.Entities.SbsBranchAwards;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class SbsBranchAwardsMapper : IMappingObject<Web.Api.Models.SbsBranchAwards, SbsBranchAwards>
    {
        public SbsBranchAwards Map(Web.Api.Models.SbsBranchAwards objectToMap)
        {
            if (objectToMap == null) return null;
            var filesMapper = new FilesMapper();
            var sbsBranchesMapper = new SbsBranchesMapper();
            var outputModel = new SbsBranchAwards
            {
                Id = objectToMap.Id,
                CatchDate = objectToMap.CatchDate,
                Description = objectToMap.Description,
                FilesItem = filesMapper.Map(objectToMap.FilesItem),
                SbsBranchesItem = sbsBranchesMapper.Map(objectToMap.SbsBranchesItem)
            };
            return outputModel;
        }
    }
}
