using System.Linq;
using SbsSections = SBSWebProject.Web.Api.Models.SbsSections;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class SbsSectionMapper : IMappingObject<Data.Entities.SbsSections, SbsSections>
    {
        public SbsSections Map(Data.Entities.SbsSections objectToMap)
        {
            if (objectToMap == null) return null;
            var rolesInUserGroupMapper = new RolesInSectionMapper();
            var sbsBranchTeamMapper = new SbsBranchTeamMapper();
            var outputModel = new SbsSections
            {
                Id = objectToMap.Id,
                Name = objectToMap.Name,
                Description = objectToMap.Description,
                //RolesInSectionS = objectToMap.RolesInSectionS.Where(c=>c.State==0).Select(item=> rolesInUserGroupMapper.Map(item)).ToList(),
                //SbsBranchTeamS = objectToMap.SbsBranchTeamS.Where(c => c.State == 0).Select(item => sbsBranchTeamMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
