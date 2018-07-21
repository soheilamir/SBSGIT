using System.Linq;
using SbsBranchAwards = SBSWebProject.Web.Api.Models.SbsBranchAwards;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class SbsBranchAwardsMapper : IMappingObject<Data.Entities.SbsBranchAwards, SbsBranchAwards>
    {
        public SbsBranchAwards Map(Data.Entities.SbsBranchAwards objectToMap)
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
