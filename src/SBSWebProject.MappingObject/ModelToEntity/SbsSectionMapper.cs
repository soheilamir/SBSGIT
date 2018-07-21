using System.Linq;
using SbsSection = SBSWebProject.Data.Entities.SbsSections;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class SbsSectionMapper : IMappingObject<Web.Api.Models.SbsSections, SbsSection>
    {
        public SbsSection Map(Web.Api.Models.SbsSections objectToMap)
        {
            if (objectToMap == null) return null;
            var rolesInUserGroupMapper = new RolesInSectionMapper();
            var sbsBranchTeamMapper = new SbsBranchTeamMapper();
            var outputModel = new SbsSection
            {
                Id = objectToMap.Id,
                Name = objectToMap.Name,
                Description = objectToMap.Description,
                //RolesInSectionS = objectToMap.RolesInSectionS.Select(item=> rolesInUserGroupMapper.Map(item)).ToList(),
                //SbsBranchTeamS = objectToMap.SbsBranchTeamS.Select(item => sbsBranchTeamMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
